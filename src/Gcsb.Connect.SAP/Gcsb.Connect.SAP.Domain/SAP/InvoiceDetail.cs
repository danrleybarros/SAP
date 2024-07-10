using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain
{
    public class InvoiceDetail
    {
        private const string formatDateTimeSAP = "ddMMyyyy";
        public const string orderItem = "D3";
        public string OrderItem { get => orderItem; }

        [Required]
        [MaxLength(18)]
        public string MaterialCode { get; private set; }

        [Required]
        [Range(1, 99999)]
        public int Amount { get; private set; }

        [Required]
        [RegularExpression(@"^\d{1,13}.\d{2}$")]
        public decimal VendorPrice { get; private set; }

        [RegularExpression(@"^\d{1,13}.\d{2}$")]
        public decimal? PISTax { get; private set; }

        [RegularExpression(@"^\d{1,13}.\d{2}$")]
        public decimal? COFINSTax { get; private set; }

        [RegularExpression(@"^\d{1,13}.\d{2}$")]
        public decimal? ISSTax { get; private set; }

        [Required]
        [RegularExpression(@"^\d{1,13}.\d{2}$")]
        public decimal ICMSTax { get; private set; }

        [RegularExpression(@"^\d{1,13}.\d{2}$")]
        public decimal? Chargeback { get; private set; }

        public DateTime? ActivationDate { get; private set; }

        public DateTime? DateOfInactivation { get; private set; }

        [Range(1, 99999999)]
        public int? Origin { get; private set; }

        public InvoiceDetail(string materialCode, int amount, decimal vendorPrice, decimal? pistax, decimal? cofinstax, decimal? isstax, decimal icmstax, decimal? chargeback, DateTime? activationDate, DateTime? dateOfInactivation, int? origin)
        {
            this.MaterialCode = materialCode;
            this.Amount = amount;
            this.VendorPrice = vendorPrice;
            this.PISTax = pistax;
            this.COFINSTax = cofinstax;
            this.ISSTax = isstax;
            this.ICMSTax = icmstax;
            this.Chargeback = chargeback;
            this.ActivationDate = activationDate;
            this.DateOfInactivation = dateOfInactivation;
            this.Origin = origin;
        }

        public string ActivationDateSAP()
        {
            if (ActivationDate == null)
                return "";            
            return ((DateTime)this.ActivationDate).ToString(formatDateTimeSAP);
        }

        public string DateOfInactivationSAP()
        {
            if (ActivationDate == null)
                return "";
            return ((DateTime)this.DateOfInactivation).ToString(formatDateTimeSAP);
        }
    }
}
