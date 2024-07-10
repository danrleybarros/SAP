using System;
using Gcsb.Connect.SAP.Domain.Config.FinancialAccounts;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.FinancialAccounts
{
    public class AccountTypeBuilder
    {
        public Guid Id;
        public int Order;
        public string Type;
        public string Description;
        public static AccountTypeBuilder New()
        {
            return new AccountTypeBuilder()
            {
                Id = Guid.NewGuid(),
                Order = 0,
                Type = "Type 001",
                Description = "Description of Type 001"
            };
        }
        public AccountTypeBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }
        public AccountTypeBuilder WithOrder(int order)
        {
            Order = order;
            return this;
        }
        public AccountTypeBuilder WithType(string type)
        {
            Type = type;
            return this;
        }
        public AccountTypeBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }
        public AccountType Build()
            => new AccountType(Id, Order, Type, Description);
    }
}
