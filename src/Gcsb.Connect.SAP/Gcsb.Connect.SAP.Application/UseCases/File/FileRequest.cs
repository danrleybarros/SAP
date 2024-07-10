using System;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{ 
    public class FileRequest
    {
        public int? CycleMonth { get; private set; }
        public int? CycleYear { get; private set; }
        public DateTime? PaymentDateIni { get; private set; }
        public DateTime? PaymentDateEnd { get; private set; }
        public DateTime? GenerationDateIni { get; private set; }
        public DateTime? GenerationDateEnd { get; private set; }

        public Connect.Messaging.Messages.File.Enum.Status? Status { get; private set; }
        public Connect.Messaging.Messages.File.Enum.TypeRegister InterfaceType { get; private set; }

        public int Page { get; set; }
        public int QuantityItemsPage { get; set; }
        public int OrderBy { get; set; }
        public string SortBy { get; set; }


        public FileRequest(Connect.Messaging.Messages.File.Enum.TypeRegister interfaceType, int? cycleMonth, int? cycleYear, DateTime? paymentDateIni, DateTime? paymentDateEnd, DateTime? generationDateIni, DateTime? generationDateEnd, Connect.Messaging.Messages.File.Enum.Status? status)
        {
            this.InterfaceType = interfaceType;
            this.CycleMonth = cycleMonth;
            this.CycleYear = cycleYear;
            this.PaymentDateIni = paymentDateIni;
            this.PaymentDateEnd = paymentDateEnd;
            this.GenerationDateIni = generationDateIni;
            this.GenerationDateEnd = generationDateEnd;
            this.Status = status;
            this.OrderBy = 0;
            this.SortBy = string.Empty;

        }       
    }
}
