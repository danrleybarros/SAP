using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.GetById
{
    public sealed class FinancialAccountGetbyIdRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
