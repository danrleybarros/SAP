using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers
{
    public class ValidateHandler : Handler, IValidateHandler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public ValidateHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(DocFeedRequest request)
        {            
            request.AddProcessingLog("PaymentFeed Ingest", "Validating data - PaymentFeed");
            var paymentList = new List<Domain.JSDN.PaymentFeedDoc>();
            request.DocFeed.ToList().ForEach(s => paymentList.Add(s as PaymentFeedDoc));
            var validation = ValidateDocs(paymentList);

            if (validation.Count > 0)
            {
                List<LogDetail> logDetails = new List<LogDetail>();
                validation.ForEach(s => logDetails.Add(new LogDetail(s.Item1, s.Item2)));
                request.AddErrorValidationLog("PaymentFeed Ingest", request.File.Id, "Error Validation Data", logDetails, TypeLog.Error);
                throw new DocAggregateException(validation.Select((e) => new DocValidationException(e)));
            }

            var invoicesExist = ValidateInvoices(paymentList);

            if (invoicesExist.Count > 0)
            {
                List<LogDetail> logDetails = new List<LogDetail>();
                invoicesExist.ForEach(invoiceNumber => logDetails.Add(new LogDetail("0", $"Invoice Number {invoiceNumber} dont't exist in any billfeed")));
                request.AddErrorValidationLog("PaymentFeed Ingest", request.File.Id, "Some invoice number don't exist in all billfeeds", logDetails, TypeLog.Error);
                throw new InvalidOperationException("Error validating the existence of invoice numbers in all billfeeds");
            }

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private List<Tuple<string, string>> ValidateDocs(IEnumerable<Domain.JSDN.PaymentFeedDoc> model)
        {
            List<Tuple<string, string>> lstValidationErrors = new List<Tuple<string, string>>();

            int i = 0;
            foreach (var item in model)
            {
                i++;
                List<ValidationResult> nestedItemResult = new List<ValidationResult>();
                ValidationContext context = new ValidationContext(item, null, null);

                Validator.TryValidateObject(item, context, nestedItemResult, true);
                if (nestedItemResult.Count == 0) continue;

                nestedItemResult.ForEach(r => lstValidationErrors.Add(Tuple.Create<string, string>(i.ToString(), r.ErrorMessage)));
            }

            return lstValidationErrors;
        }

        private List<string> ValidateInvoices(IEnumerable<PaymentFeedDoc> model)
        {
            var invoicesNumber = model.Select(s => s.InvoiceNumberJsdn).Distinct().ToList();            
            var invoices = invoiceReadOnlyRepository.GetInvoices(s => invoicesNumber.Contains(s.InvoiceNumber));

             return invoicesNumber
                .Where(invoiceNumber => !invoices.Select(s => s.InvoiceNumber).Contains(invoiceNumber))
                .ToList();
        }
    }
}
