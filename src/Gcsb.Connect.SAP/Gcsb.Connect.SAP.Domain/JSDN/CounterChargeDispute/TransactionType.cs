using System.Runtime.Serialization;

namespace Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute
{
    public enum TransactionType
    {
        [EnumMember(Value = "Adjust Reversal")]
        AdjustReversal,

        [EnumMember(Value = "Billing")]
        Billing,

        [EnumMember(Value = "Adjustment")]
        Adjustment,

        [EnumMember(Value = "Payment")]
        Payment
    }
}
