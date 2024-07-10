using System;
using System.IO;
using FluentScheduler;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.MoveJsdnFile.Jobs;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;

namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases.ExecuteJob
{
    public class ExecuteJobUsecase : IExecuteJobUseCase
    {
        private readonly string Interfaces;
        private readonly IInterfaceUseCase interfaceUseCase;

        public ExecuteJobUsecase(IInterfaceUseCase interfaceUseCase)
        {
            Interfaces = Environment.GetEnvironmentVariable("INTERFACES"); ;
            this.interfaceUseCase = interfaceUseCase;
        }

        public bool IsJob { get; set; }

        public void DeleteFiles(string pathFiles)
        {
            var di = new DirectoryInfo(pathFiles);

            foreach (FileInfo file in di.GetFiles())
                file.Delete();

            foreach (DirectoryInfo dir in di.GetDirectories())
                dir.Delete(true);
        }

        public void Execute()
        {
            var configs = ReadConfigs();

            foreach (string type in Interfaces.Split("|"))
            {
                if (!string.IsNullOrEmpty(type))
                {
                    if (Enum.TryParse(typeof(TypeRegister), type.ToUpper(), out object typeenum))
                    {
                        if (IsJob)
                            ExecuteJob((TypeRegister)typeenum, configs);
                        else
                            interfaceUseCase.Execute(configs, (TypeRegister)typeenum);
                    }
                }
            }
        }

        public Configs ReadConfigs()
            => Configs.FromJson(File.ReadAllText($"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}interfaces.json"));

        public void SetIsJob(bool isJob)
            => IsJob = isJob;

        private void ExecuteJob(TypeRegister type, Configs configs)
        {
            var debug = Environment.GetEnvironmentVariable("DEBUG");

            if (!string.IsNullOrEmpty(debug))
            {
                DeleteFiles($"{Environment.GetEnvironmentVariable("DEST_LOCAL_PATH")}/");
                DeleteFiles($"{Environment.GetEnvironmentVariable("PROCESS_LOCAL_PATH")}/");
            }

            AddJob(type, configs);
        }

        public void AddJob(TypeRegister type, Configs configs)
        {
            var jobs = new RecurringJobs();
            var interval = int.Parse(Environment.GetEnvironmentVariable("TIME_JOB") ?? "10");

            jobs.ScheduleMethod(() => interfaceUseCase.Execute(configs, type), interval);

            JobManager.UseUtcTime();
            JobManager.Initialize(jobs);
        }
    }
}
