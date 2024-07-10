using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.FAT.FATBase
{
    public abstract class Launch : ILaunch
    {
        public const string linetype = "D1";
        public const string operatorcomplement = "GW";
        public const string businesslocationTBRA = "9141";
        public const string businesslocationCloudCO = "0001";
        public const string billingCycleDateFormat = "{0:yyyyMMdd}";
        public const string numberLineFormat = "{0:0000000000}";
        public const string lauchValueFormat = "{0,16:0.00}";
        public const string billingOption = "Pos";
        public const string typeIntercompany = "INT";
        public const string typeDeferral = "DIF";

        protected abstract string type { get; }
        protected abstract string lauchDateFormat { get; }
        protected abstract string billingCycleFormat { get; }

        [Required]
        [MaxLength(2)]
        public string LineType { get => linetype; }

        [Required]
        [Format(numberLineFormat)]
        [AttributeValidation.RequireNonDefault]
        public int NumberLine { get; set; }

        [Required]
        [NotMapped]
        public DateTime LaunchDate { get; set; }

        [Required]
        [MaxLength(8)]
        public string LaunchDateStr { get => LaunchDate.AddDays(1).ToString(lauchDateFormat); }

        [Required]
        [MaxLength(10)]
        public string Type { get => GetLaunchType(); }

        [Required]
        [MaxLength(15)]
        public string FinancialAccount { get; private set; }

        [MaxLength(2)]
        public string Complement { get; private set; }

        [Required]
        [RegularExpression(@"^\d{1,16}.\d{2}$")]
        [Format(lauchValueFormat)]
        public decimal LaunchValue { get; private set; }

        [MaxLength(15)]
        public string ISSCode { get; private set; }

        [RegularExpression(@"^\d{1,16}.\d{2}$")]
        [MaxLength(16)]
        public string ISSValue { get; private set; }

        [MaxLength(7)]
        public string Product { get; private set; }

        [MaxLength(2)]
        public string OperatorComplement { get => operatorcomplement; }

        [MaxLength(10)]
        public string CostCenter { get => HaveIntercompany && SType.Equals(StoreType.TLF2) ? string.Empty : GetCostCenter(SType); }

        [MaxLength(12)]
        public string InternalOrder { get; private set; }

        [MaxLength(12)]
        public string CostObject { get; private set; }

        [NotMapped]
        public DateTime BillingCycle { get; private set; }

        [Required]
        [MaxLength(10)]
        public string BillingCycleStr { get => billingCycleFormat; }

        [MaxLength(10)]
        public string TaxCostCenter { get; private set; }

        [RegularExpression(@"^\d{1,16}.\d{2}$")]
        [MaxLength(16)]
        public string NetValue { get; private set; }

        [MaxLength(4)]
        public string BusinessLocation { get => SType.Equals(StoreType.TBRA) ? businesslocationTBRA : businesslocationCloudCO; }

        [MaxLength(20)]
        public string PaymentMethod { get; private set; }

        [MaxLength(4)]
        public string BillingOption { get => HaveIntercompany && SType.Equals(StoreType.TLF2) ? string.Empty : billingOption; }

        [RegularExpression("^(D|C)$")]
        [MaxLength(2)]
        public string AccountingEntry { get; private set; }

        [MaxLength(10)]
        public string AccountingAccount { get; private set; }

        [MaxLength(2)]
        public string UF { get; private set; }

        [NotMapped]
        public StoreType SType { get; private set; }

        [NotMapped]
        public bool IsDiscount { get; private set; }

        [NotMapped]
        public bool HaveIntercompany { get; private set; }

        [NotMapped]
        public bool IsDeferral { get; private set; }

        public Launch(int numberline, DateTime launchdate, string financialaccount, string complement, decimal launchvalue, string isscode, string issvalue, string product, string internalorder,
            string uf, string costobject, DateTime billingcycle, string taxcostcenter, string netvalue, string paymentMethod, string accountingEntry, string accountingAccount, StoreType storeType,
            bool isDiscount)
        {
            this.NumberLine = numberline;
            this.LaunchDate = launchdate;
            this.FinancialAccount = financialaccount;
            this.Complement = complement;
            this.LaunchValue = launchvalue;
            this.ISSCode = isscode;
            this.ISSValue = issvalue;
            this.Product = product;
            this.InternalOrder = internalorder;
            this.UF = uf;
            this.CostObject = costobject;
            this.BillingCycle = billingcycle;
            this.TaxCostCenter = taxcostcenter;
            this.NetValue = netvalue;
            this.PaymentMethod = paymentMethod;
            this.AccountingEntry = accountingEntry;
            this.AccountingAccount = accountingAccount;
            this.SType = storeType;
            this.IsDiscount = isDiscount;
        }

        public Launch(int numberLine, DateTime launchDate, string financialAccount, decimal launchValue, string internalOrder, string uf, DateTime billingCycle, string paymentMethod, string accountingEntry, string accountingAccount, StoreType storeType, bool isDiscount)
        {
            this.NumberLine = numberLine;
            this.LaunchDate = launchDate;
            this.FinancialAccount = financialAccount;
            this.LaunchValue = launchValue;
            this.InternalOrder = internalOrder;
            this.UF = uf;
            this.BillingCycle = billingCycle;
            this.PaymentMethod = paymentMethod;
            this.AccountingEntry = accountingEntry;
            this.AccountingAccount = accountingAccount;
            this.SType = storeType;
            this.IsDiscount = isDiscount;
        }

        public Launch(int numberLine, DateTime launchDate, string financialAccount, decimal launchValue, string internalOrder, string uf, DateTime billingCycle, string paymentMethod, string accountingEntry, string accountingAccount, StoreType storeType, bool isDiscount, bool haveIntercompany,bool isDeferral)
        {
            this.NumberLine = numberLine;
            this.LaunchDate = launchDate;
            this.FinancialAccount = financialAccount;
            this.LaunchValue = launchValue;
            this.InternalOrder = internalOrder;
            this.UF = uf;
            this.BillingCycle = billingCycle;
            this.PaymentMethod = paymentMethod;
            this.AccountingEntry = accountingEntry;
            this.AccountingAccount = accountingAccount;
            this.SType = storeType;
            this.IsDiscount = isDiscount;
            this.HaveIntercompany = haveIntercompany;
            this.IsDeferral = isDeferral;
        }

        public string GetLaunchType()
        {
            if (IsDeferral)
                return $"{type}{typeDeferral}";
            else if (HaveIntercompany)
                return $"{type}{typeIntercompany}";
            else
                return type;
        }

        private string GetCostCenter(StoreType storeType)
            => storeType switch
            {
                StoreType.TLF2 => "29CR018200",
                StoreType.TBRA => "29TR018233",
                StoreType.IOTCo => "29ER018200",
                _ => ""
            };
    }
}
