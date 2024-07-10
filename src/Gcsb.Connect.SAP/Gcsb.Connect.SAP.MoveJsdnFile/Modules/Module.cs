using Autofac;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.MoveJsdnFile.Infraestructure.Service;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;
using Gcsb.Connect.SAP.MoveJsdnFile.UseCases;
using Gcsb.Connect.SAP.MoveJsdnFile.UseCases.All;
using Gcsb.Connect.SAP.MoveJsdnFile.UseCases.BillFeed;
using Gcsb.Connect.SAP.MoveJsdnFile.UseCases.ExecuteJob;
using Gcsb.Connect.SAP.MoveJsdnFile.UseCases.PaymentFeed;
using Gcsb.Connect.SAP.MoveJsdnFile.UseCases.ReturnNF;

namespace Gcsb.Connect.SAP.MoveJsdnFile.Modules
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes()
                .AsImplementedInterfaces()
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<DownloadService>().As<IDownloadService>().InstancePerLifetimeScope();
            builder.RegisterType<ConnectionInformation>().As<IConnectionInformation>().InstancePerLifetimeScope();
            builder.RegisterType<MassTransitService>().As<IMassTransitService>().InstancePerLifetimeScope();
            builder.RegisterType<InterfaceUseCase>().As<IInterfaceUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ExecuteJobUsecase>().As<IExecuteJobUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ProcessFile>().As<IProcessFile>().InstancePerLifetimeScope();
            builder.RegisterType<BillFeedCsvUseCase>().Keyed<IDownloadFilesUseCase>(TypeRegister.BILL).InstancePerLifetimeScope();
            builder.RegisterType<PaymentFeedTsvUseCase>().Keyed<IDownloadFilesUseCase>(TypeRegister.PAYMENT);
            builder.RegisterType<PaymentFeedBoletoTsvUseCase>().Keyed<IDownloadFilesUseCase>(TypeRegister.PAYMENTBOLETO);
            builder.RegisterType<ReturnNFCsvUseCase>().Keyed<IDownloadFilesUseCase>(TypeRegister.RETURNNF);
            builder.RegisterType<AllFilesUseCase>().Keyed<IDownloadFilesUseCase>(TypeRegister.ALL);
        }
    }
}
