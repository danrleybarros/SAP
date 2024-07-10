using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Domain.JSDN;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.RequestHandlers
{
    public class ValidateHandler : Handler<BillFeedChainRequest>
    {
        public override void ProcessRequest(BillFeedChainRequest request)
        {
            request.AddProcessingLog("BillFeed Ingest", "Validating csv data - BillFeed", request.File.Id);

            var logsValidation = ValidateDocs(request.BillFeedDocs);

            if (logsValidation.Count > 0)
            {
                request.ReturnValue = 0;
                request.AddErrorValidationLog("BillFeed Ingest", request.File.Id, "Error Validation Data", logsValidation, TypeLog.Error);

                return;
            }

            sucessor?.ProcessRequest(request);
        }

        private List<LogDetail> ValidateDocs(List<BillFeedDoc> model)
        {
            var logsValidation = new List<LogDetail>();

            int i = 0;

            model.ForEach(item =>
            {
                var nestedItemResult = new List<ValidationResult>();
                var context = new ValidationContext(item, null, null);

                Validator.TryValidateObject(item, context, nestedItemResult, true);

                if (nestedItemResult.Count > 0)
                {
                    nestedItemResult.ForEach(r => logsValidation.Add(new LogDetail(i.ToString(), r.ErrorMessage)));
                    return;
                }

                i++;
            });

            return logsValidation;
        }
    }
}
