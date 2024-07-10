using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Domain.Config.Enum
{
    public enum DocumentType
    {
        [EnumMember(Value = "CPF")]
        CPF = 1,

        [EnumMember(Value = "CNPJ")]
        CNPJ = 2
    }
}
