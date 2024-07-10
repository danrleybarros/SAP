using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices.RequestHandlers;
using Gcsb.Connect.SAP.Domain.Config.CustomerService;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices
{
    public class CustomerServicesUseCase : ICustomerServicesUseCase
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly GetServicesInvoicesHandler getServicesInvoicesHandler;
        private readonly IOutputPort<List<CustomerService>> outputPort;

        public CustomerServicesUseCase(ILogWriteOnlyRepository logWriteOnlyRepository,
            IOutputPort<List<CustomerService>> outputPort,
            GetServicesInvoicesHandler getServicesInvoicesHandler,
            GetInvoicesHandler getInvoicesHandler,
            GetCustomersHandler getCustomersHandler,
            MountOutputHandler mountOutputHandler)
        {
            getServicesInvoicesHandler.SetSuccessor(getInvoicesHandler);
            getInvoicesHandler.SetSuccessor(getCustomersHandler);
            getCustomersHandler.SetSuccessor(mountOutputHandler);
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.getServicesInvoicesHandler = getServicesInvoicesHandler;
            this.outputPort = outputPort;
        }

        public void Execute(CustomerServicesRequest request)
        {
            try
            {
                request.Logs.Add(new Log("CustomerServicesUseCase", "Starting process", TypeLog.Processing));
                getServicesInvoicesHandler.ProcessRequest(request);
                outputPort.Standard(request.CustomerServices);
            }
            catch (Exception ex)
            {
                request.Logs.Add(new Log("CustomerServicesUseCase", $"Error on get services: {ex.Message} {ex.StackTrace}", TypeLog.Processing));
                outputPort.Error($"{ex.Message} {ex.StackTrace}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
