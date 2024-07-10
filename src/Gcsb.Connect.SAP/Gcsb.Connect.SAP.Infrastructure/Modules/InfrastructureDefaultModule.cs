using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Pay;
using System;
using System.Net.Http;
using Gcsb.Connect.Pkg.Serilog.Implementation;
using Gcsb.Connect.Pkg.Serilog.Contract;
using Gcsb.Connect.SAP.Infrastructure.Utils;
using Gcsb.Connect.SAP.Infrastructure.ServicesClients.Stores;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFine;
using Gcsb.Connect.SAP.Infrastructure.ApiClients.InterestAndFine;
using Gcsb.Connect.SAP.Infrastructure.Download;
using Gcsb.Connect.SAP.Application.Repositories.Download;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.DynamicSearch;
using Microsoft.EntityFrameworkCore;
using Gcsb.Connect.Pkg.Datamart.Application.Implementation;
using Gcsb.Connect.Pkg.Datamart.Application.Contract;

namespace Gcsb.Connect.SAP.Infrastructure.Modules
{
    public class InfrastructureDefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register all Types 
            //
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .AsImplementedInterfaces()
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CsvConvert.BillFeedConvert).Assembly)
                .Where(type => type.Namespace.Contains("CsvConvert"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(TextFile.MakeTextFile).Assembly)
                .Where(type => type.Namespace.Contains("TextFile"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(FileConvert.TsvConvert.PaymentFeedConvert).Assembly)
                .Where(type => type.Namespace.Contains("FileConvert.TsvConvert"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ApiClients.GF.DNEClient).Assembly)
                .Where(type => type.Namespace.Contains("ApiClients.GF"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(FtpFile.GF.FtpFileUpload).Assembly)
                .Where(type => type.Namespace.Contains("FtpFile.GF"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("MassTransitServices"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ApiClients.JsdnServices.JsdnClient).Assembly)
                .Where(type => type.Namespace.Contains("ApiClients.JsdnServices"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApiClients.FinancialAccounts.FinancialAccountsClient>().As<IFinancialAccountsClient>();
            builder.RegisterType<ApiClients.Pay.ServicePay>().As<IServicePay>();
            builder.RegisterType<ApiClients.Services>().As<IService>();
            builder.RegisterType<HttpClient>().As<HttpClient>().SingleInstance();
            builder.RegisterType<JsdnStoreService>().As<IJsdnStoreService>().AsImplementedInterfaces().AsSelf();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(IPaymentFeedConvertRepository<>)).AsImplementedInterfaces();

            builder.RegisterType<LogRequest>().As<ILogRequest>().InstancePerLifetimeScope();
            builder.RegisterType<LogInfrastructure>().As<ILogInfrastructure>().InstancePerLifetimeScope();

            builder.RegisterType<InterestAndFineClient>().As<IInterestAndFineRepository>();
            
            builder.RegisterType<DownloadService>().As<IDownloadService>();

            builder.RegisterModule(new MessagingQueue.Infrastructure.MassTransitServices.Module());
            builder.RegisterGeneric(typeof(DynamicRepository<>)).As(typeof(IDynamicRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<GetDatamartResult>().As<IGetDatamartResult>().InstancePerLifetimeScope();

            var conn = Environment.GetEnvironmentVariable("SAP_INT_CONN") ?? Environment.GetEnvironmentVariable("DBCONN");

            if (!string.IsNullOrEmpty(conn))
            {
                using var context = new PostgresDataAccess.Context();
                context.Database.Migrate();
            }
        }
    }
}
