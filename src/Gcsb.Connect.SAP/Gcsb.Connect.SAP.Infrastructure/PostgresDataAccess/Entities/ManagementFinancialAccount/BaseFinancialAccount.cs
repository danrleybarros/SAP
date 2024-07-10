
namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.ManagementFinancialAccount
{
    public abstract class BaseFinancialAccount
    {
        public string FinancialAccount { get; set; }
        public AccountingAccount AccountingAccount { get; set; }
    }
}
