using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.NewPendingInvoices;
using Gcsb.Connect.SAP.Application.UseCases.Config.NewPendingInvoices.RequestHandlers;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.NewPendingInvoices
{
    public class NewPendingInvoicesUseCase : INewPendingInvoicesUseCase
    {
        private readonly GetCustomerHandler getCustomerHandler;
        private readonly IOutputPort<List<NewPendingInvoicesOutput>> outputPort;

        public NewPendingInvoicesUseCase(GetCustomerHandler getCustomerHandler, 
            GetCustomerInvoiceCyberHandler getCustomerInvoiceCyberHandler,
            GetAllInvoicesHandler getAllInvoicesHandler,
            GetInvoicesPaid getInvoicesPaid,
            GetPaymentsHandler getPaymentsHandler,
            CreateOutputHandler createOutputHandler,
            IOutputPort<List<NewPendingInvoicesOutput>> outputPort)
        {
            getCustomerHandler.SetSucessor(getCustomerInvoiceCyberHandler);
            getCustomerInvoiceCyberHandler.SetSucessor(getAllInvoicesHandler);
            getAllInvoicesHandler.SetSucessor(getPaymentsHandler);
            getPaymentsHandler.SetSucessor(getInvoicesPaid);
            getInvoicesPaid.SetSucessor(createOutputHandler);

            this.getCustomerHandler = getCustomerHandler;
            this.outputPort = outputPort;
        }

        public void Execute(NewPendingInvoicesRequest request)
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
