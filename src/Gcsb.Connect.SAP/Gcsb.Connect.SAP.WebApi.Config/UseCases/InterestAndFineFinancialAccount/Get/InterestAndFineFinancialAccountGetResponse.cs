using System;
using Model = Gcsb.Connect.SAP.WebApi.Config.Model.InterestAndFineFinancialAccount;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.Get
{
    public class InterestAndFineFinancialAccountGetResponse
    {
        public Guid Id { get; private set; }
        public Model::FinancialAccount FinancialAccount { get; private set; }

        public InterestAndFineFinancialAccountGetResponse(Guid id,
            Model::FinancialAccount financialAccount)
        {
            Id = id;
            FinancialAccount = financialAccount;
        }
    }
}
