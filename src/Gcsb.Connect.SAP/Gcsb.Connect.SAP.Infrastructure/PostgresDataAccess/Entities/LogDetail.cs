using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class LogDetail
    {
        [Required]
        public Guid Id { get; private set; }

        [MaxLength(20)]
        public string Line { get; private set; }

        [Required]
        [MaxLength(2000)]
        public string Message { get; private set; }
        
    }
}
