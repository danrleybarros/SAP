using System;
using System.Threading;
using Autofac;
using MassTransit;

namespace Gcsb.Connect.SAP.ReadJsdnFile
{
    class Program
    {
        private static readonly AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Gcsb.Connect.SAP.ReadJsdnFile started.");

            if (Environment.GetEnvironmentVariable("DEST_LOCAL_PATH") == null)
                throw new ApplicationException("DEST_LOCAL_PATH not configured!");

            Infrastructure.Util.CreateDirectory(Environment.GetEnvironmentVariable("DEST_LOCAL_PATH"));

            var container = ConfigureContainer();         

            var bus = container.Resolve<IBusControl>();

            bus.Start();

            AppDomain.CurrentDomain.ProcessExit += (o, e) =>
            {
                bus.Stop();
                Console.WriteLine("Terminating...");
                autoResetEvent.Set();
            };

            autoResetEvent.WaitOne();

        }

        static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<Infrastructure.Modules.InfrastructureDefaultModule>();
            builder.RegisterModule<Infrastructure.Modules.ApplicationModule>();
            builder.RegisterModule<Infrastructure.PostgresDataAccess.Module>();

            builder.RegisterModule(new MessagingQueue.Infrastructure.MassTransitServices.Module(cfg =>
            {
                cfg.Add(typeof(Consumers.BillFeedConsumer));
                cfg.Add(typeof(Consumers.BillFeedFaultConsumer));
                cfg.Add(typeof(Consumers.PaymentFeedCreditCardConsumer));
                cfg.Add(typeof(Consumers.PaymentFeedCreditCardFaultConsumer));
                cfg.Add(typeof(Consumers.PaymentFeedBoletoConsumer));
                cfg.Add(typeof(Consumers.PaymentFeedBoletoFaultConsumer));
                cfg.Add(typeof(Consumers.ReturnNFConsumer));
                cfg.Add(typeof(Consumers.ReturnNFFaultConsumer));
            }));

            builder.RegisterType<ReadFile>().As<IReadFile>().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
