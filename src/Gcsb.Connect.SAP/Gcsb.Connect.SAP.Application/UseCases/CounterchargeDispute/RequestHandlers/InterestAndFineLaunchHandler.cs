using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class InterestAndFineLaunchHandler : Handler
    {
        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Start processing CounterchargeDispute - LaunchHandler");

            var stores = request.CounterchargeDisputesAdjustment.Select(s => s.StoreAcronym).Distinct().ToList();
            var cycle = request.DateTo;

            foreach (var store in stores)
            {
                var storeType = Domain.Util.ToEnum<StoreType>(store);

                if (storeType.Equals(StoreType.Others))
                    continue;

                var fileAJULineCount = request.Lines.ContainsKey(storeType) ? request.Lines[storeType].Count : 0;
                var financialAccount = request.InterestAndFineFinancialAccounts.FirstOrDefault(a => a.Store.Equals(storeType));
                var interestFinancialAccount = GetAccountingEntries(financialAccount, "interest");
                var finesFinancialAccount = GetAccountingEntries(financialAccount, "fines");
                var lines = new List<Launch>();

                var validateFinancialAccount = interestFinancialAccount
                    .Any(f => string.IsNullOrEmpty(f.financialAccount) || string.IsNullOrEmpty(f.paidInvoiceFinancialAcount) || string.IsNullOrEmpty(f.unpaidInvoiceFinancialAcount));

                if (validateFinancialAccount)
                    throw new ArgumentException("Not all financial Account for Interest have register");

                validateFinancialAccount = finesFinancialAccount
                    .Any(f => string.IsNullOrEmpty(f.financialAccount) || string.IsNullOrEmpty(f.paidInvoiceFinancialAcount) || string.IsNullOrEmpty(f.unpaidInvoiceFinancialAcount));

                if (validateFinancialAccount)
                    throw new ArgumentException("Not all financial Account for fines have register");

                var interestCounterChargeDisputes = request.CounterchargeDisputesAdjustment.Where(d => d.StoreAcronym.ToLower().Equals(store.ToLower()) && d.TipoAtividade.ToLower() == "interest").ToList();
                var finesCounterChargeDisputes = request.CounterchargeDisputesAdjustment.Where(d => d.StoreAcronym.ToLower().Equals(store.ToLower()) && d.TipoAtividade.ToLower() == "fines").ToList();

                lines.AddRange(GetLines(interestCounterChargeDisputes, interestFinancialAccount, storeType, request.DateTo, request.DateFrom, fileAJULineCount));
                fileAJULineCount += lines.Count;
                lines.AddRange(GetLines(finesCounterChargeDisputes, finesFinancialAccount, storeType, request.DateTo, request.DateFrom, fileAJULineCount));

                request.AddLaunchs(storeType, lines);
            };

            sucessor?.ProcessRequest(request);
        }

        private List<Launch> GetLines(List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute> counterchargeDisputes,
            List<(string financialAccount, string accountingEntry, string paidInvoiceFinancialAcount, string unpaidInvoiceFinancialAcount)> financialAccount,
            StoreType storeType,
            DateTime dateTo,
            DateTime dateFrom,
            int lineCount)
        {
            var launches = counterchargeDisputes
                        .Where(f => f.ValorContestado.HasValue && f.ValorContestado != 0)
                        .Select(s => new
                        {
                            uf = s.UF,
                            s.MetodoPagamento,
                            ValorContestado = Math.Abs(s.ValorContestado.Value),
                            s.TipoDisputa
                        })
                        .GroupBy(s => new { s.uf, s.MetodoPagamento, s.TipoDisputa })
                        .Select(e => new
                        {
                            e.Key.TipoDisputa,
                            launchValue_current = e.Sum(ss => ss.ValorContestado),
                            e.Key.uf,
                            internalOrder = Util.GetUF(e.Key.uf, storeType).InternalOrder,
                            PaymentMethod = e.Key.MetodoPagamento,
                        })
                        .Where(f => f.launchValue_current != 0)
                        .SelectMany(m => financialAccount, (service, account) => new { service, account })
                        .Select(sn => new Launch(
                                ++lineCount,
                                dateFrom,
                                sn.account.financialAccount,
                                sn.service.launchValue_current,
                                sn.service.internalOrder,
                                dateTo,
                                sn.service.uf,
                                sn.service.PaymentMethod.RemoveAccents(),
                                sn.account.accountingEntry,
                                sn.service.TipoDisputa == "Future Account" ? sn.account.paidInvoiceFinancialAcount : sn.account.unpaidInvoiceFinancialAcount,
                                storeType)
                        )
                        .ToList();
            return launches;
        }

        private List<(string financialAccount, string accountingEntry, string paidInvoiceFinancialAcount, string unpaidInvoiceFinancialAcount)> GetAccountingEntries(InterestAndFineFinancialAccount financialAccount, string activityType)
        {
            return (activityType.ToLower()) switch
            {
                "interest" => new List<(string financialAccount, string accountingEntry, string finesPaidInvoiceFinancialAcount, string finesUnpaidInvoiceFinancialAcount)>
                    {
                    (financialAccount.Interest.FinancialAccount, "C",
                    financialAccount.Interest.PaidInvoice.Credit, financialAccount.Interest.UnpaidInvoice.Credit),
                    (financialAccount.Interest.FinancialAccount, "D",
                    financialAccount.Interest.PaidInvoice.Debit, financialAccount.Interest.UnpaidInvoice.Debit)
                    },
                "fines" => new List<(string financialAccount, string accountingEntry, string finesPaidInvoiceFinancialAcount, string finesUnpaidInvoiceFinancialAcount)>
                    {
                    (financialAccount.Fine.FinancialAccount, "C",
                    financialAccount.Fine.PaidInvoice.Credit, financialAccount.Fine.UnpaidInvoice.Credit),
                    (financialAccount.Fine.FinancialAccount, "D",
                    financialAccount.Fine.PaidInvoice.Debit, financialAccount.Fine.UnpaidInvoice.Debit)
                    },
                _ => null,
            };
        }
    }
}
