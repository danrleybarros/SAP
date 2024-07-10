using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDisputeByInvoices.RequestHandlers;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDisputeByInvoices
{
    public class CounterchargeDisputeByInvoicesUseCase : ICounterchargeDisputeByInvoicesUseCase
    {
        private readonly IOutputPort<List<CounterchargeDisputeInvoice>> outputPort;
        private readonly GetCounterChargeDisputesHandler getCounterChargeDisputesHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public CounterchargeDisputeByInvoicesUseCase(IOutputPort<List<CounterchargeDisputeInvoice>> outputPort,
            GetCounterChargeDisputesHandler getCounterChargeDisputesHandler,
            GetInvoiceCycleHandler getInvoiceCycleHandler,
            IJsdnRepository jsdnRepository,
            ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            getCounterChargeDisputesHandler.SetSucessor(getInvoiceCycleHandler);
            this.outputPort = outputPort;
            this.getCounterChargeDisputesHandler = getCounterChargeDisputesHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(CounterchargeDisputeByInvoicesRequest request)
        {
            var logs = new List<Log>();

            try
            {
                logs.Add(new Log("CounterchargeDispute", "Getting CounterchargeDispute by InvoicesNumber parameter", Messaging.Messages.Log.Enum.TypeLog.Processing));

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
