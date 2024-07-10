using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;

namespace Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount
{
    public class AccountDetailsByServiceDto
    {
        public List<Service> Services { get; set; }
    }

    public class Service
    {
        public string StoreAcronym { get; set; }
        public string ServiceCode { get; set; }
        public string ProviderCompanyAcronym { get; set; }
        public AccountDetail AccountDetail { get; set; }
    }

    public class AccountDetail
    {
        public List<Account> Store { get; set; }
        public List<Account> Intercompany { get; set; }
    }

    public class Account
    {
        public string InterfaceType { get; set; }
        public string AccountType { get; set; }
        public string FinancialAccount { get; set; }
        public string FinancialAccountDeb { get; set; }
        public string FinancialAccountCred { get; set; }

        public string GetAccountingAccountByType(AccountingEntryType type)
            => type == AccountingEntryType.Credit ? FinancialAccountCred : FinancialAccountDeb;
    }
}
