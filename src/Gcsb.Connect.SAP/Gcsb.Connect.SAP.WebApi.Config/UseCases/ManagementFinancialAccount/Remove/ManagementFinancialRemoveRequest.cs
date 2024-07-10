using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Remove
{
    public sealed class ManagementFinancialRemoveRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
