using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Domain.Config.Enum
{
    public enum CardLabel
    {
        [EnumMember(Value = "Visa")]
        Visa = 1,

        [EnumMember(Value = "Mastercard")]
        Mastercard = 2,

        [EnumMember(Value = "Elo")]
        Elo = 3,

        [EnumMember(Value = "Diners")]
        Diners = 4,

        [EnumMember(Value = "HiperCard")]
        HiperCard = 5,

        [EnumMember(Value = "Amex")]
        Amex = 6
    }
}
