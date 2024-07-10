using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class CreditGrantedFinancialAccount 
    {
        public Guid Id { get; private set; }
        public StoreType StoreAcronym { get; private set; }
        public string CreditGrantedAJU { get; private set; }
        public string AccountingAccountDeb { get; private set; }
        public string AccountingAccountCred { get; private set; }
    }
}
