using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount
{
    public class ManagementFinancialAccountBuilder
    {
        public Guid Id;
        public Domain.Config.ManagementFinancialAccount.ARR ARR;
        public Unassigned Unassigned;
        public Critic Critic;
        public Transferred Transfer;
        public StoreType StoreType;

        public static ManagementFinancialAccountBuilder New()
        {
            return new ManagementFinancialAccountBuilder
            {
                Id = Guid.NewGuid(),
                ARR = ARRBuilder.New().Build(),
                Unassigned = UnassignedBuilder.New().Build(),
                Critic = CriticBuilder.New().Build(),
                Transfer = TransferBuilder.New().Build(),
                StoreType = StoreType.TBRA
            };
        }

        public ManagementFinancialAccountBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public ManagementFinancialAccountBuilder WithARR(Domain.Config.ManagementFinancialAccount.ARR arr)
        {
            ARR = arr;
            return this;
        }

        public ManagementFinancialAccountBuilder WithUnassigned(Unassigned unassigned)
        {
            Unassigned = unassigned;
            return this;
        }

        public ManagementFinancialAccountBuilder WithCritic(Critic critic)
        {
            Critic = critic;
            return this;
        }

        public ManagementFinancialAccountBuilder WithTransfer(Transferred transfer)
        {
            Transfer = transfer;
            return this;
        }

        public Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount Build()
        => new Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount(Id,ARR, Unassigned, Critic, Transfer, StoreType);

    }
}
