using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.GetDetailServiceByInvoice;
using Gcsb.Connect.SAP.Application.UseCases.Config.GetDetailServiceByInvoice.RequestHandlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetDetailServiceByInvoice
{
    public class GetDetailServiceByInvoiceUseCase : IGetDetailServiceByInvoiceUseCase
    {
        private readonly IOutputPort<GetDetailServiceByInvoiceOutput> outputPort;
        private readonly GetInvoiceHandler getInvoiceHandler;

        public GetDetailServiceByInvoiceUseCase(IOutputPort<GetDetailServiceByInvoiceOutput> outputPort, 
            GetInvoiceHandler getInvoiceHandler,
            GetCustomerHandler getCustomerHandler,
            GetServiceInvoiceHandler getServiceInvoiceHandler,
            OutputHandler outputHandler)
        {
            getInvoiceHandler.SetSucessor(getCustomerHandler);
            getCustomerHandler.SetSucessor(getServiceInvoiceHandler);
            getServiceInvoiceHandler.SetSucessor(outputHandler);

            this.outputPort = outputPort;
            this.getInvoiceHandler = getInvoiceHandler;
        }

        public void Execute(GetDetailServiceByInvoiceRequest request)
        {
            try
            {
                getInvoiceHandler.ProcessRequest(request);
                outputPort.Standard(request.Consumptions);
            }
            catch (Exception ex)
            {
                outputPort.Error($"Error message: {ex.Message}, Stack trace: {ex.StackTrace ?? ex.InnerException.StackTrace}");
            }
        }
    }
}
