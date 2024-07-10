using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.Remove
{
    public class InterestAndFineFinancialAccountRemoveRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
