using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Boundaries.PaymentFeedConsumption
{
    public class PaymentFeedOutput
    {
        const string attributionMethod = "Automaticamente";
        const string invoiceStatus = "Fechada";

        public DateTime PaymentDate { get; set; }
        public DateTime AssignmentDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal AmountReceived { get; set; }
        public string PaymentMetohd { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Cycle { get; set; }
        public string InvoiceStatus { get => invoiceStatus; }
        public string AttributionMethod { get => attributionMethod; }

        //Boleto
        [AllowNull]
        public string BankCode  { get; set; }
        [AllowNull]
        public string BankName { get; set; }

        //Credit Card
        [AllowNull]
        public string CreditCardBrand { get; set; }
        [AllowNull]
        public string CreditCardNumber { get; set; }
        [AllowNull]
        public string Nsu { get; set; }

        public PaymentFeedOutput(DateTime paymentDate, DateTime assignmentDate, decimal transactionAmount, 
            decimal amountReceived, string invoiceNumber, DateTime cycle, 
            string? bankCode, string? bankName)
        {
            PaymentDate = paymentDate;
            AssignmentDate = assignmentDate;
            TransactionAmount = transactionAmount;
            AmountReceived = amountReceived;
            PaymentMetohd = "Boleto";
            InvoiceNumber = invoiceNumber;
            Cycle = cycle;
            BankCode = bankCode;
            BankName = bankName;
        }

        public PaymentFeedOutput(DateTime paymentDate, DateTime assignmentDate, decimal transactionAmount,
            decimal amountReceived, string invoiceNumber, DateTime cycle, 
            string? creditCardBrand, string? creditCardNumber, string? nsu)
        {
            PaymentDate = paymentDate;
            AssignmentDate = assignmentDate;
            TransactionAmount = transactionAmount;
            AmountReceived = amountReceived;
            PaymentMetohd = "Cartão de crédito";
            InvoiceNumber = invoiceNumber;
            Cycle = cycle;
            CreditCardBrand = creditCardBrand;
            CreditCardNumber = creditCardNumber;
            Nsu = nsu;
        }
    }
}
