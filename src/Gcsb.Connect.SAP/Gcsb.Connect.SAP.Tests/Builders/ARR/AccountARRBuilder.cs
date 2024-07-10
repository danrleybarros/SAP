using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Tests.Builders.ARR
{
    public class AccountARRBuilder
    {
        public string InvoiceNumber;
        public string ServiceCode;
        public string ArrecadacaoARR;
        public string AccountingEntryType;
        public string AccountingAccount;
        public StoreType Store;
        public StoreType Provider;
        public bool HaveIntercompany;
        public bool ValidAccount;

        public static AccountARRBuilder New()
        {
            return new AccountARRBuilder() 
            {
                InvoiceNumber = "InvoiceTest",
                ServiceCode = "ServiceCodeTest",
                ArrecadacaoARR = "accountCredit",
                AccountingEntryType = "C",
                AccountingAccount = "12345",
                Store = StoreType.TBRA,
                Provider = StoreType.TBRA,
                HaveIntercompany = false,
                ValidAccount = true
            };
        }

        public AccountARRBuilder WithInvoiceNumber(string invoiceNumber)
        {
            InvoiceNumber = invoiceNumber;
            return this;
        }

        public AccountARRBuilder WithServiceCode(string serviceCode)
        {
            ServiceCode = serviceCode;
            return this;
        }

        public AccountARRBuilder WithArrecadacaoARR(string arrecadacaoARR)
        {
            ArrecadacaoARR = arrecadacaoARR;
            return this;
        }

        public AccountARRBuilder WithAccountingEntryType(string accountingEntryType)
        {
            AccountingEntryType = accountingEntryType;
            return this;
        }

        public AccountARRBuilder WithAccountingAccount(string accountingAccount)
        {
            AccountingAccount = accountingAccount;
            return this;
        }

        public AccountARRBuilder WithStore(StoreType store)
        {
            Store = store;
            return this;
        }

        public AccountARRBuilder WithProvider(StoreType provider)
        {
            Provider = provider;
            return this;
        }

        public AccountARRBuilder WithHaveIntercompany(bool haveIntercompany)
        {
            HaveIntercompany = haveIntercompany;
            return this;
        }

        public AccountARRBuilder WithValidAccount(bool validAccount)
        {
            ValidAccount = validAccount;
            return this;
        }

        public AccountARR Build()
            => new AccountARR(InvoiceNumber, ServiceCode, ArrecadacaoARR, AccountingEntryType, AccountingAccount, Store, Provider, HaveIntercompany, ValidAccount);
    }
}
