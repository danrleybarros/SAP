using System;
using Gcsb.Connect.SAP.Domain.JSDN;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN
{

    public partial class ServiceFinancialAccountBuilder : Builder<ServiceFinnancialAccount>
    {
        public ServiceFinancialAccountBuilder()
        {
            Defaults();
        }
        public System.Guid Id;
        public System.String Store;
        public System.String ServiceCode;
        public System.String ServiceName;
        public System.String ProviderCompany;

        public ServiceFinancialAccountBuilder WithId(System.Guid id)
        {
            Id = id;
            return this;
        }
        public ServiceFinancialAccountBuilder WithStore(System.String store)
        {
            Store = store;
            return this;
        }

        public ServiceFinancialAccountBuilder WithServiceCode(System.String servicecode)
        {
            ServiceCode = servicecode;
            return this;
        }
        public ServiceFinancialAccountBuilder WithName(System.String servicename)
        {
            ServiceName = servicename;
            return this;
        }
        public ServiceFinancialAccountBuilder WithProviderCompany(System.String providercompany)
        {
            ProviderCompany = providercompany;
            return this;
        }

        public new void Defaults()
        {
            Id = Guid.NewGuid();
            Store = "servicestore";
            ServiceCode = "servicecode";
            ServiceName = "servicename";
            ProviderCompany = "serviceprovidercompany";

        }

        public new Gcsb.Connect.SAP.Domain.JSDN.ServiceFinnancialAccount Build()
        {
            return new Gcsb.Connect.SAP.Domain.JSDN.ServiceFinnancialAccount(
                                Guid.NewGuid(),
                                Store,
                                ServiceCode,
                                ServiceName,
                                ProviderCompany);
        }
    }
}
