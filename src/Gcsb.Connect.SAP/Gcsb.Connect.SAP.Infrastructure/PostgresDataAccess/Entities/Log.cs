//using Gcsb.Connect.SAP.Domain.Log.Enum;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class Log
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Service { get; private set; }

        public Guid? FileId { get; private set; }

        [MaxLength(200)]
        public string UserId { get; private set; }

        [Required]
        [MaxLength(200)]
        public string Message { get; private set; }

        public List<LogDetail> LogDetails { get; private set; }

        [Required]
        public DateTime DateLog { get; private set; }

        [Required]
        public TypeLog TypeLog { get; private set; }

        [MaxLength(2000)]
        public string StackTrace { get; private set; }       
    }
}
