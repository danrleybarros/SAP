using Gcsb.Connect.SAP.Application.Boundaries.PaymentFeedConsumption;
using Gcsb.Connect.SAP.Domain.Config.Enum;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeedConsumption.RequestHandler
{
    public class PaymentOutputHandler : Handler
    {
        public override void ProcessRequest(PaymentfeedConsumptionRequest request)
        {
            request.PaymentFeedsOutput.AddRange(request.PaymentsCredit
                .Select(s => new PaymentFeedOutput(
                    s.DateProcessing,
                    s.DateProcessing,
                    s.TransactionAmount.Value/100,
                    s.TransactionAmount.Value/100,
                    s.InvoiceNumberJsdn,
                    request.Invoices.FirstOrDefault(f => f.InvoiceNumber == s.InvoiceNumberJsdn).CycleCode.Value,
                    ((CardLabel)(string.IsNullOrEmpty(s.CardLabel) ? s.CardBrand.Value : int.Parse(s.CardLabel))).ToString(), 
                    s.CardPan,
                    string.IsNullOrEmpty(s.CreditCardNSU) ? s.AcquirerTransactionID : s.CreditCardNSU 
                    ))
                .ToList());

            request.PaymentFeedsOutput.AddRange(request.PaymentsBoleto
                .Select(s => new PaymentFeedOutput(
                    Convert.ToDateTime(s.DateTimePayment),
                    s.DateProcessing,
                    s.TransactionAmount.Value,
                    s.TransactionAmount.Value,
                    s.InvoiceNumberJsdn,
                    request.Invoices.FirstOrDefault(f => f.InvoiceNumber == s.InvoiceNumberJsdn).CycleCode.Value,
                    s.CodigoBanco.ToString(),
                    s.NomeBanco
                    ))
                .ToList());

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
