using System;
using FluentScheduler;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.WriteJsdnFile.UseCase.TriggerInterfaces.FAT57;
using Gcsb.Connect.SAP.WriteJsdnFile.UseCase.TriggerInterfaces.Lei1601;

namespace Gcsb.Connect.SAP.WriteJsdnFile.UseCase.ExecuteJob
{
    public class ExecuteJobUsecase : IExecuteJobUseCase
    {
        private readonly ITriggerFAT57UseCase triggerFAT57UseCase;
        private readonly ITriggerLei1601UseCase triggerLei1601UseCase;

        public ExecuteJobUsecase(ITriggerFAT57UseCase triggerFAT57UseCase, ITriggerLei1601UseCase triggerLei1601UseCase)
        {
            this.triggerFAT57UseCase = triggerFAT57UseCase;
            this.triggerLei1601UseCase = triggerLei1601UseCase;
        }

        public bool IsJob { get; set; }

        public void Execute()
        {
            if (IsJob)
            {
                AddJobFAT57();
                AddJobLei1601();
            }
        }

        private void AddJobLei1601()
        {
            if (ValidateEnvironment())
            {
                var pathLei1601TimeJob = Environment.GetEnvironmentVariable("TIME_JOB_Lei1601").Split(';');
                var registry = new Registry();
                var day = int.Parse(pathLei1601TimeJob[0]);
                var hour = int.Parse(pathLei1601TimeJob[1]);
                var minute = int.Parse(pathLei1601TimeJob[2]);

                registry.Schedule(() => triggerLei1601UseCase.Execute())
                    .ToRunNow()
                    .AndEvery(1)
                    .Days()
                    .At(hour, minute);

                JobManager.UseUtcTime();
                JobManager.Initialize(registry);
            }
        }

        public void AddJobFAT57()
        {
            if (ValidateEnvironment())
            {
                var pathFAT57TimeJob = Environment.GetEnvironmentVariable("TIME_JOB_FAT57").Split(';');

                var registry = new Registry();
                var day = int.Parse(pathFAT57TimeJob[0]);
                var hour = int.Parse(pathFAT57TimeJob[1]);
                var minute = int.Parse(pathFAT57TimeJob[2]);

                registry.Schedule(() => triggerFAT57UseCase.Execute())
                    .ToRunEvery(1)
                    .Months()
                    .On(day)
                    .At(hour, minute);

                JobManager.UseUtcTime();
                JobManager.Initialize(registry);
            }
        }

        public void SetIsJob(bool isJob)
          => IsJob = isJob;

        private bool ValidateEnvironment()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("TIME_JOB_FAT57")))
            {
                Log.CreateProcessingLog("LEI1601", "Environment must not be empty TIME_JOB_FAT57");
                return false;
            }

            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("TIME_JOB_Lei1601")))
            {
                Log.CreateProcessingLog("LEI1601", "Environment must not be empty TIME_JOB_FAT57");
                return false;
            }

            return true;
        }
    }
}
