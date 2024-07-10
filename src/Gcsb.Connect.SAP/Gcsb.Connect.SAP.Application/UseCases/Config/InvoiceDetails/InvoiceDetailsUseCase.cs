using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.CustomerConsumption;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InvoiceDetails
{
    public class InvoiceDetailsUseCase : IInvoiceDetailUseCase
    {
        private readonly RequestHandlers.GetCustomerHandler getCustomerHandler;
        private readonly IOutputPort<InvoiceDetailsOutput> outputPort;
        private readonly ILogInfrastructure logInfrastructure;

        public InvoiceDetailsUseCase(RequestHandlers.GetCustomerHandler getCustomerHandler, 
            RequestHandlers.GetInvoicesHandler getInvoicesHandler, 
            RequestHandlers.GetServicesHandler getServicesHandler,
            RequestHandlers.GetPaymentsHandler getPaymentsHandler,
            RequestHandlers.FillInvoiceObjectHandler fillInvoiceObjectHandler,
            RequestHandlers.MountConsumptionDataHandler mountConsumptionDataHandler,
            IOutputPort<InvoiceDetailsOutput> outputPort,
            ILogInfrastructure logInfrastructure)
        {
            getCustomerHandler.SetSucessor(getInvoicesHandler)
                .SetSucessor(getServicesHandler)
                .SetSucessor(getPaymentsHandler)
                .SetSucessor(fillInvoiceObjectHandler)
                .SetSucessor(mountConsumptionDataHandler);

            this.getCustomerHandler = getCustomerHandler;
            this.outputPort = outputPort;
            this.logInfrastructure = logInfrastructure;
        }

        public void Execute(InvoiceDetailsRequest request)
        {

            try
            {
                getCustomerHandler.ProcessRequest(request);
                outputPort.Standard(request.Output);
            }
            catch (System.Exception ex)
            {
                logInfrastructure.LogException(ex, ex.Message);
                outputPort.Error($"Message: {ex.Message}\n, StackTrace: {ex.StackTrace}");
            }
        }
    }
}