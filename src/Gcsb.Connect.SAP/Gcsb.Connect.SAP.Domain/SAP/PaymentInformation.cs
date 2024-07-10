using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain
{
    public class PaymentInformation
    {
        private const string formatDateTimeSAP = "ddMMyyyy";
        private const string orderCab = "D2";

        public string OrderCab { get => orderCab; }

        [Required]
        [MaxLength(30)]
        public string OrderNumber { get; private set; }

        [Required]
        public DateTime OrderDate { get; private set; }

        [RegularExpression(@"^\d{6}\*{6}\d{4}")]
        [MaxLength(16)]
        public string CardNumber { get; private set; }

        [MaxLength(12)]
        public string NSU { get; private set; }

        [MaxLength(15)]
        public string CardFlag { get; private set; }

        [MaxLength(2)]
        public string AdmGlobalPayment { get; private set; }

        [Required]
        [MaxLength(12)]
        public string AuthorizationCode { get; private set; }

        //TODO: Verificar a necessidade dessa propriedade, uma vez que no documento está fazendo referencia ao DDD do número de telefone.
        [Required]
        [MaxLength(4)]
        public string Division { get; private set; }

        public PaymentInformation(string orderNumber, DateTime orderDate, string cardNumber, string nsu, string cardFlag, 
            string admGlobalPayment, string authorizationCode, string division)
        {
            this.OrderNumber = orderNumber;
            this.OrderDate = orderDate;
            this.CardNumber = cardNumber;
            this.NSU = nsu;
            this.CardFlag = cardFlag;
            this.AdmGlobalPayment = admGlobalPayment;
            this.AuthorizationCode = authorizationCode;
            this.Division = division;
        }        

        public string OrderDateSAP()
        {
            return this.OrderDate.ToString(formatDateTimeSAP);
        }
    }
}
