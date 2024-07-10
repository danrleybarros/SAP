using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Domain.JSDN.Stores
{
    public enum StoreType
    {
        [EnumMember(Value = "others")]
        Others,

        [EnumMember(Value = "telerese")]
        TBRA,

        [EnumMember(Value = "CloudCo")]
        TLF2,

        [EnumMember(Value = "IOTCo")]
        IOTCo
    }
}
