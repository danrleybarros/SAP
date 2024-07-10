using Gcsb.Connect.Pkg.Datamart.Application.Contract;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.BoletoIntercompany
{
    public class GetAccountingEntryHandler : Handler<ARRBoletoInter>, IGetAccountingEntryHandler<ARRBoletoInter>
    {
        private readonly IGetDatamartResult getDatamartResult;

        public GetAccountingEntryHandler(IGetDatamartResult getDatamartResult)
        {
            this.getDatamartResult = getDatamartResult;
        }

        public override void ProcessRequest(IARRRequest<ARRBoletoInter> request)
        {
            request.AddProcessingLog("Get Accounting Account of Intercompany Financial Account");

            var listAccountingEntry = new List<AccountingEntry>();
            var listUnassigned = new List<AccountingEntry>();

            if (request.Accounts.Any(s => s.ARR.Boleto.FinancialAccount == null || s.ARR.Boleto.AccountingAccount.Credit == null || s.ARR.Boleto.AccountingAccount.Debit == null))
                throw new ArgumentException("Not all Accounting Entry have been configured");

            listAccountingEntry.AddRange(request.AccountsDto.Select(s => new AccountingEntry(s.Boleto.FinancialAccount, "C", s.Boleto.AccountingAccountCredit, Domain.Util.ToEnum<StoreType>(s.StoreAcronym), true)));
            listAccountingEntry.AddRange(request.AccountsDto.Select(s => new AccountingEntry(s.Boleto.FinancialAccount, "D", s.Boleto.AccountingAccountDebit, Domain.Util.ToEnum<StoreType>(s.StoreAcronym), true)));

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
