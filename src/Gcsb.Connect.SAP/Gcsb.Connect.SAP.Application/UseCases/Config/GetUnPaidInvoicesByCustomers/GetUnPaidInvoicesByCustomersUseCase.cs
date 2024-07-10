using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.GetUnPaidInvoicesByCustomers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.GetUnPaidInvoicesByCustomers.RequestHandlers;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetUnPaidInvoicesByCustomers
{
    public class GetUnPaidInvoicesByCustomersUseCase : IGetUnPaidInvoicesByCustomersUseCase
    {
        private readonly GetCustomerHandler getCustomerHandler;
        private readonly IOutputPort<List<InvoicesByDocumentOutput>> outputPort;
        private readonly ILogInfrastructure logInfrastructure;

        public GetUnPaidInvoicesByCustomersUseCase(
            IOutputPort<List<InvoicesByDocumentOutput>> outputPort,
            ILogInfrastructure logInfrastructure,
            GetCustomerHandler customerHandler,
            GetInvoicesHandler invoicesHandler,
            GetServicesHandler servicesHandler,
            GetPaymentsHandler paymentsHandler,
            InvoiceFilterHandler invoiceFilterHandler
            )
        {
            customerHandler.SetSucessor(invoicesHandler);
            invoicesHandler.SetSucessor(servicesHandler);
            servicesHandler.SetSucessor(paymentsHandler);
            paymentsHandler.SetSucessor(invoiceFilterHandler);

            this.getCustomerHandler = customerHandler;
            this.outputPort = outputPort;
            this.logInfrastructure = logInfrastructure;
        }

        public void Execute(GetUnPaidInvoicesByCustomersRequest request)
        {
            try
            {
                getCustomerHandler.ProcessRequest(request);
                outputPort.Standard(request.OpenInvoicesOutput);
            }
            catch (Exception ex)
            {
                outputPort.Error(ex.Message);
                logInfrastructure.LogException(ex, $"{GetType().Name} - {ex.Message}");
            }
        }
    }
}
