using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.AllCustomers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.RequestHandlers;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers
{
    public class AllCustomersUseCase : IAllCustomersUseCase
    {
        private readonly GetCustomersHandler getCustomersHandler;
        private readonly IOutputPort<List<AllCustomersOutput>> outputPort;
        private readonly ILogInfrastructure logInfrastructure;

        public AllCustomersUseCase(GetCustomersHandler getCustomersHandler, GetInvoicesHandler getInvoicesHandler, GetStoresHandler getStoresHandler, MountResponseHandler mountResponseHandler, IOutputPort<List<AllCustomersOutput>> outputPort, ILogInfrastructure logInfrastructure)
        {
            getCustomersHandler.SetSucessor(getInvoicesHandler);
            getInvoicesHandler.SetSucessor(getStoresHandler);
            getStoresHandler.SetSucessor(mountResponseHandler);

            this.getCustomersHandler = getCustomersHandler;
            this.outputPort = outputPort;
            this.logInfrastructure = logInfrastructure;
        }

        public void Execute(AllCustomersRequest request)
        {
            try
            {
                getCustomersHandler.ProcessRequest(request);
                outputPort.Standard(request.AllCustomersOutputs);
            }
            catch (Exception ex)
            {
                outputPort.Error(ex.Message);
                logInfrastructure.LogException(ex, $"{GetType().Name} - {ex.Message}");
            }
        }
    }
}
