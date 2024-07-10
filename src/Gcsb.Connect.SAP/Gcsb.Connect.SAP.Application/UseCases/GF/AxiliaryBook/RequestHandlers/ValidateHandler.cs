using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook.RequestHandlers
{
    public class ValidateHandler : Handler
    {
        public override void ProcessRequest(AxiliaryBookRequest request)
        {
            request.AddProcessingLog("Validating data - AxiliaryBook");
            var errosList = request.LaunchItems.Where(s => s.ValidateModel().Count > 0)
                .Select(s => string.Join(";", s.ValidateModel().Select(x => $"{x.ErrorMessage}"))).ToList();
            var errosString = string.Join(Environment.NewLine, errosList);

            if (errosList.Count > 0)
            {
                request.AddExceptionLog("Model is invalid", errosString);
                throw new ArgumentException("Model invalid");
            }

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
