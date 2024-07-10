using System;
using Gcsb.Connect.SAP.Application.UseCases.Lei1601;
using Serilog;

namespace Gcsb.Connect.SAP.WriteJsdnFile.UseCase.TriggerInterfaces.Lei1601
{
    public class TriggerLei1601UseCase : ITriggerLei1601UseCase
    {
        private readonly ILei1601UseCase lei1601UseCase;

        public TriggerLei1601UseCase(ILei1601UseCase lei1601UseCase)
        {
            this.lei1601UseCase = lei1601UseCase;
        }

        public void Execute()
        {          
            var executeDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            var dateTo = executeDate;
            var dateFrom = executeDate.AddDays(-1);

            Log.Information("Job Lei1601 - ExecuteDate: {@executeDate} DateFrom: {@dateFrom}, DateTo: {@dateTo}", executeDate, dateFrom, dateTo);

            lei1601UseCase.Execute(new Application.UseCases.Lei1601.Lei1601Request
            {
                ProcessDate = DateTime.UtcNow,
                ReferenceDate = DateTime.UtcNow.AddDays(-1),
                Sequence = 1
            });
        }

    }
}
