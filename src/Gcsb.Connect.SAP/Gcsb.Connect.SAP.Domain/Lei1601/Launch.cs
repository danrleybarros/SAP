using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gcsb.Connect.SAP.Domain.Lei1601;

namespace Gcsb.Connect.SAP.Domain.LEI1601
{
    public class Launch
    {
        private const string CATG_CODE = "CL";
        private const string CATG_CODE_IT = "";
        private const string CADG_CODE_IT = "";
        private const string OIPE_TOT_VS = "";
        private const string OIPE_TOT_OUTROS = "";
        private const string SISTEMA_ORIGEM = "PLATAFORMA DIGITAL";

        [Required]
        [MaxLength(4)]
        public string EmpsCod { get; private set; }

        [Required]
        [MaxLength(4)]
        [NotMapped]
        public string FiliCod { get; private set; }

        [Required]
        [MaxLength(4)]
        public string StrFiliCod { get => FiliCod.PadLeft(4, '0'); }

        [Required]
        [MaxLength(8)]
        public string StrOipeDataOper { get => OipeDataOper == null ? DateTime.Now.ToString("ddMMyyyy") : OipeDataOper.Value.ToString("ddMMyyyy"); }

        [Required]
        [NotMapped]
        public DateTime? OipeDataOper { get; private set; }

        [Required]
        [MaxLength(2)]
        public string CatgCode { get => CATG_CODE; }

        [MaxLength(10)]
        public string EmptySpaceCadgCod { get; private set; }

        [NotMapped]
        [Required]
        [MaxLength(10)]
        public string CadgCod { get; private set; }

        [Required]
        [MaxLength(10)]
        public string StgCadgCod { get => CadgCod?.PadLeft(10, '0'); }

        [MaxLength(9)]
        public string CatgCodIt { get => CATG_CODE_IT; }

        [MaxLength(9)]
        public string CadgCodIt { get => CADG_CODE_IT; }

        [MaxLength(17)]
        public string OipeTotVs { get => OIPE_TOT_VS; }

        [Required]
        [MaxLength(17)]
        public string StrOipeTotIss { get => OipeTotIss.ToString().Replace(".", String.Empty).PadLeft(17, '0'); }

        [Required]
        [NotMapped]
        public decimal? OipeTotIss { get; private set; }

        [MaxLength(17)]
        public string OipeTotOutros { get => OIPE_TOT_OUTROS; }

        [Required]
        [MaxLength(60)]
        public string StrBancoOrigPgto { get => BancoOrigPgto.PadRight(60); }

        [Required]
        [MaxLength(60)]
        [NotMapped]
        public string BancoOrigPgto { get; private set; }

        [Required]
        [MaxLength(30)]
        public string SistemaOrigem { get => SISTEMA_ORIGEM; }

        [NotMapped]
        public Guid FileId { get; set; }

        [NotMapped]
        public int BankCode { get; set; }

        [NotMapped]
        public PaymentMethod PaymentMethod { get; set; }

        public Launch(Guid fileId, string empsCod, string filiCod, DateTime? oipeDataOper, decimal? oipeTotIss, string bancoOrigPgto, PaymentMethod paymentMethod, int bankCode)
        {
            FileId = fileId;
            EmpsCod = empsCod;
            FiliCod = filiCod;
            OipeDataOper = oipeDataOper;
            OipeTotIss = oipeTotIss;
            BancoOrigPgto = bancoOrigPgto;
            PaymentMethod = paymentMethod;
            BankCode = bankCode;
        }

        public Launch(Guid fileId, string empsCod, string filiCod, DateTime? oipeDataOper, decimal? oipeTotIss, string bancoOrigPgto, PaymentMethod paymentMethod, string acquirerEntity)
        {
            FileId = fileId;
            EmpsCod = empsCod;
            FiliCod = filiCod;
            OipeDataOper = oipeDataOper;
            OipeTotIss = oipeTotIss;
            BancoOrigPgto = bancoOrigPgto;
            PaymentMethod = paymentMethod;

            CadgCod = acquirerEntity switch
            {
                "P002" => "0003341459",
                "P01" => "0003341459",
                "P02" => "0003341459",
                "P03" => "0003341459",
                "P04" => "0003341459",
                "P05" => "0003341459",
                _ => "0000000000"
            };
        }

        public void SetParticipantCode(string participantCode)
            => CadgCod = participantCode.PadLeft(10, '0');
    }
}
