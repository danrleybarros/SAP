using System;
using System.ComponentModel.DataAnnotations;


namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Pay
{
    public class Critical
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string BankCode { get; private set; }

        [Required]
        public decimal InvoiceAmount { get; private set; }

        [Required]
        public DateTime RegisterDate { get; private set; }

        [Required]
        public DateTime InclusionDate { get; private set; }

        public File File { get; set; }

        public Guid IdFile { get; set; }
    }
}
