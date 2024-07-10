using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDispute.RequestHandlers;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDispute
{
    public class CounterchargeDisputeUseCase : ICounterchargeDisputeUseCase
    {
        private readonly IOutputPort<List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute>> outputPort;
        private readonly GetCounterChargeDisputesHandler getCounterChargeDisputesHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public CounterchargeDisputeUseCase(IOutputPort<List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute>> outputPort,
            GetCounterChargeDisputesHandler getCounterChargeDisputesHandler,
            GetInvoiceCycleHandler getInvoiceCicleHandler,
            ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            getCounterChargeDisputesHandler.SetSucessor(getInvoiceCicleHandler);
            this.outputPort = outputPort;
            this.getCounterChargeDisputesHandler = getCounterChargeDisputesHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(CounterchargeDisputeRequest request)
        {
            var logs = new List<Log>();

            try
            {
                logs.Add(new Log("CounterchargeDispute", "Getting CounterchargeDispute with the cycle parameter", Messaging.Messages.Log.Enum.TypeLog.Processing));

                getCounterChargeDisputesHandler.ProcessRequest(request);

                outputPort.Standard(request.CounterchargeDisputes);
            }
            catch (Exception ex)
            {
                logs.Add(new Log("CounterchargeDispute", $"Error on CounterchargeDispute with the cycle parameter: {ex.Message} {ex.StackTrace}", Messaging.Messages.Log.Enum.TypeLog.Processing));
                outputPort.Error($"Error on get data: {ex.Message} {ex.StackTrace}");
            }
            finally
            {
                logWriteOnlyRepository.Add(logs);
            }
        }
    }
}
