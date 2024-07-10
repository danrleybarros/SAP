using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedConsumption
{
    public class PaymentFeedResponse
    {
        public DateTime PaymentDate { get; set; }
        public DateTime AssignmentDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal AmountReceived { get; set; }
        public string PaymentMethod { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Cycle { get; set; }
        public string InvoiceStatus { get; set; }
        public string AttributionMethod { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string CreditCardBrand { get; set; }
        public string CreditCardNumber { get; set; }
        public string Nsu { get; set; }

        public PaymentFeedResponse(DateTime paymentDate, DateTime assignmentDate, decimal transactionAmount, 
            decimal amountReceived, string paymentMethod, string invoiceNumber, DateTime cycle, string invoiceStatus, 
            string attributionMethod, string bankCode, string bankName, string creditCardBrand, string creditCardNumber, 
            string nsu)
        {
            PaymentDate = paymentDate;
            AssignmentDate = assignmentDate;
            TransactionAmount = transactionAmount;
            AmountReceived = amountReceived;
            PaymentMethod = paymentMethod;
            InvoiceNumber = invoiceNumber;
            Cycle = cycle;
            InvoiceStatus = invoiceStatus;
            AttributionMethod = attributionMethod;
            BankCode = bankCode;
            BankName = bankName;
            CreditCardBrand = creditCardBrand;
            CreditCardNumber = creditCardNumber;
            Nsu = nsu;
        }
    }
}
