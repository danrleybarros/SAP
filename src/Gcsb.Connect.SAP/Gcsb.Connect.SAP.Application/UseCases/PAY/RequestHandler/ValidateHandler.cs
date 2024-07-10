using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.PAY.RequestHandler
{
    public class ValidateHandler : Handler
    {
        public override void ProcessRequest(CriticalRequest request)
        {
            request.AddLog("Validating data criticals");

            var errosList = request.Criticals
                     .Where(s => s.ValidateModel().Count > 0)
                     .Select(s => string.Join(";", s.ValidateModel()
                     .Select(x => $"{x.ErrorMessage}"))).ToList();

            var errosString = string.Join(Environment.NewLine, errosList);

            if (errosList.Any())
            {
                request.AddLogError($"Model is invalid - { errosString }");
                return;
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
