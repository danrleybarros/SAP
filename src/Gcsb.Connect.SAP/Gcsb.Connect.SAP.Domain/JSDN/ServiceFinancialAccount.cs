using System;
using System.ComponentModel.DataAnnotations;


namespace Gcsb.Connect.SAP.Domain.JSDN
{
    public class ServiceFinnancialAccount
    {
        public Guid Id { get; private set; }

        [Required]
        public string Store { get; private set; }

        [Required]
        public string ServiceCode { get; private set; }

        public string ServiceName { get; private set; }

        [Required]
        public string ProviderCompany { get; private set; }

        public ServiceFinnancialAccount(Guid id, string store, string serviceCode, string serviceName, string providerCompany)
        {
            Id = id;
            Store = store;
            ServiceCode = serviceCode;
            ServiceName = serviceName;
            ProviderCompany = providerCompany;
        }

    }
}
