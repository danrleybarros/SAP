using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.Services
{
    public class ServicesUseCase : IServicesUseCase
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IOutputPort<List<ServiceInvoice>> outputPort;

        public ServicesUseCase(IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository, ILogWriteOnlyRepository logWriteOnlyRepository, IOutputPort<List<ServiceInvoice>> outputPort)
        {
            this.serviceInvoiceReadOnlyRepository = serviceInvoiceReadOnlyRepository;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.outputPort = outputPort;
        }

        public void Execute(List<string> invoices)
        {
            var logs = new List<Log>();

            try
            {
                logs.Add(new Log("ServicesUseCase", "Getting a list of services by invoice number", TypeLog.Processing));
                outputPort.Standard(serviceInvoiceReadOnlyRepository.GetServices(w => invoices.Contains(w.InvoiceNumber)));
            }
            catch (Exception ex)
            {
                logs.Add(new Log("ServicesUseCase", $"Error on get services: {ex.Message} {ex.StackTrace}", TypeLog.Processing));
                outputPort.Error($"{ex.Message} {ex.StackTrace}");
            }
            finally
            {
                logWriteOnlyRepository.Add(logs);
            }
        }
    }
}
