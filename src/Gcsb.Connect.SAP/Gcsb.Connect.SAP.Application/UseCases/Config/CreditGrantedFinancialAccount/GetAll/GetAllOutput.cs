using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetAll
{
    public class GetAllOutput
    {
        public List<Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount> CreditGrantedFinancialAccounts { get; private set; }

        public GetAllOutput(List<Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount> creditGrantedFinancialAccounts)
        {
            CreditGrantedFinancialAccounts = creditGrantedFinancialAccounts;
        }
    }
}
