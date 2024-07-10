using Gcsb.Connect.SAP.Domain.Config.PaymentFeed;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using Response = Gcsb.Connect.SAP.Application.Boundaries.PaymentFeed.PaymentFeedResponse;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedData.PaymentFeedResponse
{
    public class OutputPaymentFeed
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
        public FileType Type { get; private set; }

        public DateTime? PaymentDate { get; private set; }

        public string CreditCard { get; private set; }

        public string CreditCardNSU { get; private set; }

        public string AuthorizationCode { get; private set; }

        public string CardLabel { get; private set; }

        public string Acquirer { get; private set; }

        public decimal? PaymentValue { get; private set; }

        public OutputPaymentFeed(int resultCode, string description, string entityId, string cardPan, string cardExpirationDate, decimal transactionAmount, DateTime? datetimeSIA, DateTime? datetimePayment, 
            string cardType, string invoiceNumber, DateTime transactionDate, string billingCycle, int bankCode, string bankName, string barCode, string covenantCode, DateTime dueDate, int? nSA, string uF, 
            decimal receivedValue, FileType type)
        {
            ResultCode = resultCode;
            Description = description;
            EntityId = entityId;
            CardPan = cardPan;
            CardExpirationDate = cardExpirationDate;
            TransactionAmount = transactionAmount;
            DatetimeSIA = datetimeSIA;
            DatetimePayment = datetimePayment;
            CardType = cardType;
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

        public OutputPaymentFeed(Response response) : this(response.ResultCode,
                  response.Description,
                  response.EntityId,
                  response.CardPan,
                  response.CardExpirationDate,
                  response.TransactionAmount,
                  response.DatetimeSIA,
                  response.DatetimePayment,
                  response.CardType,
                  response.InvoiceNumber,
                  response.TransactionDate,
                  response.BillingCycle,
                  response.BankCode,
                  response.BankName,
                  response.BarCode,
                  response.CovenantCode,
                  response.DueDate,
                  response.NSA,
                  response.UF,
                  response.ReceivedValue,
                  response.Type)
        {
            if(response.Type == FileType.Credit)
            {

                PaymentDate = response.PaymentDate;
                CreditCard = response.CreditCard;
                CreditCardNSU = response.CreditCardNSU;
                AuthorizationCode = response.AuthorizationCode;
                CardLabel = response.CardLabel;
                Acquirer = response.Acquirer;
                PaymentValue = response.PaymentValue;
            }
        }
    }
}
