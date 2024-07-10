using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;

namespace Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount
{
    public class InterestAndFineFinancialAccount
    {
        public Guid Id { get; set; }
        public StoreType Store { get; set; }
        public Account Interest { get; private set; }
        public Account Fine { get; private set; }

        public InterestAndFineFinancialAccount(Guid id, StoreType store, Account interest, Account fine)
        {
            Id = id;
            Store = store;
            Interest = interest;
            Fine = fine;
        }
    }
}
