using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccounts.GetServicesFinancialAccountsByStore
{
    public class FinancialAccountsByStoreInput
    {
        [Required]
        public string StoreAcronym { get; set; }
    }
}
