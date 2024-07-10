using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.FAT.IFAT
{
    public interface ILaunch
    {
        string LineType { get; }
        int NumberLine { get; set; }
        DateTime LaunchDate { get; set; }
        string LaunchDateStr { get; }
        string Type { get; }
        string FinancialAccount { get; }
        string Complement { get; }
        decimal LaunchValue { get; }
        string ISSCode { get; }
        string ISSValue { get; }
        string Product { get; }
        string OperatorComplement { get; }
        string CostCenter { get; }
        string InternalOrder { get; }
        string UF { get; }
        string CostObject { get; }
        DateTime BillingCycle { get; }
        string BillingCycleStr { get; }
        string TaxCostCenter { get; }
        string NetValue { get; }
        string BusinessLocation { get; }
        string PaymentMethod { get; }
        string BillingOption { get; }
        string AccountingEntry { get; }
        string AccountingAccount { get; }
        bool IsDiscount{ get; }
    }
}
