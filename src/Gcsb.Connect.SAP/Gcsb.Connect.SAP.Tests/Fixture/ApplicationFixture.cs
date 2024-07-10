using Autofac;
using AutoMapper;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.AllCustomers;
using Gcsb.Connect.SAP.Application.Boundaries.PaymentFeedConsumption;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.Repositories.Pay;
using Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetAll;
using Gcsb.Connect.SAP.Domain.Config.CustomerService;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using Gcsb.Connect.SAP.Tests.Builders.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Mock;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.CreditGrantedFinancialAccount.GetAll;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerServices;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersExpression;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedConsumption;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.GetById;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.UploadType;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Gcsb.Connect.SAP.Application.Repositories.Download;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.UploadStatus;
using Gcsb.Connect.SAP.Domain.Upload;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.Pkg.Datamart.Application.Contract;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;

// Set the orderer
[assembly: TestCollectionOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.DisplayNameOrderer", "Gcsb.Connect.SAP.Tests")]

// Need to turn off test parallelization so we can validate the run order
[assembly: CollectionBehavior(DisableTestParallelization = true)]
//[Collection("Name of Collection Order by Aphabet")]

namespace Gcsb.Connect.SAP.Tests.Fixture
{
    public class ApplicationFixture
    {
        public IContainer Container { get; private set; }

        public ApplicationFixture()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<TestsModule>();

            RegisterModule(builder);
            AddMock(builder);
            RegisterPresenter(builder);


            Container = builder.Build();

            Feed();
        }

        private void Feed()
        {
            IMapper mapper = Container.Resolve<IMapper>();

            var context = new Context();
            context.Database.EnsureCreated();

            ContextInitializer.Seed(context);
            if (context.File.Any())
                return;

            Guid idPayment = new Guid("4f7d07bc-c36e-4530-9c18-436cde991eb6");
            Guid idARR = new Guid("7a8c5901-1f3c-43e4-94bb-91c565c8a95a");

            var files = new List<File>()
            {
                new File(idPayment, "PaymentFeed", TypeRegister.PAYMENT, DateTime.Now, Status.Success, new List<Log>() { new Log("servicecode1", "Message Sucess", TypeLog.Processing )}),
                new File(idARR, idPayment, "ARR21TB29190001", TypeRegister.ARR, DateTime.Now, Status.Error, new List<Log>(){ new Log("servicecode1", idPayment, "Message Error",new List<LogDetail>(), TypeLog.Error, "Stack Trace")})
            };

            context.File.AddRange(mapper.Map<List<Infrastructure.PostgresDataAccess.Entities.File>>(files));

            context.SaveChanges();
        }

        private void RegisterModule(ContainerBuilder builder)
        {
            builder.RegisterModule<Infrastructure.Modules.ApplicationModule>();
            builder.RegisterModule<Infrastructure.Modules.WebApiModule>();
            builder.RegisterModule<Infrastructure.Modules.InfrastructureDefaultModule>();
            builder.RegisterModule<Infrastructure.MassTransitServices.InMemoryModule>();
            builder.RegisterModule<Infrastructure.ApiClients.Module>();
            builder.RegisterModule<Infrastructure.PostgresDataAccess.Module>();
            builder.RegisterType<Context>().As<Context>().SingleInstance();
            builder.RegisterType<IdentityParser>().As<IIdentityParser<UserInfo>>().AsSelf().InstancePerLifetimeScope();

        }

        private void AddMock(ContainerBuilder builder)
        {
            builder.RegisterInstance(new ServicePayMock().Execute().Object).As<IServicePay>();
            builder.RegisterInstance(new JsdnRepositoryMock().Execute().Object).As<IJsdnRepository>();
            builder.RegisterInstance(new StoresMock().GetStoresMoq().Object).As<IJsdnStoreService>();
            builder.RegisterInstance(new DneMock().GetLocalizationMock().Object).As<IDne>();
            builder.RegisterInstance(new DigitalCertificateMock().Execute().Object).As<IDigitalCertificateRepository>();            
            builder.RegisterInstance(new HttpContextMock().Execute().Object).As<HttpContext>();
            builder.RegisterInstance(new DownloadServiceMock().Execute().Object).As<IDownloadService>();
            builder.RegisterInstance(new UploadStatusMock().Execute().Object).As<IUploadReadOnlyRepository>();
            builder.RegisterInstance(new DynamicServiceMock().Execute().Object).As<IDynamicService>();
            builder.RegisterInstance(new GetDatamartResultMock().Execute().Object).As<IDatamartService>();
            builder.RegisterInstance(new FinancialAccountsMock().Execute().Object).As<IFinancialAccountsClient>();
            builder.RegisterInstance(new JsdnClientMock().Execute().Object).As<IJsdnService>();

        }

        private void RegisterPresenter(ContainerBuilder builder)
        {
            builder.RegisterType<ManagementFinancialAccountPresenter>().As<Application.Boundaries.ManangementFinancialAccount.IOutputPort>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<FinancialAccountGetbyIdPresenter>().As<Application.Boundaries.FinancialAccount.IOutputPort>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CustomersExprPresenter>().As<IOutputPort<List<AllCustomersOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<PaymentFeedPresenter>().As<IOutputPort<List<PaymentFeedOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CustomerServicesPresenter>().As<IOutputPort<List<CustomerService>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<GetAllPresenter>().As<IOutputPort<GetAllOutput>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UploadTypePresenter>().As<IOutputPort<List<Domain.UploadTypeDto.UploadTypeDto>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<StatusPresenter>().As<IOutputPort<List<UploadStatusDto>>>().AsSelf().InstancePerLifetimeScope();
            
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

        public static List<ServiceBuilder> ServiceInvoices => new List<ServiceBuilder>
            {
                ServiceBuilder.New().WithServiceCode("azuremonth").WithServiceName("Azure"),
                ServiceBuilder.New().WithServiceCode("azuremonth").WithServiceName("Azure"),
                ServiceBuilder.New().WithServiceCode("windowsyear").WithServiceName("Windows")
            };

        public static List<Invoice> Invoices(string invoicePrefix) => new List<Invoice>
            {
                InvoiceBuilder.New().WithInvoiceNumber($"{invoicePrefix}1")
                .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0001").Build()).WithIndividualInvoice("S").Build())
                .WithServices(ServiceInvoices.Select(i=> i.Build()).ToList())
                .Build(),

                InvoiceBuilder.New().WithInvoiceNumber($"{invoicePrefix}2")
                .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0002").Build()).WithIndividualInvoice("S").Build())
                .WithServices(ServiceInvoices.Select(i=> i.Build()).ToList())
                .Build(),
            };

        public static List<Customer> Customers(Guid idFile, string invoicePrefix) => new List<Customer>
            {

                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New()
                    .WithIdFile(idFile)
                    .WithInvoiceNumber($"{invoicePrefix}1")
                    .WithServices( ServiceInvoices.Select(i=> i.Build()).ToList()).Build())
                    .WithIndividualInvoice("S").Build(),
                 CustomerBuilder.New().WithInvoice(InvoiceBuilder.New()
                    .WithIdFile(idFile)
                    .WithInvoiceNumber($"{invoicePrefix}2")
                    .WithServices( ServiceInvoices.Select(i=> i.Build()).ToList()).Build())
                    .WithIndividualInvoice("S").Build(),
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New()
                    .WithIdFile(idFile)
                    .WithInvoiceNumber($"{invoicePrefix}3")
                    .WithServices( ServiceInvoices.Select(i=> i.Build()).ToList()).Build())
                    .WithIndividualInvoice("N").Build(),
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New()
                    .WithIdFile(idFile)
                    .WithInvoiceNumber($"{invoicePrefix}4")
                    .WithServices( ServiceInvoices.Select(i=> i.Build()).ToList()).Build())
                    .WithIndividualInvoice("N").Build()
            };

        static string[] services = new string[] { "AzureActiveDirectoryPremiumP2", "Dynamics365AIforSales", "dynamics365forcustomerserviceprofessional",
            "dynamics365forfieldservicedevice", "dynamics365formarketing", "OneDriveforBusinessPlan1", "EnterpriseMobilitySecurityE3",
            "EnterpriseMobilitySecurityE5", "Microsoft365E5", "dynamics365forsalesprofessional", "dynamics365layout", "Dynamics365Plan",
            "Dynamics365RemoteAssist", "Office365ProPlus", "Office65Business", "Office365F1", "Office365EnterpriseE5",
            "Office365EnterpriseE3", "MeetingRoom", "MicrosoftPowerAppsPlan2", "office365be", "office356bp", "Office365EnterpriseE1",
            "OneDriveforBusinessPlan2", "azureactivedirectorypremiumP1", "Dynamics365UnifiedOperationsDevice", "Dynamics365UnifiedOperationsPlan",
            "Microsoft365Business", "Microsoft365F1", "MicrosoftIntuneDevice", "projectonlinepremium", "sharepointonlineplan2", "PowerBIPremiumP2",
            "AzureActiveDirectoryBasic", "windows10enterprisee3", "sharepointonlineplan1", "PowerBIPremiumP5", "skypeforbusinessonlineplan2",
            "PowerBIPremiumP3", "MSintune", "AzureInformationProtectionPlan1", "MicrosoftPowerAppsPlan1", "visioonlineplan2", "Office365AdvancedThreatProtectionP2",
            "ExchangeOnlinePlan2", "Microsoft365E3", "Office365BusinessPremium", "ExchangeOnlineProtection", "ExchangeOnlinePlan1",
            "office365advancedcompliance", "dynamics365forprojectserviceautomation", "AzureInformationProtectionPremiumP2" };

        public static IEnumerable<Domain.Config.FinancialAccount> FinancialsAccounts => services.Select(item => FinancialAccountBuilder.New().WithIdFinancialAccount(Guid.NewGuid()).WithServiceCode(item).Build());

        public static Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount ManagementFinancialsAccount() => ManagementFinancialAccountBuilder.New().Build();


        public static void ClearCreditGrantedFinancialAccounts()
        {
            var context = new Context();
            context.Database.EnsureCreated();
            context.CreditGrantedFinancialAccount.RemoveRange(context.CreditGrantedFinancialAccount);
            context.SaveChanges();
        }
    }
}
