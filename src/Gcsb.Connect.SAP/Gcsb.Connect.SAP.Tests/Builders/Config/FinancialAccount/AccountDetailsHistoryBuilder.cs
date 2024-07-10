using System;
using Gcsb.Connect.SAP.Domain.Config;

namespace Gcsb.Connect.SAP.Tests.Builders.Config
{
    public class AccountDetailsHistoryBuilder
    {

        public static AccountDetailsHistoryBuilder New()
        {
            return new AccountDetailsHistoryBuilder()
            {
                Id = Guid.NewGuid(),
                IdService = Guid.NewGuid(),
                IdInterface = Guid.NewGuid(),
                IdAccountType = Guid.NewGuid(),
                FinancialAccount = "FAT365",
                AccountDebit = "FAT365DEB",
                AccountCredit = "FAT365CRED",
                InclusionDate = DateTime.UtcNow,
                LastUpdate = DateTime.UtcNow,
                IsDeleted = false

            };
        }

        #region Properties
        public Guid Id { get; set; }
        public Guid IdService { get; set; }
        public Guid IdInterface { get; set; }
        public Guid IdAccountType { get; private set; }
        public string FinancialAccount { get; private set; }
        public string AccountDebit { get; private set; }
        public string AccountCredit{ get; private set; }
        public DateTime InclusionDate { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public bool IsDeleted { get; private set; }
        #endregion

        #region Methods
        public AccountDetailsHistoryBuilder WithIdService(Guid idService)
        {
            IdService = idService;
            return this;
        }

        public AccountDetailsHistoryBuilder WithIdInterface(Guid idInterface)
        {
            IdInterface = idInterface;
            return this;
        }

        public AccountDetailsHistoryBuilder WithIdAccountType(Guid idAccountType)
        {
            IdAccountType = idAccountType;
            return this;
        }

        public AccountDetailsHistoryBuilder WithFinancialAccount(string financialAccount)
        {
            FinancialAccount = financialAccount;
            return this;
        }
        public AccountDetailsHistoryBuilder WithAccountDebit(string accountDebit)
        {
            AccountDebit = accountDebit;
            return this;
        }
        public AccountDetailsHistoryBuilder WithAccountCredit(string accountCredit)
        {
            AccountCredit = accountCredit;
            return this;
        }

        public AccountDetailsHistoryBuilder WithInclusionDate(DateTime inclusionDate)
        {
            InclusionDate = inclusionDate;
            return this;
        }
        public AccountDetailsHistoryBuilder WithLastUpdate(DateTime lastUpdate)
        {
            LastUpdate = lastUpdate;
            return this;
        }
        public AccountDetailsHistoryBuilder WithIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
            return this;
        }
        #endregion

        public AccountDetailHistory Build()
           => new AccountDetailHistory(
               Id,
               IdService,
               IdInterface,
               IdAccountType,
               FinancialAccount,
               AccountDebit,
               AccountCredit,
               InclusionDate,
               LastUpdate,
               IsDeleted
           );
    }
}
