using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Autofac;
using Gcsb.Connect.Pkg.Datamart.Application.Contract;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.AllCustomers;
using Gcsb.Connect.SAP.Application.Boundaries.PaymentFeedConsumption;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.Repositories.Pay;
using Gcsb.Connect.SAP.Application.UseCases.Files.Download;
using Gcsb.Connect.SAP.Domain.Config.CustomerService;
using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess;
using Gcsb.Connect.SAP.Tests.Mock;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerServices;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersExpression;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedConsumption;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.Download;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.GetById;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount;

namespace Gcsb.Connect.SAP.Tests.Fixture
{
    public class TestsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            SetVariables();

            builder.RegisterInstance<HttpClient>(new HttpClient(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; },
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            })
            {
                BaseAddress = new Uri(Environment.GetEnvironmentVariable("JSDN_URLV1"))
            });

            builder.RegisterModule<Infrastructure.Modules.ApplicationModule>();
            builder.RegisterModule<Infrastructure.Modules.WebApiModule>();
            builder.RegisterModule<Infrastructure.Modules.InfrastructureDefaultModule>();
            builder.RegisterModule<Infrastructure.MassTransitServices.InMemoryModule>();
            builder.RegisterModule<Infrastructure.ApiClients.Module>();
            builder.RegisterModule<Infrastructure.PostgresDataAccess.Module>();
            builder.RegisterType<Context>().As<Context>().SingleInstance();

            builder.RegisterInstance(new ServicePayMock().Execute().Object).As<IServicePay>();
            builder.RegisterInstance(new JsdnRepositoryMock().Execute().Object).As<IJsdnRepository>();
            builder.RegisterInstance(new GetDatamartResultMock().Execute().Object).As<IDatamartService>();
           


            builder.RegisterType<ManagementFinancialAccountPresenter>().As<Application.Boundaries.ManangementFinancialAccount.IOutputPort>()
                          .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<FinancialAccountGetbyIdPresenter>().As<Application.Boundaries.FinancialAccount.IOutputPort>()
                         .AsSelf().InstancePerLifetimeScope();
            
            builder.RegisterType<InterestAndFineFinancialAccountPresenter>().As<Application.Boundaries.InterestAndFineFinancialAccount.IOutputPort>()
                          .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<CustomersExprPresenter>().As<IOutputPort<List<AllCustomersOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<PaymentFeedPresenter>().As<IOutputPort<List<PaymentFeedOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CustomerServicesPresenter>().As<IOutputPort<List<CustomerService>>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<WebApi.Config.UseCases.CreditGrantedFinancialAccount.Save.SavePresenter>().As<IOutputPort<Guid>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<WebApi.Config.UseCases.CreditGrantedFinancialAccount.GetByStore.GetByStorePresenter>().As<IOutputPort<Application.UseCases.Config.CreditGrantedFinancialAccount.GetByStore.GetByStoreOutput>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<DownloadPresenter>().As<IOutputPort<DownloadOutput>>().AsSelf().InstancePerLifetimeScope();            
        }

        private void SetVariables()
        {
            var path = System.IO.Directory
               .GetParent(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            var strPath = System.IO.Path.Combine(path.FullName, "OutputFiles");

            Environment.SetEnvironmentVariable("OUTPUT_SAP", strPath);
            Environment.SetEnvironmentVariable("EMAIL_NFE", "nfe.digital.br@telefonica.com|nfe.prefeituras.br@telefonica.com");
            Environment.SetEnvironmentVariable("MARKETPLACE", "targettelefonica");
            Environment.SetEnvironmentVariable("MARKETPLACE_USER", "admin-api.jamcracker.com");
            Environment.SetEnvironmentVariable("MARKETPLACE_PASS", "Global@12345");
            Environment.SetEnvironmentVariable("JSDN_URLV1", "https://admin-dev-3.vivoplataformadigital.com.br/api/1.0");
            Environment.SetEnvironmentVariable("DNE_URLV1", "https://int-dev-3.vivoplataformadigital.com.br/dne/api/Dne");
            Environment.SetEnvironmentVariable("SFTP_HOST", "sftp.nfeplace.com.br1");
            Environment.SetEnvironmentVariable("SFTP_PORT", "21");
            Environment.SetEnvironmentVariable("SFTP_USER", "02558157013574");
            Environment.SetEnvironmentVariable("SFTP_PASS", "sftp02558157013574");
            Environment.SetEnvironmentVariable("SFTP_PATH", "\\dados\\vivo77434\\remessa");
            Environment.SetEnvironmentVariable("DEST_LOCAL_PATH", System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())).Replace("\\bin", "\\OutputFiles\\"));
            Environment.SetEnvironmentVariable("FTP_NF", "false");
            Environment.SetEnvironmentVariable("MARKETPLACE_URL", "https://admin-dev-3.vivoplataformadigital.com.br");
            Environment.SetEnvironmentVariable("API_GW_URL", "https://int-dev-3.vivoplataformadigital.com.br");
            Environment.SetEnvironmentVariable("TOKEN_GW_URL", "https://int-dev-3.vivoplataformadigital.com.br/token/api/v2?api-version=2");
            Environment.SetEnvironmentVariable("FINANCIAL_ACCOUNTS_API", "https://int-dev-3.vivoplataformadigital.com.br/financialaccounts");
            Environment.SetEnvironmentVariable("BILL_MAX_DATE", "26");
        }
    }
}
