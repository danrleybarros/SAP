using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.ARR
{
    public abstract class IdentificationRegister
    {
        protected abstract string typeLine { get; }
        protected abstract string systemCode { get; }
        protected abstract string fileCode { get; }
        protected abstract string companyCode { get; }
        protected abstract string divisionCode { get; }
        protected abstract string extension { get; }

        [Required]
        [MaxLength(2)]
        public string TypeLine { get => typeLine; }

        [Required]
        [MaxLength(20)]
        public string FileName
        {
            get
            {
                return GetFileName();
            }
        }
                
        [Required]
        [NotMapped]
        public DateTime DateGeneration { get; private set; }

        [Required]
        [NotMapped]
        public int Sequence { get; private set; }

        [Required]
        [MaxLength(6)]
        public string GenerationDate
        {
            get
            {
                return this.DateGeneration.ToString("ddMMyyyy");
            }
        }

        [Required]
        [MaxLength(6)]
        public string GenerationHour
        {
            get
            {
                return this.DateGeneration.ToString("HHmmss");
            }
        }

        [Required]
        [MaxLength(2)]
        [NotMapped]
        public string GenerationYear
        {
            get
            {
                return this.DateGeneration.ToString("yy");
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public IdentificationRegister(int sequential)
        {
            this.DateGeneration = DateTime.UtcNow;
            this.Sequence = sequential;
        }

        protected virtual string GetFileName()
            => $"{systemCode}{fileCode}{companyCode}{divisionCode}{this.GenerationYear}{extension}";
    }
}
