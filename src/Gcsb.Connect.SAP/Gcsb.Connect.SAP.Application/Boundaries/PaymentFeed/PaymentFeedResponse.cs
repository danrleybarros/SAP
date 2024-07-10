using Gcsb.Connect.SAP.Domain.Config.PaymentFeed;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;

namespace Gcsb.Connect.SAP.Application.Boundaries.PaymentFeed
{
    public class PaymentFeedResponse
    {
        public int ResultCode { get; private set; }

        public string Description { get; private set; }

        public string EntityId { get; private set; }

        public string CardPan { get; private set; }

        public string CardExpirationDate { get; private set; }

        public decimal TransactionAmount { get; private set; }

        public DateTime? DatetimeSIA { get; private set; }

        public DateTime? DatetimePayment { get; private set; }

        public string CardType { get; private set; }

        public string InvoiceNumber { get; private set; }

        public DateTime TransactionDate { get; private set; }

        public string BillingCycle { get; private set; }

        public int BankCode { get; private set; }

        public string BankName { get; private set; }

        public string BarCode { get; private set; }

        public string CovenantCode { get; private set; }

        public DateTime DueDate { get; private set; }

        public int? NSA { get; private set; }

        public string UF { get; private set; }

        public decimal ReceivedValue { get; private set; }

        public DateTime? PaymentDate { get; private set; }

        public string CreditCard { get; private set; }

        public string CreditCardNSU { get; private set; }

        public string AuthorizationCode { get; private set; }

        public string CardLabel { get; private set; }

        public string Acquirer { get; private set; }

        public decimal? PaymentValue { get; private set; }

        public FileType Type { get; private set; }

        public PaymentFeedResponse(PaymentCreditCard paymentCredit) :  this(paymentCredit.ResultCode, paymentCredit.Description, paymentCredit.EntityId, 
            paymentCredit.CardPan, paymentCredit.CardExpirationDate, paymentCredit.TransactionAmount.Value, paymentCredit.DateTimeSIA, 
            paymentCredit.DateTimePayment, paymentCredit.CardType, paymentCredit.InvoiceNumberJsdn, paymentCredit.TransactionDate.Value, FileType.Credit)
        {
            PaymentDate = ConvertDate(paymentCredit.PaymentDate);
            CreditCard = paymentCredit.CreditCard;
            CreditCardNSU = paymentCredit.CreditCardNSU;
            AuthorizationCode = paymentCredit.AuthorizationCode;
            CardLabel = paymentCredit.CardLabel;
            Acquirer = paymentCredit.Acquirer;
            PaymentValue = paymentCredit.PaymentValue;
        }

        public PaymentFeedResponse(PaymentBoleto paymentBoleto) : this(paymentBoleto.EntityId, paymentBoleto.TransactionAmount.Value, paymentBoleto.DateTimeSIA, 
            paymentBoleto.DateTimePayment, paymentBoleto.InvoiceNumberJsdn, paymentBoleto.TransactionDate.Value, paymentBoleto.CicloFaturamento, 
            paymentBoleto.CodigoBanco, paymentBoleto.NomeBanco, paymentBoleto.CodigoBarras, paymentBoleto.CodigoConvenio,
            paymentBoleto.DataVencimento, paymentBoleto.NSA, paymentBoleto.UF, paymentBoleto.ValorRecebido, FileType.Boleto)
        { }


        public PaymentFeedResponse(string entityId, decimal transactionAmount, string datetimeSIA, string datetimePayment, 
            string invoiceNumber, DateTime transactionDate, string billingCycle, int bankCode, string bankName, 
            string barCode, string covenantCode, DateTime dueDate, int? nSA, string uF, decimal receivedValue, FileType type)
        {
            EntityId = entityId;
            TransactionAmount = transactionAmount;
            DatetimeSIA = Convert.ToDateTime(datetimeSIA);
            DatetimePayment = Convert.ToDateTime(datetimePayment);
            InvoiceNumber = invoiceNumber;
            TransactionDate = transactionDate;
            BillingCycle = billingCycle;
            BankCode = bankCode;
            BankName = bankName;
            BarCode = barCode;
            CovenantCode = covenantCode;
            DueDate = dueDate;
            NSA = nSA;
            UF = uF;
            ReceivedValue = receivedValue;
            Type = type;
        }

        public PaymentFeedResponse(int resultCode, string description, string entityId, string cardPan, 
            string cardExpirationDate, decimal transactionAmount, string datetimeSIA, string datetimePayment, 
            string cardType, string invoiceNumber, DateTime transactionDate, FileType type)
        {
            ResultCode = resultCode;
            Description = description;
            EntityId = entityId;
            CardPan = cardPan;
            CardExpirationDate = cardExpirationDate;
            TransactionAmount = transactionAmount;
            DatetimeSIA = ConvertDate(datetimeSIA);
            DatetimePayment = ConvertDate(datetimePayment); 
            CardType = cardType;
            InvoiceNumber = invoiceNumber;
            TransactionDate = transactionDate;
            Type = type;
        }

        private DateTime? ConvertDate(string date)
        {
            if (string.IsNullOrEmpty(date)) return null;
            if (date.Length < 12) throw new ArgumentOutOfRangeException();

            var year = $"20{date.Substring(0, 2)}";
            var month = date.Substring(2, 2);
            var day = date.Substring(4, 2);
            var hour = date.Substring(6, 2);
            var minute = date.Substring(8, 2);
            var second = date.Substring(10, 2);

            return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), int.Parse(second));
        }
    }
}
