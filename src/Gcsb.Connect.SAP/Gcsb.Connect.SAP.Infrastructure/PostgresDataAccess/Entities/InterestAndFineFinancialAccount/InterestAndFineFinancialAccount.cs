using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.InterestAndFineFinancialAccount
{
    public class InterestAndFineFinancialAccount
    {
        public Guid Id { get; set; }
        public StoreType Store { get; set; }
        public Account Interest { get; set; }
        public Account Fine { get; set; }
    }
}
