using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.PaymentFeedConsumption;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeedConsumption.RequestHandler;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeedConsumption
{
    public class PaymentfeedConsumptionUseCase : IPaymentfeedConsumptionUseCase
    {
        private readonly IOutputPort<List<PaymentFeedOutput>> outputPort;
        private readonly GetCustomerHandler getCustomerHandler;
        private readonly ILogInfrastructure logInfrastructure;

        public PaymentfeedConsumptionUseCase(IOutputPort<List<PaymentFeedOutput>> outputPort,
            GetCustomerHandler getCustomerHandler,
            GetPaymentBoletoHandler getPaymentBoletoHandler,
            GetPaymentCreditHandler getPaymentCreditHandler,
            GetInvoicesHandler getInvoicesHandler,
            PaymentOutputHandler paymentOutputHandler, 
            ILogInfrastructure logInfrastructure)
        {
            getCustomerHandler.SetSucessor(getPaymentBoletoHandler);
            getPaymentBoletoHandler.SetSucessor(getPaymentCreditHandler);
            getPaymentCreditHandler.SetSucessor(getInvoicesHandler);
            getInvoicesHandler.SetSucessor(paymentOutputHandler);

            this.outputPort = outputPort;
            this.getCustomerHandler = getCustomerHandler;
            this.logInfrastructure = logInfrastructure;
        }

        public void Execute(PaymentfeedConsumptionRequest request)
        {
            try
            {
                getCustomerHandler.ProcessRequest(request);
                outputPort.Standard(request.PaymentFeedsOutput);
            }
            catch (ArgumentException ex)
            {
                outputPort.NotFound(ex.Message);
                logInfrastructure.LogException(ex, $"{GetType()} - {ex.Message}");
            }
            catch (Exception ex)
            {
                outputPort.Error(ex.Message);
                logInfrastructure.LogException(ex, $"{GetType()} - {ex.Message}");
            }
        }
    }
}
