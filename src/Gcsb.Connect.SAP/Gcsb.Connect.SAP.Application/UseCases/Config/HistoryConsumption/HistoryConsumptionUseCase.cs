using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.HistoryConsumption.RequestHandler;
using Gcsb.Connect.SAP.Domain.Config.HistoryConsumption;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.HistoryConsumption
{
    public class HistoryConsumptionUseCase : IHistoryConsumptionUseCase
    {
        private readonly GetBillFeedDataHandler getBillFeedDataHandler;
        private readonly IOutputPort<List<HistoryConsumptionValue>> output;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public HistoryConsumptionUseCase(GetBillFeedDataHandler getBillFeedDataHandler,
            MountConsumptionHistoryHandler mountConsumptionHistoryHandler,
            IOutputPort<List<HistoryConsumptionValue>> output,
            ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            getBillFeedDataHandler.SetSucessor(mountConsumptionHistoryHandler);

            this.getBillFeedDataHandler = getBillFeedDataHandler;
            this.output = output;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(HistoryRequest request)
        {
            try
            {
                getBillFeedDataHandler.ProcessRequest(request);
                output.Standard(request.HistoryConsumptions);
            }
            catch (Exception ex)
            {
                request.AddLog($"Error on billfeeddata with the cycle parameter: {ex.Message} {ex.StackTrace}", TypeLog.Error);
                output.Error($"Error on get data: {ex.Message} {ex.StackTrace}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
