using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount
{
    public class ManagementFinancialAccount
    {
        public Guid Id { get; set; }

        [Required]
        public ARR ARR { get; private set; }

        [Required]
        public Unassigned Unassigned { get; set; }

        [Required]
        public Critic Critic { get; private set; }

        [Required]
        public Transferred Transfer { get; private set; }

        [Required]
        public StoreType StoreType { get; private set; }        

        public ManagementFinancialAccount(Guid id,ARR aRR, Unassigned unassigned, Critic critic, Transferred transfer, StoreType storeType)
        {
            Id = id;
            ARR = aRR;
            Unassigned = unassigned;
            Critic = critic;
            Transfer = transfer;
            StoreType = storeType;
        }
    }
}

