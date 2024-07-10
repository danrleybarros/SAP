using System.Runtime.Serialization;


namespace Gcsb.Connect.SAP.Domain.AJU
{
    public enum TypeAccounting
    {
        [EnumMember(Value = "D")]
        Debito,

        [EnumMember(Value = "C")]
        Credito
    }
}
