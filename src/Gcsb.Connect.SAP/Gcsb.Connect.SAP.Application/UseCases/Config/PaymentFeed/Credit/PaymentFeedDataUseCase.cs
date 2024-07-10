using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed.RequestHandler;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed.Credit
{
    public class PaymentFeedDataUseCase : IPaymentFeedDataUseCase
    {
        private readonly GetInvoicesHandler getInvoicesHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IOutputPort<List<PaymentCreditCard>> outputPort;

        public PaymentFeedDataUseCase(GetInvoicesHandler getInvoicesHandler, 
            GetPaymentCreditHandler getPaymentCreditHandler,
            ILogWriteOnlyRepository logWriteOnlyRepository, 
            IOutputPort<List<PaymentCreditCard>> outputPort)
        {
            getInvoicesHandler.SetSucessor(getPaymentCreditHandler);

            this.getInvoicesHandler = getInvoicesHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.outputPort = outputPort;
        }

        public void Execute(PaymentFeedRequest request)
        {
            try
            {
                getInvoicesHandler.ProcessRequest(request);
                outputPort.Standard(request.PaymentsCredit);
            }
            catch (Exception ex)
            {
                request.Logs.Add(new Log("PaymentFeedDataUseCase", $"Error on PaymentFeedDataUseCase with the cycle parameter: {ex.Message} {ex.StackTrace}", Messaging.Messages.Log.Enum.TypeLog.Processing));
                outputPort.Error($"Error on get data: {ex.Message} {ex.StackTrace}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
