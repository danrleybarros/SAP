using Gcsb.Connect.Pkg.Datamart.Application.Contract;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.Boleto
{
    public class GetAccountingEntryHandler : Handler<ARRBoleto>, IGetAccountingEntryHandler<ARRBoleto>
    {
        private readonly IGetDatamartResult getDatamartResult;

        public GetAccountingEntryHandler(IGetDatamartResult getDatamartResult)
        {
            this.getDatamartResult = getDatamartResult;
        }

        public override void ProcessRequest(IARRRequest<ARRBoleto> request)
        {
            request.AddProcessingLog("Get Accounting Account of Financial Account");

            var listAccountingEntry = new List<AccountingEntry>();
            var listUnassigned = new List<AccountingEntry>();

            if (request.AccountsDto.Any(s => s.Boleto.FinancialAccount == null ||
                                     s.Boleto.AccountingAccountCredit == null ||
                                     s.Boleto.AccountingAccountDebit == null ||
                                     s.Unassigned.FinancialAccount == null ||
                                     s.Unassigned.AccountingAccountCredit == null ||
                                     s.Unassigned.AccountingAccountDebit == null))
                throw new ArgumentException("Not all Accounting Entry have been configured");
                                        
            request.AccountsDto.ForEach(fa =>
            {
                listAccountingEntry.Add(new AccountingEntry(fa.Boleto.FinancialAccount, "C", fa.Boleto.AccountingAccountCredit, Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), false));
                listAccountingEntry.Add(new AccountingEntry(fa.Boleto.FinancialAccount, "D", fa.Boleto.AccountingAccountDebit, Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), false));

                fa.Boleto.Intercompany.ForEach(fb =>
                {
                    listAccountingEntry.Add(new AccountingEntry(fa.Boleto.FinancialAccount, "C", fb.AccountingAccountCredit, Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), Domain.Util.ToEnum<StoreType>(fb.ProviderCompany), true));
                    listAccountingEntry.Add(new AccountingEntry(fa.Boleto.FinancialAccount, "D", fb.AccountingAccountDebit, Domain.Util.ToEnum<StoreType>(fa.StoreAcronym), Domain.Util.ToEnum<StoreType>(fb.ProviderCompany), true));
                });                                
            });

            request.AccountingEntriesArrecadacao = listAccountingEntry;

            listUnassigned.AddRange(request.Accounts.Select(s => new AccountingEntry(s.Unassigned.FinancialAccount, "C", s.Unassigned.AccountingAccount.Credit, s.StoreType)));
            listUnassigned.AddRange(request.Accounts.Select(s => new AccountingEntry(s.Unassigned.FinancialAccount, "D", s.Unassigned.AccountingAccount.Debit, s.StoreType)));

            request.AccountingUnassignedEntriesArrecadacao = listUnassigned;

            var servicesIncompany = getDatamartResult.GetAllServicesIntercompany();

            /*Contas financeiras dos serviços com Intercompany*/
            request.AccountsARR = request.Services                
                .Join(request.AccountingEntriesArrecadacao.Where(w => w.HaveIntercompany == true),
                    s => new { storeAcronym = Domain.Util.ToEnum<StoreType>(s.StoreAcronym), providerCompanyAcronym = Domain.Util.ToEnum<StoreType>(s.ProviderCompanyAcronym) },
                    a => new { storeAcronym = a.Store, providerCompanyAcronym = a.Provider }, (s, a) => new { s, a })                
                .Select(s => new AccountARR(
                    s.s.Invoice.InvoiceNumber,
                    s.s.ServiceCode,
                    s.a.ArrecadacaoARR,
                    s.a.AccountingEntryType,
                    s.a.AccountingAccount,
                    s.a.Store,
                    s.a.Provider,
                    s.a.HaveIntercompany,
                    servicesIncompany.Any(a => a.ServiceCode == s.s.ServiceCode && Domain.Util.ToEnum<StoreType>(a.Store) == s.a.Store && Domain.Util.ToEnum<StoreType>(a.Provider) == s.a.Provider)))
                .ToList();

            sucessor?.ProcessRequest(request);
        }
    }
}
