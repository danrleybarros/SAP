using Autofac;
using FluentScheduler;
using Gcsb.Connect.Pkg.Serilog.Implementation;
using Gcsb.Connect.SAP.WriteJsdnFile.UseCase.ExecuteJob;
using MassTransit;
using Serilog;
using System;
using System.Threading;

namespace Gcsb.Connect.SAP.WriteJsdnFile
{
    class Program
    {

        private static readonly AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Gcsb.Connect.SAP.WriteJsdnFile started.");

            var container = ConfigureContainer();
            var executeJob = container.Resolve<IExecuteJobUseCase>();
            var bus = container.Resolve<IBusControl>();

            var log_conn = Environment.GetEnvironmentVariable("POSTGRES_LOG_CONN") ?? Environment.GetEnvironmentVariable("DBCONN");

            Log.Logger = new Logger().ConfigureLogger(log_conn, "saplog", "log");
            Log.Information("Starting WriteJsdnFile");        

            executeJob.SetIsJob(true);
            executeJob.Execute();

            bus.Start();

            AppDomain.CurrentDomain.ProcessExit += (o, e) =>
            {
                bus.Stop();
                JobManager.StopAndBlock();
                Console.WriteLine("Terminating...");
                autoResetEvent.Set();
            };

            autoResetEvent.WaitOne();

        }

        static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<Modules.Module>();
            builder.RegisterModule<Infrastructure.Modules.InfrastructureDefaultModule>();
            builder.RegisterModule<Infrastructure.Modules.ApplicationModule>();
            builder.RegisterModule<Infrastructure.PostgresDataAccess.Module>();
            builder.RegisterModule(new MessagingQueue.Infrastructure.MassTransitServices.Module(cfg =>
            {
                cfg.Add(typeof(Consumers.BillConsumer));
                cfg.Add(typeof(Consumers.BillFaultConsumer));
                cfg.Add(typeof(Consumers.ARRBoletoConsumer));
                cfg.Add(typeof(Consumers.ARRBoletoFaultConsumer));
                cfg.Add(typeof(Consumers.ARRBoletoIntercompanyConsumer));
                cfg.Add(typeof(Consumers.ARRBoletoIntercompanyFaultConsumer));
                cfg.Add(typeof(Consumers.ARRCreditCardConsumer));
                cfg.Add(typeof(Consumers.ARRCreditCardFaultConsumer));
                cfg.Add(typeof(Consumers.ARRCreditCardIntercompanyConsumer));
                cfg.Add(typeof(Consumers.ARRCreditCardIntercompanyFaultConsumer));
                cfg.Add(typeof(Consumers.PASConsumer));
                cfg.Add(typeof(Consumers.PASFaultConsumer));
                cfg.Add(typeof(Consumers.ISIConsumer));
                cfg.Add(typeof(Consumers.ISIFaultConsumer));
                cfg.Add(typeof(Consumers.ItemsConsumer));
                cfg.Add(typeof(Consumers.ItemsFaultConsumer));
                cfg.Add(typeof(Consumers.CISSConsumer));
                cfg.Add(typeof(Consumers.CISSFaultConsumer));
                cfg.Add(typeof(Consumers.ClientConsumer));
                cfg.Add(typeof(Consumers.ClientFaultConsumer));
                cfg.Add(typeof(Consumers.MasterConsumer));
                cfg.Add(typeof(Consumers.MasterFaultConsumer));
                cfg.Add(typeof(Consumers.AXILIARYBOOKConsumer));
                cfg.Add(typeof(Consumers.AXILIARYBOOKFaultConsumer));
                cfg.Add(typeof(Consumers.CriticalFileConsumer));
                cfg.Add(typeof(Consumers.CriticalFileFaultConsumer));

            }));

            builder.RegisterType<ReadFile>().As<IReadFile>().InstancePerLifetimeScope();
            return builder.Build();
        }
    }
}
