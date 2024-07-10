using System;
using System.Collections.Generic;
using System.Text;
using Gcsb.Connect.SAP.Domain.Config;

namespace Gcsb.Connect.SAP.Tests.Builders.Config
{
    public class AccountDetailsBuilder
    {

        public static AccountDetailsBuilder New()
        {
            return new AccountDetailsBuilder()
            {
                Id = Guid.NewGuid(),
                IdService = Guid.NewGuid(),
                IdInterface = Guid.NewGuid(),
                AccountType = "faturado",
                FinancialAccount = "FAT365",
                FinancialAccountDebit = "FAT365DEB",
                FinancialAccountCredit = "FAT365CRED"

            };
        }

        #region Properties
        public Guid Id { get; set; }
        public Guid IdService { get; set; }
        public Guid IdInterface { get; set; }
        public string AccountType { get; private set; }
        public string FinancialAccount { get; private set; }
        public string FinancialAccountDebit { get; private set; }
        public string FinancialAccountCredit { get; private set; }
        #endregion

        #region Methods
        public AccountDetailsBuilder WithIdService(Guid idService)
        {
            IdService = idService;
            return this;
        }

        public AccountDetailsBuilder WithIdInterface(Guid idInterface)
        {
            IdInterface = idInterface;
            return this;
        }

        public AccountDetailsBuilder WithAccountType(string accountType)
        {
            AccountType = accountType;
            return this;
        }

        public AccountDetailsBuilder WithFinancialAccount(string financialAccount)
        {
            FinancialAccount = financialAccount;
            return this;
        }
        public AccountDetailsBuilder WithIdFinancialAccountDeb(string financialAccountDeb)
        {
            FinancialAccountDebit = financialAccountDeb;
            return this;
        }
        public AccountDetailsBuilder WithIdFinancialAccountCred(string financialAccountCred)
        {
            FinancialAccountCredit = financialAccountCred;
            return this;
        } 
        #endregion

         public AccountDetails Build()
            => new AccountDetails(
                Id,
                IdService,
                IdInterface,
                AccountType,
                FinancialAccount,
                FinancialAccountDebit,
                FinancialAccountCredit
            );
    }
}
