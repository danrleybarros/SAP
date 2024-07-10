using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Pay;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class File
    {
        [Key]
        public Guid Id { get; private set; }

        public Guid? IdParent { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public DateTime InclusionDate { get; private set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public TypeRegister Type { get; private set; }

        public virtual List<Log> Logs { get; set; }

        public virtual List<Critical> Criticals { get; set; }

        public DateTime? CycleDate { get; private set; }
    }
}
