using FluentScheduler;
using System;

namespace Gcsb.Connect.SAP.MoveJsdnFile.Jobs
{
    public class RecurringJobs : Registry
    {
        public void ScheduleMethod(Action method, int time)
            => Schedule(method).ToRunNow().AndEvery(time).Minutes();
    }
}
