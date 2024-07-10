using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.LEI1601
{
    public class IdentificationRegister
    {
        private const string INIT = "GW_SI_1601";
        private const string EXTENSION = ".TXT";
        private const string SEQUENCE_FORMAT = "{0:000}";

        public string FileName
        {
            get
            {
                return GetFileName();
            }
        }

        [Required]
        [NotMapped]
        [Range(1, 999)]
        public int Sequence { get; private set; }

        [Required]
        [NotMapped]
        public DateTime ReferenceDate { get; private set; }

        [Required]
        [MaxLength(8)]
        public string Reference
        {
            get
            {
                return ReferenceDate.ToString("yyyyMMdd");
            }
        }

        [Required]
        [NotMapped]
        public DateTime ProcessDate { get; private set; }

        [Required]
        [MaxLength(8)]
        public string Process
        {
            get
            {
                return ProcessDate.ToString("yyyyMMdd");
            }
        }

        public IdentificationRegister(DateTime refDate, DateTime processDate, int sequential)
        {
            ReferenceDate = refDate;
            ProcessDate = processDate;
            Sequence = sequential;
        }

        private string GetFileName()
        {
            return $"{INIT}_{Reference}_{Process}_INST_{string.Format(SEQUENCE_FORMAT, Sequence)}{EXTENSION}";
        }
    }
}
