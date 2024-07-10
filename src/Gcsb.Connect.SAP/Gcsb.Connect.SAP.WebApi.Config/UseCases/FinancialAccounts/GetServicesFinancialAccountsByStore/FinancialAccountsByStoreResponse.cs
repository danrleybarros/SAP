using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccounts.GetServicesFinancialAccountsByStore
{
    public class FinancialAccountsByStoreResponse
    {
        public List<ServiceFinancialAccount> ServiceFinancialAccounts { get; set; }
    }

    public class ServiceFinancialAccount
    {
        public Guid Id { get; set; }
        
        public string StoreAcronym { get; set; }
        
        public string ServiceCode { get; set; }

        public string ServiceName { get; set; }

        public string StoreAcronymServiceProvider { get; set; }
       
    }
}
