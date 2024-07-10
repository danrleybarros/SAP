using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Gcsb.Connect.SAP.WebApi.Config.Model.InterestAndFineFinancialAccount;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.GetAll
{
    public class InterestAndFineFinancialAccountGetAllResponse
    {
        public List<Model::FinancialAccount> FinancialAccount { get; private set; }

        public InterestAndFineFinancialAccountGetAllResponse(List<Model::FinancialAccount> financialAccount)
        {
            FinancialAccount = financialAccount;
        }
    }
}
