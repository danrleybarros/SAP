using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed.RequestHandler;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using Gcsb.Connect.SAP.Application.Boundaries;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed.Transaction.Credit
{
    public class PaymentFeedDataUseCase : IPaymentFeedDataTransactionUseCase
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly GetPaymentCreditHandler getPaymentCreditHandler;
        private readonly IOutputPort<List<PaymentCreditCard>> outputPort;

        public PaymentFeedDataUseCase(ILogWriteOnlyRepository logWriteOnlyRepository, GetPaymentCreditHandler getPaymentCreditHandler, IOutputPort<List<PaymentCreditCard>> outputPort)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.getPaymentCreditHandler = getPaymentCreditHandler;
            this.outputPort = outputPort;
        }

        public void Execute(PaymentFeedRequest request)
        {
            try
            {
                request.GetCredit = g => g.TransactionDate >= request.BillFromDate.Date && g.TransactionDate <= request.BillToDate.Date && g.ResultCode >= 0;
                getPaymentCreditHandler.ProcessRequest(request);
                outputPort.Standard(request.PaymentsCredit);
            }
            catch (Exception ex)
            {
                request.Logs.Add(new Log("Transaction - Credit - PaymentFeedDataUseCase", $"Error on PaymentFeedDataUseCase with the date transaction parameter: {ex.Message} {ex.StackTrace}", TypeLog.Processing));
                outputPort.Error($"Error on get data: {ex.Message} {ex.StackTrace}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
