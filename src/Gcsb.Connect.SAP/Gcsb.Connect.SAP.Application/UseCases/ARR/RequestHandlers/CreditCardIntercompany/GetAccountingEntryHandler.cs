using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.Pkg.Datamart.Application.Contract;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCardIntercompany
{
    public class GetAccountingEntryHandler : Handler<ARRCreditCardInter>, IGetAccountingEntryHandler<ARRCreditCardInter>
    {
        private readonly IGetDatamartResult getDatamartResult;

        public GetAccountingEntryHandler(IGetDatamartResult getDatamartResult)
        {
            this.getDatamartResult = getDatamartResult;
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCardInter> request)
        {
            request.AddProcessingLog("Get Accounting Account of Financial Account");

            var listAccountingEntry = new List<AccountingEntry>();

            if (request.AccountsDto.Any(s => s.CreditCard.FinancialAccount == null || s.CreditCard.AccountingAccountCredit == null || s.CreditCard.AccountingAccountDebit == null))
                throw new ArgumentException("Not all Accounting Entry have been configured");
            
            listAccountingEntry.AddRange(request.AccountsDto.Select(s => new AccountingEntry(s.CreditCard.FinancialAccount, "C", s.CreditCard.AccountingAccountCredit, Domain.Util.ToEnum<StoreType>(s.StoreAcronym), true)));
            listAccountingEntry.AddRange(request.AccountsDto.Select(s => new AccountingEntry(s.CreditCard.FinancialAccount, "D", s.CreditCard.AccountingAccountDebit, Domain.Util.ToEnum<StoreType>(s.StoreAcronym), true)));

            request.AccountingEntriesArrecadacao = listAccountingEntry;

            var servicesIncompany = getDatamartResult.GetAllServicesIntercompany();

            request.AccountsARR = request.Services
            .Join(request.AccountingEntriesArrecadacao, s => Domain.Util.ToEnum<StoreType>(s.ProviderCompanyAcronym), a => a.Provider, (s, a) => new { s, a })
            .Select(s => new AccountARR(
                s.s.Invoice.InvoiceNumber,
                s.s.ServiceCode,
                s.a.ArrecadacaoARR,
                s.a.AccountingEntryType,
                s.a.AccountingAccount,
                Domain.Util.ToEnum<StoreType>(s.s.StoreAcronym),
                Domain.Util.ToEnum<StoreType>(s.s.ProviderCompanyAcronym),
                s.a.HaveIntercompany,
                s.a.HaveIntercompany ? servicesIncompany.Any(a => a.ServiceCode == s.s.ServiceCode && a.Store == s.s.StoreAcronym && a.Provider == s.s.ProviderCompanyAcronym) : true))
            .ToList();

            sucessor?.ProcessRequest(request);
        }
    }
}
