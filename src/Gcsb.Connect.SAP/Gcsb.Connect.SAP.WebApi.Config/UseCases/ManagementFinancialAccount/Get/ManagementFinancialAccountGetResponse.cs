using Gcsb.Connect.SAP.WebApi.Config.Model.ManagementFinancialAccount;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Get
{
    public sealed class ManagementFinancialAccountGetResponse
    {   
        public Guid Id { get; private set; }
        public Boleto Boleto { get; private set; }
        public CreditCard CreditCard { get; private set; }
        public Unassigned Unassigned { get; private set; }
        public Critic Critic { get; private set; }
        public Transferred Transferred { get; private set; }

        public ManagementFinancialAccountGetResponse(Guid id ,Boleto boleto, CreditCard creditCard, Unassigned unassigned, Critic critic, Transferred transferred)
        {
            Id = id;
            Boleto = boleto;
            CreditCard = creditCard;
            Unassigned = unassigned;
            Critic = critic;
            Transferred = transferred;
        }
    }
}
