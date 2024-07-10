using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Domain.Config.PaymentFeed;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed
{
    public class PaymentFeedRequest
    {
        private const string typeBoleto = "Boleto";
        private const string typeCredit = "Cartão de Crédito";

        public DateTime BillFromDate { get; private set; }
        public DateTime BillToDate { get; private set; }
        public FileType Type { get; private set; }
        public List<Invoice> Invoices { get; set; }
        public List<Log> Logs { get; set; }
        public List<PaymentBoleto> PaymentsBoleto { get; set; }
        public List<PaymentCreditCard> PaymentsCredit { get; set; }
        public Expression<Func<PaymentCreditCard, bool>> GetCredit { get; set; }
        public Expression<Func<PaymentBoleto, bool>> GetBoleto { get; set; }

        public string PaymentMethod { get => Type == FileType.Boleto ? typeBoleto : typeCredit; }

        public PaymentFeedRequest(DateTime billFromDate, DateTime billToDate, FileType type)
        {
            this.BillFromDate = billFromDate;
            this.BillToDate = billToDate;
            this.Type = type;
            this.Invoices = new List<Invoice>();
            this.Logs = new List<Log>();
            this.PaymentsCredit = new List<PaymentCreditCard>();
            this.PaymentsBoleto = new List<PaymentBoleto>();
        }

    }
}
