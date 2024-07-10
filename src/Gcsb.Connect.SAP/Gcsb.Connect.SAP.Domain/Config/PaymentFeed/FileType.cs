using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Domain.Config.PaymentFeed
{
    public enum FileType
    {
        [EnumMember(Value = "Credit")]
        Credit = 0,

        [EnumMember(Value = "Boleto")]
        Boleto = 1,
    }
}
