using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute;
using System;
using Serilog;

namespace Gcsb.Connect.SAP.WriteJsdnFile.UseCase.TriggerInterfaces.FAT57
{
    public class TriggerFAT57UseCase : ITriggerFAT57UseCase
    {
        private readonly ICounterchargeDisputeUseCase counterchargeDisputeUseCase;
        private readonly string[] pathFAT57TimeJob;

        public TriggerFAT57UseCase(ICounterchargeDisputeUseCase counterchargeDisputeUseCase)
        {
            this.counterchargeDisputeUseCase = counterchargeDisputeUseCase;
            pathFAT57TimeJob = Environment.GetEnvironmentVariable("TIME_JOB_FAT57").Split(';');
        }

        public void Execute()
        {
            var executeDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, int.Parse(pathFAT57TimeJob[0]));
            var dateTo = executeDate.AddDays(-1);
            var dateFrom = executeDate.AddMonths(-1);

            Log.Information("Job FAT57 - ExecuteDate: {@executeDate} DateFrom: {@dateFrom}, DateTo: {@dateTo}", executeDate, dateFrom, dateTo);

            var request = new CounterchargeDisputeRequest(dateFrom, dateTo);
            counterchargeDisputeUseCase.Execute(request);
        }
    }
}
