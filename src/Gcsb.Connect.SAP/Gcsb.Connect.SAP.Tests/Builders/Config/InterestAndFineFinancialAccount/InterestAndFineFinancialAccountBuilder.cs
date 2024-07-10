using Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.InterestAndFineFinancialAccount
{
    public class InterestAndFineFinancialAccountBuilder
    {
        public Guid Id;
        public StoreType Store;
        public Account Interest;
        public Account Fine;

        public static InterestAndFineFinancialAccountBuilder New()
        {
            return new InterestAndFineFinancialAccountBuilder
            {
                Id = Guid.NewGuid(),
                Interest = AccountBuilder.New().WithBilledCounterchargeChargeback("IBill").WithGrantedDebit("IGrantedD").Build(),
                Fine = AccountBuilder.New().WithFinancialAccount("987654321").WithBilledCounterchargeChargeback("FBill").WithGrantedDebit("FGrantedD").Build(),
                Store = StoreType.TBRA
            };
        }

        public InterestAndFineFinancialAccountBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public InterestAndFineFinancialAccountBuilder WithStore(StoreType store)
        {
            Store = store;
            return this;
        }

        public InterestAndFineFinancialAccountBuilder WithInterest(Account interest)
        {
            Interest = interest;
            return this;
        }

        public InterestAndFineFinancialAccountBuilder WithFine(Account fine)
        {
            Fine = fine;
            return this;
        }

        public Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount Build()
            => new Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount(Id, Store, Interest, Fine);
    }
}
