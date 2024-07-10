using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.GF
{
    public class IndividualReportService
    {
        private const string serviceType = "S";
        private const string revenueTypeIndicator = "P";
        private const string digitalPlatform = "Vivo Plataforma Digital";
        private const string updateDataServiceFormat = "{0:yyyyMMdd}";
        private const string serviceName = "Processamento,armaz. ou hosped. de dados, textos, imagens, videos, paginas eletronicas, apps e sist. de info., entre outros formatos e congeneres";
        private const string serviceCode = "1.03";
        private const string cslcCodLst = "1.03";

        [Required]
        [MaxLength(60)]
        [GF("SERV_COD")]
        public string ServiceCode { get => serviceCode; }

        [Required]
        [Format(updateDataServiceFormat)]
        [GF("SERV_DAT_ATUA")]
        public DateTime UpdateDataService { get; private set; }

        [Required]
        [MaxLength(150)]
        [GF("SERV_DSC")]
        public string ServiceName { get => serviceName; }

        [Required]
        [MaxLength(1)]
        [GF("SERV_TP_SERV")]
        public string ServiceType { get => serviceType; }

        [Required]
        [MaxLength(1)]
        [GF("SERV_IND_REC")]
        public string RevenueTypeIndicator { get => revenueTypeIndicator; }

        [Required]
        [MaxLength(150)]
        [GF("VAR05")]
        public string DigitalPlatform { get => digitalPlatform; }

        [Required]
        [MaxLength(5)]
        [GF("CSLC_COD_LST")]
        public string CslcCodLst { get => cslcCodLst; }

        public IndividualReportService(DateTime updateDataService)
        {
            this.UpdateDataService = updateDataService;
        }

        public IList<ValidationResult> ValidateModel()
        {
            return Util.ValidateModel(this);
        }
    }
}
