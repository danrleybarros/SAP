using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.Config.FinancialAccounts
{
    public class Interface
    {

        [Required]
        public Guid Id { get; private set; }

        [Required]
        public string Type { get; private set; }

        [Required]
        public string Description { get; private set; }

        public Interface(Guid id, string type, string description)
        {
            Id = id;
            Type = type;
            Description = description;
        }
    }
}


