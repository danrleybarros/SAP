using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.ARR
{
    public class LaunchItem
    {
        public const string typeLine = "D1";
        public const string numberLineFormat = "{0:0000000000}";
        public const string lauchValueFormat = "{0,16:0.00}";
        public const string lauchDateFormat = "{0:ddMMyyyy}";

        [Required]
        [MaxLength(2)]
        public string TypeLine { get => typeLine; }

        [Required]
        [Format(numberLineFormat)]
        public int? LineNumber { get; set; }

        [Required]
        [Format(lauchDateFormat)]
        public DateTime LaunchDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string Type { get; set; }

        [Required]
        [MaxLength(15)]
        public string FinancialAccount { get; set; }

        [MaxLength(2)]
        public string Complement { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue)]
        [RegularExpression(@"^\d{1,16}.\d{2}$")]
        [Format(lauchValueFormat)]
        public decimal LaunchValue { get; set; }

        [MaxLength(10)]
        public string SecondComplement { get; set; }

        [RegularExpression(@"^(D|C)\s?$")]
        [MaxLength(2)]
        public string AccountingEntry { get; private set; }

        [RegularExpression(@"^[0-9\sa-zA-Z]*$")]
        [MaxLength(10)]
        public string AccountingAccount { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="typeLine"></param>
        public LaunchItem(
            int? lineNumber, 
            DateTime launchDate, 
            string financialAccount, 
            decimal launchValue, 
            string secondComplement, 
            string type, 
            string complement, 
            string accountingEntry, 
            string accountingAccount)
        {
            this.LineNumber = lineNumber;
            this.LaunchDate = launchDate;
            this.FinancialAccount = financialAccount;
            this.LaunchValue = launchValue;
            this.SecondComplement = secondComplement;
            this.Type = type;
            this.Complement = complement;
            this.AccountingEntry = accountingEntry;
            this.AccountingAccount = accountingAccount;           
        }
    }
}
