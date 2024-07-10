using Gcsb.Connect.Pkg.Datamart.Application.Contract;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCard
{
    public class GetAccountingEntryHandler : Handler<ARRCreditCard>, IGetAccountingEntryHandler<ARRCreditCard>
    {
        private readonly IGetDatamartResult getDatamartResult;

        public GetAccountingEntryHandler(IGetDatamartResult getDatamartResult)
        {
            this.getDatamartResult = getDatamartResult;
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCard> request)
        {
            request.AddProcessingLog("Get Accounting Account of Financial Account");

            var listAccountingEntry = new List<AccountingEntry>();

            if (request.AccountsDto.Any(s => s.CreditCard.FinancialAccount == null || 
                                        s.CreditCard.AccountingAccountCredit == null || 
                                        s.CreditCard.AccountingAccountDebit == null))
                throw new ArgumentException("Not all Accounting Entry have been configured");

            request.AccountsDto.ForEach(fa =>
            {
                listAccountingEntry.Add(new AccountingEntry(fa.CreditCard.FinancialAccount, "C", fa.CreditCard.AccountingAccountCredit, Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), false));
                listAccountingEntry.Add(new AccountingEntry(fa.CreditCard.FinancialAccount, "D", fa.CreditCard.AccountingAccountDebit, Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), false));

                fa.CreditCard.Intercompany.ForEach(fb =>
                {
                    listAccountingEntry.Add(new AccountingEntry(fa.CreditCard.FinancialAccount, "C", fb.AccountingAccountCredit, Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), Domain.Util.ToEnum<StoreType>(fb.ProviderCompany), true));
                    listAccountingEntry.Add(new AccountingEntry(fa.CreditCard.FinancialAccount, "D", fb.AccountingAccountDebit, Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), Domain.Util.ToEnum<StoreType>(fb.ProviderCompany), true));
                });
            });

            request.AccountingEntriesArrecadacao = listAccountingEntry;

            var servicesIncompany = getDatamartResult.GetAllServicesIntercompany();

            request.AccountsARR = request.Services
                .Join(request.AccountingEntriesArrecadacao, s => Domain.Util.ToEnum<StoreType>(s.StoreAcronym), a => a.Store, (s, a) => new { s, a })
                .Select(s => new AccountARR(
                    s.s.Invoice.InvoiceNumber,
                    s.s.ServiceCode,
                    s.a.ArrecadacaoARR,
                    s.a.AccountingEntryType,
                    s.a.AccountingAccount,
                    s.a.Store,
                    s.a.Provider,
                    s.a.HaveIntercompany,
                    s.a.HaveIntercompany ? servicesIncompany.Any(a => a.ServiceCode == s.s.ServiceCode && Domain.Util.ToEnum<StoreType>(a.Store) == s.a.Store && Domain.Util.ToEnum<StoreType>(a.Provider) == s.a.Provider) : true))
                .ToList();

            sucessor?.ProcessRequest(request);
        }
    }
}
