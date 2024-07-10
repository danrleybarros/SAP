using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.CustomersConsumption;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomersConsumption.RequestHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomersConsumption
{
    public class CustomersConsumptionUseCase : ICustomersConsumptionUseCase
    {
        private readonly GetCustomerHandler getCustomerHandler;
        private readonly IOutputPort<List<CustomersOutput>> outputPort;

        public CustomersConsumptionUseCase(GetCustomerHandler getCustomerHandler,
            GetInvoicesHandler getInvoicesHandler,
            GetPaymentsHandler getPaymentsHandler,
            FillInvoiceObjectHandler fillInvoiceObjectHandler,
            GetCreditInvoicesHandler getCreditInvoicesHandler,
            MountConsumptionDataHandler mountConsumptionDataHandler,
            IOutputPort<List<CustomersOutput>> outputPort)
        {
            getCustomerHandler.SetSucessor(getInvoicesHandler);
            getInvoicesHandler.SetSucessor(getPaymentsHandler);
            getPaymentsHandler.SetSucessor(fillInvoiceObjectHandler);
            fillInvoiceObjectHandler.SetSucessor(getCreditInvoicesHandler);
            getCreditInvoicesHandler.SetSucessor(mountConsumptionDataHandler);

            this.getCustomerHandler = getCustomerHandler;
            this.outputPort = outputPort;
        }

        public void Execute(CustomersConsumptionRequest request)
        {
            try
            {
                getCustomerHandler.ProcessRequest(request);
                outputPort.Standard(request.Consumptions);
            }
            catch (Exception ex)
            {
                outputPort.Error($"Error message: {ex.Message}, Stack trace: {ex.StackTrace ?? ex.InnerException.StackTrace}");
            }
        }
    }
}
