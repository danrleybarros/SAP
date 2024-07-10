using Gcsb.Connect.SAP.Domain.AttributeValidation;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.PAS
{
    public class Header
    {
        private const string hd = @"HD";
        private const string empresaTBRA = @"TBRA";
        private const string empresaCloud = @"TLF2";
        private const string codLegado = @"GLWEB";
        private const string divisao = @"29SP";
        private const string formatDataArquivo = @"{0:yyyyMMdd}";
        private const string formatHoraNomeArquivo = @"{0:HHmmss}";
        private const string formatHoraArquivo = @"{0:HHmmss00}";        

        [Required]
        [MaxLength(2)]
        public string HD { get => hd; }
        [Required]
        [MaxLength(4)]
        public string Empresa { get => StoreType.Equals(StoreType.TBRA) ? empresaTBRA : empresaCloud; }
        [NotMapped]
        [RequireNonDefault]
        public DateTime GenerationDate { get; set; }
        [Required]
        [Format(formatDataArquivo)]
        public DateTime DataArquivo { get { return GenerationDate; } }
        [Required]
        [Format(formatHoraArquivo)]
        public DateTime HoraArquivo { get { return GenerationDate; } }
        [Required]
        [MaxLength(5)]
        public string CodLegado { get => codLegado; }
        [Required]
        [MaxLength(4)]
        public string Divisao { get => divisao; }

        [NotMapped]
        [Required]
        [Format(formatHoraNomeArquivo)]
        public DateTime HoraNomeArquivo { get { return GenerationDate; } }

        [NotMapped]
        public StoreType StoreType { get; set; }


        public Header(StoreType storeType)
        {
            StoreType = storeType;
            GenerationDate = DateTime.UtcNow;
        }

        public string GetFileName()
        {
            return StoreType switch
            {
                StoreType.TBRA => $"PAS_GLWEB_{Empresa}_{Divisao}_{string.Format(formatDataArquivo, DataArquivo)}_{string.Format(formatHoraNomeArquivo, HoraNomeArquivo)}.TXT",
                _ => $"PAS_GLWEB_{Empresa}_{Divisao}_{string.Format(formatDataArquivo, DataArquivo)}_{string.Format(formatHoraNomeArquivo, HoraNomeArquivo)}.TXT"

            };
        }
    }
}
