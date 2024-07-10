using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions
{
    public enum TypeSearch
    {
        [EnumMember(Value = "CustomerCode")]
        CustomerCode = 1,

        [EnumMember(Value = "CustomerName")]
        CustomerName = 2,

        [EnumMember(Value = "Cnpj")]
        Cnpj = 3,
    }
}
