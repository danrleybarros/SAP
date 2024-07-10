using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories.Pay;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.PAY.RequestHandler
{
    public class CallApiPayHandler : Handler
    {
        private readonly IServicePay servicePay;

        public CallApiPayHandler(IServicePay servicePay)
        {
            this.servicePay = servicePay;
        }

        public override void ProcessRequest(CriticalRequest request)
        {         
            request.AddLog($"Getting critical on api pay - DataProcessing {request.InclusionDate}");

            // variável vazia/nula executa normalmente - regra temporária para subida para produção
            if (string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("NOT_EXEC_CRITICALS"))) 
            {
                request.Criticals = servicePay.Execute(request.InclusionDate, DateTime.UtcNow.Date);           
                request.Criticals.ForEach(f => f.SetParendId(request.IDPaymentFeed));
            }

            request.AddLog($"Total Data Encountered: { request.Criticals.Count()}");
                      
            if (sucessor != null)
                sucessor.ProcessRequest(request);

        }
    }
}
