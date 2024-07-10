using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed.RequestHandler;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using Gcsb.Connect.SAP.Application.Boundaries;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed.Transaction.Boleto
{
    public class PaymentFeedDataUseCase : IPaymentFeedDataTransactionUseCase
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly GetPaymentBoletoHandler getPaymentBoletoHandler;
        private readonly IOutputPort<List<PaymentBoleto>> outputPort;

        public PaymentFeedDataUseCase(ILogWriteOnlyRepository logWriteOnlyRepository, GetPaymentBoletoHandler getPaymentBoletoHandler, IOutputPort<List<PaymentBoleto>> outputPort)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.getPaymentBoletoHandler = getPaymentBoletoHandler;
            this.outputPort = outputPort;
        }

        public void Execute(PaymentFeedRequest request)
        {
            try
            {
                request.GetBoleto = g => g.TransactionDate >= request.BillFromDate.Date && g.TransactionDate <= request.BillToDate.Date && !String.IsNullOrEmpty(g.CodigoBarras);
                getPaymentBoletoHandler.ProcessRequest(request);
                outputPort.Standard(request.PaymentsBoleto);
            }
            catch (Exception ex)
            {
                request.Logs.Add(new Log("Transaction - Boleto - PaymentFeedDataUseCase", $"Error on PaymentFeedDataUseCase with the date transaction parameter: {ex.Message} {ex.StackTrace}", TypeLog.Processing));
                outputPort.Error($"Error on get data: {ex.Message} {ex.StackTrace}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
