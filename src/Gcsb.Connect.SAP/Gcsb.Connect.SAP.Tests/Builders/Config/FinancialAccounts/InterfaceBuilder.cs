using System;
using Gcsb.Connect.SAP.Domain.Config.FinancialAccounts;

namespace Gcsb.Connect.SAP.Tests.Builders.Config.FinancialAccounts
{ 
    public class InterfaceBuilder
    {
        public Guid Id;
        public string Type;
        public string Description;

        public static InterfaceBuilder New()
        {
            return new InterfaceBuilder()
            {
                Id = Guid.NewGuid(),
                Type = "Interface Faturar",
                Description = "Faturar"
            };
        }

        public InterfaceBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public InterfaceBuilder WithType(string type)
        {
            Type = type;
            return this;
        }

        public InterfaceBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public Interface Build()
        {
            return new Interface(Id, Type, Description);
        }
    }
}
