using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime.RequestHandlers
{
    public class ValidateHandler : Handler
    {
        public override void ProcessRequest(SpecialRegimeRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Validating data - Special Regime"));

            var errosList = request.SpecialRegimes.Where(s => s.ValidateModel().Count > 0).Select(s => string.Join(";", s.ValidateModel().Select(x => $"{x.ErrorMessage}"))).ToList();
            var errosString = string.Join(Environment.NewLine, errosList);

            if (errosList.Count > 0)
            {
                request.Logs.Add(Log.CreateExceptionLog(request.Service, "Model is invalid", errosString));
                throw new ArgumentException("Model invalid");
            }

            sucessor?.ProcessRequest(request);
        }
    }
}