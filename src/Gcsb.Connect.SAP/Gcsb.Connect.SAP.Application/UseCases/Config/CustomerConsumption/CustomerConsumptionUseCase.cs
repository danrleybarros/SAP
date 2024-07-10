using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.CustomerConsumption;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption.RequestHandlers;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption
{
    public class CustomerConsumptionUseCase : ICustomerConsumptionUseCase
    {
        private readonly GetCustomerHandler getCustomerHandler;
        private readonly IOutputPort<List<ConsumptionOutput>> outputPort;

        public CustomerConsumptionUseCase(GetCustomerHandler getCustomerHandler, 
            GetInvoicesHandler getInvoicesHandler, 
            GetServicesHandler getServicesHandler,
            GetPaymentsHandler getPaymentsHandler,
            FillInvoiceObjectHandler fillInvoiceObjectHandler,
            MountConsumptionDataHandler mountConsumptionDataHandler,
            IOutputPort<List<ConsumptionOutput>> outputPort)
        {
            getCustomerHandler.SetSucessor(getInvoicesHandler);
            getInvoicesHandler.SetSucessor(getServicesHandler);
            getServicesHandler.SetSucessor(getPaymentsHandler);
            getPaymentsHandler.SetSucessor(fillInvoiceObjectHandler);
            fillInvoiceObjectHandler.SetSucessor(mountConsumptionDataHandler);

            this.getCustomerHandler = getCustomerHandler;
            this.outputPort = outputPort;
        }

        public void Execute(CustomerConsumptionRequest request)
        {
            getCustomerHandler.ProcessRequest(request);
            outputPort.Standard(request.Consumptions);
        }
    }
}