using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.AJU
{
    public class Launch 
    {
        private const string launchDay = "21";
        private const string launchDayIOT = "01";
        private const string dateFormat = "{0:MMyyyy}";
        private const string cycleDateFormat = "{0:yyyyMMdd}";
        private const string type = "CONT";
        private const string lauchValueFormat = "{0,16:0.00}";
        private const string cycleNumber = "01";
        private const string typeLine = "D1";
        public const string numberLineFormat = "{0:0000000000}";
        public const string operatorcomplement = "GW";        
        public const string billingOption = "Pos";
        public const string typeIntercompany = "INT";

        [Required]
        [MaxLength(2)]
        public string TypeLine { get => typeLine; }

        [Required]
        [Format(numberLineFormat)]
        public int LineNumber { get; set; }
      
        [NotMapped]
        public DateTime LaunchDate { get; private set; }

        [Required]
        [MaxLength(8)]
        public string LaunchDateStr { get => $"{ (SType.Equals(StoreType.IOTCo) ? launchDayIOT : launchDay) }{string.Format(dateFormat,LaunchDate.AddMonths(1))}"; }

        [Required]
        [MaxLength(10)]        
        public string Type { get => HaveIntercompany ? type + typeIntercompany : type; }

        [Required]
        [MaxLength(15)]
        public string FinancialAccount { get; private set; }

        [MaxLength(2)]
        public string Complement { get; private set; }

        [Required]
        [Format(lauchValueFormat)]
        public decimal LaunchValue { get; private set; }       

        [MaxLength(15)]
        public string CodeISS { get; private set; }

        [MaxLength(16)]
        public string ValueISS { get; private set; }

        [MaxLength(7)]
        public string Product { get; private set; }

        [MaxLength(2)]
        public string OperatorComplement { get => operatorcomplement; }

        [Required]
        [MaxLength(10)]        
        public string CostCenter { get => HaveIntercompany && SType.Equals(StoreType.TLF2) ? string.Empty : GetCostCenter(SType); }

        [MaxLength(12)]
        public string InternalOrder { get; private set; }

        [MaxLength(12)]
        public string CostObject { get; }

        [NotMapped]
        [Format(cycleDateFormat)]
        public DateTime BillingCycle { get; private set; }

        [NotMapped]
        public string CycleNumber { get => cycleNumber; }

        [Required]
        [MaxLength(10)]
        public string BillingCycleStr { get => $"{CycleNumber}{string.Format(cycleDateFormat, BillingCycle)}"; }

        [MaxLength(10)]
        public string TaxCostCenter { get; private set; }

        [MaxLength(16)]
        public string LiquidValue { get; private set; }

        [MaxLength(4)]
        public string BusinessLocation { get => SType.Equals(StoreType.TBRA) ? "9141" :  "0001"; }

        [MaxLength(20)]
        public string PaymentMethod { get; private set; } 

        [MaxLength(4)]        
        public string BillingOption { get => HaveIntercompany && SType.Equals(StoreType.TLF2) ? string.Empty : billingOption; }

        [Required]
        [MaxLength(2)]
        [RegularExpression(@"^(D|C)$", ErrorMessage = "The name must be equals C or D")]
        public string TypeLaunchAccounting { get ; private set; }

        [Required]
        [MaxLength(10)]
        public string AccountingAccount { get; private set; }

        [MaxLength(2)]
        public string UF { get; private set; }

        [NotMapped]
        public StoreType SType { get; private set; }

        [NotMapped]
        public bool HaveIntercompany { get; private set; }

        public Launch(int lineNumber, DateTime launchDate, string financialAccount,string complement, decimal launchValue, string codeISS, string valueISS, string product, string internalOrder, 
                      string costObject, DateTime billingCycle, string taxCostCenter, string liquidValue, string uf, string paymentMethod,string typeLaunchAccounting, string accountingAccount, StoreType storeType)
        {
            this.LineNumber = lineNumber;
            this.LaunchDate = launchDate;
            this.FinancialAccount = financialAccount;
            this.Complement = complement;
            this.LaunchValue = launchValue;
            this.CodeISS = codeISS;
            this.ValueISS = valueISS;          
            this.Product = product;
            this.InternalOrder = internalOrder;
            this.UF = uf;
            this.CostObject = costObject;
            this.BillingCycle = billingCycle;            
            this.PaymentMethod = paymentMethod;
            this.TypeLaunchAccounting = typeLaunchAccounting;
            this.AccountingAccount = accountingAccount;
            this.SType = storeType;
        }

        public Launch(int lineNumber, DateTime launchDate, string financialAccount, decimal launchValue,  string internalOrder,
                   DateTime billingCycle, string uf, string paymentMethod, string typeLaunchAccounting, string accountingAccount, StoreType storeType)
        {
            this.LineNumber = lineNumber;
            this.LaunchDate = launchDate;
            this.FinancialAccount = financialAccount;          
            this.LaunchValue = launchValue;          
            this.InternalOrder = internalOrder;
            this.UF = uf;
            this.BillingCycle = billingCycle;
            this.PaymentMethod = paymentMethod;
            this.TypeLaunchAccounting = typeLaunchAccounting;
            this.AccountingAccount = accountingAccount;
            this.SType = storeType;
        }

        public Launch(int lineNumber, DateTime launchDate, string financialAccount, decimal launchValue, string internalOrder,
           DateTime billingCycle, string uf, string paymentMethod, string typeLaunchAccounting, string accountingAccount, 
           StoreType storeType, bool haveIntercompany)
        {
            this.LineNumber = lineNumber;
            this.LaunchDate = launchDate;
            this.FinancialAccount = financialAccount;
            this.LaunchValue = launchValue;
            this.InternalOrder = internalOrder;
            this.UF = uf;
            this.BillingCycle = billingCycle;
            this.PaymentMethod = paymentMethod;
            this.TypeLaunchAccounting = typeLaunchAccounting;
            this.AccountingAccount = accountingAccount;
            this.SType = storeType;
            this.HaveIntercompany = haveIntercompany;
        }

        private string GetCostCenter(StoreType storeType)
        {
            return storeType switch
            {
                StoreType.TLF2 => "29CR018200",
                StoreType.TBRA => "29TR018233", 
                StoreType.IOTCo => "29ER018200",
                _ => ""
            };
        }
    }
}
