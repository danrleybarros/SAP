using Autofac;
using FluentScheduler;
using Gcsb.Connect.Pkg.Serilog.Implementation;
using Gcsb.Connect.SAP.Infrastructure.Modules;
using Gcsb.Connect.SAP.MoveJsdnFile.Consumers;
using Gcsb.Connect.SAP.MoveJsdnFile.Infraestructure.Service;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;
using Gcsb.Connect.SAP.MoveJsdnFile.Moq;
using Gcsb.Connect.SAP.MoveJsdnFile.UseCases.ExecuteJob;
using MassTransit;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Gcsb.Connect.SAP.MoveJsdnFile
{
    class Program
    {
        private static readonly AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            var container = RegisterContainers();
            var bus = container.Resolve<IBusControl>();
            var executeJob = container.Resolve<IExecuteJobUseCase>();

            var log_conn = Environment.GetEnvironmentVariable("POSTGRES_LOG_CONN") ?? Environment.GetEnvironmentVariable("DBCONN");

            Log.Logger = new Logger().ConfigureLogger(log_conn, "saplog", "log");
            Log.Information("Gcsb.Connect.SAP.MoveJsdnFile started");

            CreateDirectories();

            bus.Start();

            executeJob.SetIsJob(true);
            executeJob.Execute();

            AppDomain.CurrentDomain.ProcessExit += (o, e) =>
            {
                bus.Stop();
                JobManager.StopAndBlock();
                Console.WriteLine("Terminating...");
                autoResetEvent.Set();
            };

            autoResetEvent.WaitOne();
        }

        private static void CreateDirectories()
        {
            var configs = Configs.FromJson(File.ReadAllText($"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}interfaces.json"));

            foreach (var item in configs.Interfaces.Where(i => i.Type != "RETURNNF"))
            {
                Infrastructure.Util.CreateDirectory(item.Source);
                Infrastructure.Util.CreateDirectory(item.Process);
                Infrastructure.Util.CreateDirectory(item.Dest);
            }
        }

        private static IContainer RegisterContainers()
        {
            var builder = new ContainerBuilder();
            var moq = bool.Parse(Environment.GetEnvironmentVariable("SFTP_MOCK") ?? "true");
            var downloadservice = moq ? typeof(DownloadServiceMoq) : typeof(DownloadService);

            builder.RegisterModule<Modules.Module>();
            builder.RegisterModule<InfrastructureDefaultModule>();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<Infrastructure.PostgresDataAccess.Module>();
            builder.RegisterType(downloadservice).As<IDownloadService>().AsImplementedInterfaces().AsSelf();

            builder.RegisterModule(new MessagingQueue.Infrastructure.MassTransitServices.Module(cfg =>
            {
                cfg.Add(typeof(DeleteFileConsumer));
                cfg.Add(typeof(DeleteFileFaultConsumer));
            }));

            return builder.Build();
        }
    }
}
