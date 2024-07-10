using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN
{

    public partial class ServiceBuilder : Builder<Gcsb.Connect.SAP.Domain.JSDN.Service>
    {
        public ServiceBuilder()
        {
            Defaults();
        }
        public System.String Code;
        public System.String Name;

        public ServiceBuilder WithCode(System.String code)
        {
            Code = code;
            return this;
        }
        public ServiceBuilder WithName(System.String name)
        {
            Name = name;
            return this;
        }

        public new void Defaults()
        {
            Code = "servicecode";
            Name = "servicename";
        }

        public new Gcsb.Connect.SAP.Domain.JSDN.Service Build()
        {
            return new Gcsb.Connect.SAP.Domain.JSDN.Service(
                                Code,
                                Name);
        }
    }
}
