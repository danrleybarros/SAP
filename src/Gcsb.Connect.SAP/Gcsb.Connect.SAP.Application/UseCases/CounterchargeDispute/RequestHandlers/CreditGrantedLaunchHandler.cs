using Gcsb.Connect.SAP.Domain;
using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.Config.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class CreditGrantedLaunchHandler : Handler
    {
        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Start processing CounterchargeDispute - CreditGrantedLaunchHandler");

            var stores = request.CounterchargeDisputesBilling.Select(s => s.StoreAcronym).Distinct().ToList();

            var activityTypes = new List<string>() { "CREDITS", "INTEREST", "FINES" };
            var interestAndFinesChargebackReceivables = new string[] { "SPJURTBRAC", "SPMULTBRAC", "SPJURCLOUDCOC", "SPMULCLOUDCOC" };

            foreach (var store in stores)
            {
                var storeType = Domain.Util.ToEnum<StoreType>(store);

                if (storeType.Equals(StoreType.Others))
                    continue;

                var lineCount = request.Lines.FirstOrDefault(l => l.Key.Equals(storeType)).Value?.Count ?? 0;
                var creditGrantedCounterchargeDisputes = request.CounterchargeDisputesBilling.Where(c => c.StoreAcronym.Equals(store) && c.TipoDisputa.Equals("Future Account") && activityTypes.Contains(c.TipoAtividade.ToUpper()) && c.ValorContestado != 0).ToList();
                var interestAndFineCounterchargeChargeback = request.CounterchargeDisputesBilling
                    .Where(c => c.StoreAcronym.Equals(store) 
                            && c.TipoDisputa.Equals("Future Account") 
                            && c.TipoAtividade.Equals("Countercharge Chargeback") 
                            && interestAndFinesChargebackReceivables.Contains(c.AReceber)).ToList();
                creditGrantedCounterchargeDisputes.AddRange(interestAndFineCounterchargeChargeback);

                if (creditGrantedCounterchargeDisputes.Any())
                {
                    var financialAccount = request.CreditGrantedFinancialAccounts.FirstOrDefault(a => a.StoreAcronym.Equals(storeType));

                    var launches = GetLines(creditGrantedCounterchargeDisputes, financialAccount, request.DateFrom, request.DateTo, lineCount, storeType);

                    request.AddLaunchs(storeType, launches);
                }
            };

            sucessor?.ProcessRequest(request);
        }

        private List<Launch> GetLines(List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute> creditGrantedCounterchargeDisputes,
            CreditGrantedFinancialAccount financialAccount,
            DateTime launchDate,
            DateTime billingCycle,
            int lineCount,
            StoreType storeType)
        {

            var accountingAccounts = new List<ServiceAccountingAccountAJU>()
            {
                new ServiceAccountingAccountAJU(financialAccount.CreditGrantedAJU, TypeAccounting.Credito, financialAccount.AccountingAccountCred),
                new ServiceAccountingAccountAJU(financialAccount.CreditGrantedAJU, TypeAccounting.Debito, financialAccount.AccountingAccountDeb),
            };

            var grouping = creditGrantedCounterchargeDisputes.Where(f => f.ValorContestado.HasValue && f.ValorContestado != 0 && f.MetodoPagamento != null)
                       .GroupBy(g => new { g.MetodoPagamento, g.TipoDisputa, g.UF })
                       .Select((s) => new
                       {
                           s.Key.MetodoPagamento,
                           s.Key.TipoDisputa,
                           s.Key.UF,
                           ValorContestado = s.Sum(m => m.ValorContestado.Value)
                       });

            return grouping
                      .SelectMany(c => accountingAccounts, (credit, account) => new { credit, account })
                      .Select((s) => new Launch(
                          ++lineCount,
                          launchDate,
                          s.account.FinancialAccount,
                          s.credit.ValorContestado,
                          Util.GetUF(s.credit.UF, storeType).InternalOrder,
                          billingCycle,
                          s.credit.UF,
                          s.credit.MetodoPagamento.RemoveAccents(),
                          s.account.Type.GetAttributeOfType<EnumMemberAttribute>().Value,
                          s.account.AccountingAccount[0],
                          storeType
                          ))
                      .ToList();
        }
    }
}
