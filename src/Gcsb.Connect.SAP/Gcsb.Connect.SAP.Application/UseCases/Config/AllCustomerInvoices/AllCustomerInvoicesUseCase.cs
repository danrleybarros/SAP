using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.AllCustomerInvoices;
using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomerInvoices.RequestHandlers;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomerInvoices
{
    public class AllCustomerInvoicesUseCase : IAllCustomerInvoicesUseCase
    {
        private readonly GetCustomerHandler getCustomerHandler;
        private readonly IOutputPort<List<AllCustomerInvoicesOutput>> outputPort;

        public AllCustomerInvoicesUseCase(GetCustomerHandler getCustomerHandler, 
            GetInvoicesHandler getInvoicesHandler, 
            GetServicesHandler getServicesHandler,
            GetPaymentsHandler getPaymentsHandler,
            FillInvoiceObjectHandler fillInvoiceObjectHandler,
            MountConsumptionDataHandler mountConsumptionDataHandler,
            IOutputPort<List<AllCustomerInvoicesOutput>> outputPort)
        {
            getCustomerHandler.SetSucessor(getInvoicesHandler);
            getInvoicesHandler.SetSucessor(getServicesHandler);
            getServicesHandler.SetSucessor(getPaymentsHandler);
            getPaymentsHandler.SetSucessor(fillInvoiceObjectHandler);
            fillInvoiceObjectHandler.SetSucessor(mountConsumptionDataHandler);

            this.getCustomerHandler = getCustomerHandler;
            this.outputPort = outputPort;
        }

        public void Execute(AllCustomerInvoicesRequest request)
        {
            getCustomerHandler.ProcessRequest(request);
            outputPort.Standard(request.Consumptions);
        }
    }
}