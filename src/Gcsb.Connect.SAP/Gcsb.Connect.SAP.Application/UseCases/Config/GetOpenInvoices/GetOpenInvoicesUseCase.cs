using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices.RequestHandlers;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices
{
    public class GetOpenInvoicesUseCase : IGetOpenInvoicesUseCase
    {
        private readonly Handler<GetOpenInvoicesRequest> initialHandler;
        private readonly PayFilterHandler payFilterHandler;
        private readonly IOutputPort<List<InvoiceOutput>> outputPort;
        private readonly ILogInfrastructure logInfrastructure;

        public GetOpenInvoicesUseCase(IOutputPort<List<InvoiceOutput>> outputPort,
            GetCustomerHandler customerHandler,
            GetInvoicesHandler invoicesHandler,
            GetServicesHandler servicesHandler,
            GetPaymentsHandler paymentsHandler,
            InvoiceFilterHandler invoiceFilterHandler,
            PayFilterHandler payFilterHandler, 
            ILogInfrastructure logInfrastructure)
        {
            customerHandler
                .SetSucessor(invoicesHandler)
                .SetSucessor(servicesHandler)
                .SetSucessor(paymentsHandler)
                .SetSucessor(invoiceFilterHandler);

            initialHandler = customerHandler;
            this.payFilterHandler = payFilterHandler;
            this.outputPort = outputPort;
            this.logInfrastructure = logInfrastructure;
        }

        public void Execute(GetOpenInvoicesRequest request)
        {
            try
            {
                initialHandler.ProcessRequest(request);
                outputPort.Standard(request.OpenInvoicesOutput);
            }
            catch (System.Exception ex)
            {
                outputPort.Error(ex.Message);
                logInfrastructure.LogException(ex, $"{GetType().Name} - {ex.Message}");
            }
        }

        public IGetOpenInvoicesUseCase AddPayFilterHandler()
        {
            Handler<GetOpenInvoicesRequest> currentHandler = initialHandler;

            while(currentHandler.GetSucessor() != null)
            {
                currentHandler = currentHandler.GetSucessor();
            }

            currentHandler.SetSucessor(payFilterHandler);

            return this;
        }
    }
}
