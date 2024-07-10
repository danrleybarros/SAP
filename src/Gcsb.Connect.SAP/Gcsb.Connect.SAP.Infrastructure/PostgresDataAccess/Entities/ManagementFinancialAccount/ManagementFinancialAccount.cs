using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.ManagementFinancialAccount
{
    public class ManagementFinancialAccount
    {
        public Guid Id { get; set; }
        [Required]
        public ARR ARR { get; set; }
        [Required]
        public Unassigned Unassigned { get; set; }
        [Required]
        public Critic Critic { get; set; }
        [Required]
        public Transfer Transfer { get; set; }    
        public StoreType StoreType { get; set; }
    }
}

