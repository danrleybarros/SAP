using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.Config.FinancialAccounts
{
    public class AccountType
    {
        public Guid Id { get; private set; }
        [Required]
        public int Order { get; private set; }
        [Required]
        public string Type { get; private set; }
        [Required]
        public string Description { get; private set; }

        public AccountType(Guid id, int order, string type, string description)
        {
            Id = id;
            Order = order;
            Type = type;
            Description = description;
        }
        public AccountType()
        {
            Id = Guid.NewGuid();
        }
    }
}
