using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.Messaging.Messages.Log;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.ComponentModel.DataAnnotations;
using Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.Exception;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF.ReturnNFHandlers
{
    public class ValidateHandler : Handler
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public ValidateHandler(IFileReadOnlyRepository FileReadOnlyRepository, ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.fileReadOnlyRepository = FileReadOnlyRepository;
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public override void ProcessRequest(ReturnNFRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Validating data"));

            var validation = new List<Tuple<string, string>>();

            validation.AddRange(ValidateReturnNFs(request.NFs));
            validation.AddRange(ValidateInvoices(request));

            if (validation.Count > 0)
            {
                var logDetails = new List<LogDetail>();

                validation.ForEach(s => logDetails.Add(new LogDetail(s.Item1, s.Item2)));
                request.Logs.Add(Log.CreateExceptionLog(request.Service, request.File.Id, "Error Validation Data", logDetails));

                throw new DocAggregateException(validation.Select((e) => new DocValidationException(e)));
            }

            sucessor?.ProcessRequest(request);
        }

        private List<Tuple<string, string>> ValidateReturnNFs(List<Domain.GF.Nfe.ReturnNF> nfs)
        {
            var lstValidationErrors = new List<Tuple<string, string>>();

            for (var i = 0; i < nfs.Count; i++)
            {
                var item = nfs[i];
                var nestedItemResult = new List<ValidationResult>();
                var context = new ValidationContext(item, null, null);

                Validator.TryValidateObject(item, context, nestedItemResult, true);

                nestedItemResult.ForEach(r => lstValidationErrors.Add(Tuple.Create(i.ToString(), r.ErrorMessage)));
            }

            return lstValidationErrors;
        }

        private List<Tuple<string, string>> ValidateInvoices(ReturnNFRequest request)
        {
            var lstValidationErrors = new List<Tuple<string, string>>();
            var activitiesToAvoid = new List<string> { "credits", "fines", "interest", "payment credit", "contractual fine" };

            var billFeedFile = request.BillFeedFileId.HasValue ?
                fileReadOnlyRepository.GetFile(s => s.Id == request.BillFeedFileId.Value && s.Status == Status.Success) :
                fileReadOnlyRepository.GetFiles(TypeRegister.BILLCSV, Status.Success).OrderByDescending(p => p.InclusionDate).FirstOrDefault();

            if (billFeedFile != null)
            {
                request.BillfeedId = billFeedFile.Id;
                request.BillfeedCycleDate = billFeedFile.CycleDate.Value;

                var customers = customerReadOnlyRepository.GetCustomers(billFeedFile.Id, "S") ?? new List<Customer>();

                customers.SelectMany(s => s.Invoice.Services)
                    .Where(f => !activitiesToAvoid.Contains(f.Activity.ToLower()))
                    .Select(s => s.InvoiceNumber)
                    .Distinct()
                    .ToList()
                    .ForEach(invoiceNumber =>
                    {
                        var validInvoice = request.NFs.Select(s => s.InvoiceID).Contains(invoiceNumber);

                        if (!validInvoice)
                            lstValidationErrors.Add(Tuple.Create("0", $"The invoice: {invoiceNumber} not exists in return nf object"));
                    });
            }
            else
                lstValidationErrors.Add(Tuple.Create("0", "Not found any billfeed on database"));

            return lstValidationErrors;
        }
    }
}
