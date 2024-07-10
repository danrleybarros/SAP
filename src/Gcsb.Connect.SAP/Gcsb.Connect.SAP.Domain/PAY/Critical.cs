using Gcsb.Connect.Messaging.Messages.File;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.PAY
{
    public class Critical
    {
        public Guid Id { get; private set; }

        [Required]
        [MaxLength(3)]
        public string BankCode { get; private set; }

        [Required]
        [Range(0.0, Double.MaxValue)]
        public decimal InvoiceAmount { get; private set; }

        [Required]
        public DateTime RegisterDate { get; private set; }

        [Required]
        public DateTime InclusionDate { get; private set; }

        [Required]
        public Guid IdFile { get; private set; }

        public Critical(string bankCode, decimal launchValue, DateTime registerDate, DateTime includeDate, Guid idFile)
        {
            this.Id = Guid.NewGuid();
            this.BankCode = bankCode;
            this.InvoiceAmount = launchValue;
            this.RegisterDate = registerDate;
            this.InclusionDate = includeDate;
            this.IdFile = idFile;
        }

        protected Critical() { }

        public IList<ValidationResult> ValidateModel()
        {
            return Util.ValidateModel(this);
        }

        public void SetParendId(Guid idFile)
        {
            this.IdFile = idFile;
        }
    }
}
