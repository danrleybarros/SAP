using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers
{
    public class ValidateHandler : Handler
    {
        public override void ProcessRequest(ISIChainRequest request)
        {
            request.AddProcessingLog("Validating data - Individual Report Service");

            var errosList = request
                .Lines
                .Where(f => f.ValidateModel().Any())
                .Select(s => string.Join(";", s.ValidateModel().Select(v => $"{v.ErrorMessage}")))
                .ToList();

            var errosString = string.Join(Environment.NewLine, errosList);

            if (errosList.Any())
            {
                request.AddExceptionLog("Model is invalid", errosString.Substring(0, 1999)); 
                throw new ArgumentException("Model invalid");
            }

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
