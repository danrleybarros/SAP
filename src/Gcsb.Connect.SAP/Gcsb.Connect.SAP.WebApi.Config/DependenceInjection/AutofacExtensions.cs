using Autofac;
using Gcsb.Connect.SAP.Domain.Config.HistoryConsumption;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.BillFeedData;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.HistoryConsumption;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedData;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.GetById;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.Services;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerConsumption;
using Gcsb.Connect.SAP.Application.Boundaries.CustomerConsumption;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersConsumption;
using Gcsb.Connect.SAP.Application.Boundaries.CustomersConsumption;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetNotPaidInvoices;
using Gcsb.Connect.SAP.Application.Boundaries.NewPendingInvoices;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersExpression;
using Gcsb.Connect.SAP.Application.Boundaries.AllCustomers;
using Gcsb.Connect.SAP.WebApi.Config.Modules;
using Gcsb.Connect.SAP.Application.Boundaries.PaymentFeedConsumption;
using Gcsb.Connect.SAP.Domain.Config.CustomerService;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CounterchargeDisputeData;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CounterchargeDisputeByInvoice;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetOrdemInterna;
using Gcsb.Connect.SAP.Application.Boundaries.OrdemInterna;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetDetailServiceByInvoice;
using Gcsb.Connect.SAP.Application.Boundaries.GetDetailServiceByInvoice;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.InvoiceDetails;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.AvgOfferConsumption;
using Gcsb.Connect.SAP.Application.Boundaries.AvgOfferConsumption;
using System;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.UploadType;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.Download;
using Gcsb.Connect.SAP.Application.UseCases.Files.Download;
using Gcsb.Connect.SAP.Domain.Upload;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.UploadStatus;
using Gcsb.Connect.SAP.Application.Boundaries.GetUnPaidInvoicesByCustomers;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetUnPaidInvoicesByCustomers;

namespace Gcsb.Connect.SAP.WebApi.Config.DependenceInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<Infrastructure.Modules.InfrastructureDefaultModule>();
            builder.RegisterModule<Infrastructure.Modules.ApplicationModule>();
            builder.RegisterModule<Infrastructure.PostgresDataAccess.Module>();
            builder.RegisterModule<SwagValidationModule>();


            builder.RegisterType<Infraestructure.Services.IdentityParser>().As<Infraestructure.Services.IIdentityParser<UserInfo>>().InstancePerLifetimeScope();
            builder.RegisterType<BillFeedPresenter>().As<IOutputPort<List<BillFeedDoc>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<PaymentFeedPresenter>()
                .As<IOutputPort<List<PaymentBoleto>>>()
                .As<IOutputPort<List<PaymentCreditCard>>>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<HistoryConsumptionPresenter>().As<IOutputPort<List<HistoryConsumptionValue>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ServicesPresenter>().As<IOutputPort<List<ServiceInvoice>>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<ManagementFinancialAccountPresenter>().As<Application.Boundaries.ManangementFinancialAccount.IOutputPort>()
            .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<InterestAndFineFinancialAccountPresenter>().As<Application.Boundaries.InterestAndFineFinancialAccount.IOutputPort>()
            .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<FinancialAccountGetbyIdPresenter>().As<Application.Boundaries.FinancialAccount.IOutputPort>()
             .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<CustomerPresenter>().As<IOutputPort<List<ConsumptionOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CustomersPresenter>().As<IOutputPort<List<CustomersOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<GetNotPaidInvoicesPresenter>().As<IOutputPort<List<NewPendingInvoicesOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CustomersExprPresenter>().As<IOutputPort<List<AllCustomersOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UseCases.FeedData.PaymentFeedConsumption.PaymentFeedPresenter>().As<IOutputPort<List<PaymentFeedOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UseCases.FeedData.GetOpenInvoices.OpenInvoicesPresenter>().As<IOutputPort<List<Application.Boundaries.GetOpenInvoices.InvoiceOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<GetUnPaidInvoicesByCustomersPresenter>().As<IOutputPort<List<InvoicesByDocumentOutput>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UseCases.FeedData.CustomerServices.CustomerServicesPresenter>().As<IOutputPort<List<CustomerService>>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<CounterchargeDisputePresenter>().As<IOutputPort<List<CounterchargeDispute>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CounterchargeDisputeByInvoicePresenter>().As<IOutputPort<List<CounterchargeDisputeInvoice>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<GetOrdemInternaPresenter>().As<IOutputPort<OrdemInternaOutput>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<GetDetailServicePresenter>().As<IOutputPort<GetDetailServiceByInvoiceOutput>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<InvoiceDetailsPresenter>().As<IOutputPort<InvoiceDetailsOutput>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<AvgOfferConsumptionPresenter>().As<IOutputPort<AvgOfferConsumptionOutput>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UseCases.FeedData.AllCustomerInvoices.AllCustomerInvoicesPresenter>().As<IOutputPort<List<Application.Boundaries.AllCustomerInvoices.AllCustomerInvoicesOutput>>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UseCases.FeedData.AllCustomerInvoices.AllCustomerInvoicesPresenter>().As<IOutputPort<List<Application.Boundaries.AllCustomerInvoices.AllCustomerInvoicesOutput>>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UseCases.CreditGrantedFinancialAccount.Save.SavePresenter>().As<IOutputPort<Guid>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UseCases.CreditGrantedFinancialAccount.GetByStore.GetByStorePresenter>().As<IOutputPort<Application.UseCases.Config.CreditGrantedFinancialAccount.GetByStore.GetByStoreOutput>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UseCases.CreditGrantedFinancialAccount.GetAll.GetAllPresenter>().As<IOutputPort<Application.UseCases.Config.CreditGrantedFinancialAccount.GetAll.GetAllOutput>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UseCases.FeedData.InvoiceDetails.InvoiceDetailsPresenter>().As<IOutputPort<InvoiceDetailsOutput>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UploadTypePresenter>().As<IOutputPort<List<Domain.UploadTypeDto.UploadTypeDto>>>().AsSelf().InstancePerLifetimeScope();
            
            builder.RegisterType<DownloadPresenter>().As<IOutputPort<DownloadOutput>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<StatusPresenter>().As<IOutputPort<List<UploadStatusDto>>>().AsSelf().InstancePerLifetimeScope();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            
            return builder;
        }
    }
}

