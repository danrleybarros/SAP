using System;
using System.Collections.Generic;
using Autofac;
using Gcsb.Connect.Pkg.Datamart.Application.Contract;
using Gcsb.Connect.Pkg.Datamart.Application.Implementation;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions;
using Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper;
using Gcsb.Connect.SAP.Application.UseCases.FAT;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Deferral;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Deferral.Billed;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Deferral.Provision;
using Gcsb.Connect.SAP.Application.UseCases.File.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.Files.UploadType;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed;
using Gcsb.Connect.SAP.Domain.Config.PaymentFeed;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Infrastructure.SearchExpression;
using Gcsb.Connect.SAP.Infrastructure.SearchExpression.Expression;
using Gcsb.Connect.SAP.Infrastructure.Upload;

namespace Gcsb.Connect.SAP.Infrastructure.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Gcsb.Connect.SAP.Application
            //
            builder.RegisterAssemblyTypes(typeof(Application.ApplicationException).Assembly)
                .AsImplementedInterfaces()
                .AsSelf().InstancePerDependency();

            builder
                .RegisterGeneric(typeof(SaveFileHandler<>))
                .As(typeof(ISaveFileHandler<>))
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(GenerateOutputHandler<>))
                .As(typeof(IGenerateOutputHandler<>))
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(FileReprocess<>))
                .As(typeof(IFileReprocess<>))
                .InstancePerDependency();

            builder
                .RegisterType(typeof(FATaFaturarACM))
                .AsImplementedInterfaces().AsSelf()
                .InstancePerDependency();

            builder
                .RegisterType(typeof(FATaFaturarECM))
                .AsImplementedInterfaces().AsSelf()
                .InstancePerDependency();

            builder
                .RegisterType(typeof(FATFaturado))
                .AsImplementedInterfaces().AsSelf()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(ISaveFATHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(IGenerateFileHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder
                .RegisterGeneric(typeof(PaymentFeedUseCase<>))
                .As(typeof(IPaymentFeedUseCase<>))
                .InstancePerDependency();

            var acg = AppDomain.CurrentDomain.GetAssemblies();

            #region Payment            
            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers.IConvertHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers.ISaveDocsHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers.IInsertQueueHandler<>)).InstancePerDependency().AsImplementedInterfaces();
            #endregion

            #region ARR
            builder
                .RegisterGeneric(typeof(Application.UseCases.ARR.ARRRequest<>))
                .As(typeof(Application.UseCases.ARR.IRequestHandlers.IARRRequest<>))
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(Application.UseCases.ARR.ARRUseCase<>))
                .As(typeof(Application.UseCases.ARR.IRequestHandlers.IARRUseCase<>))
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.ARR.IRequestHandlers.IAccountsHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.ARR.IRequestHandlers.IGenerateFileHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.ARR.IRequestHandlers.IIdentificationRegisterHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.ARR.IRequestHandlers.IInsertQueueHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.ARR.IRequestHandlers.ILaunchHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.ARR.IRequestHandlers.ISaveFileHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.ARR.IRequestHandlers.ISequenceHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.ARR.IRequestHandlers.IServicesHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.ARR.IRequestHandlers.IGetAccountingEntryHandler<>)).InstancePerDependency().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(acg)
                .AsClosedTypesOf(typeof(Application.UseCases.ARR.IRequestHandlers.IGetPaymetFeedHandler<>)).InstancePerDependency().AsImplementedInterfaces();
            #endregion

            builder.RegisterType<Application.UseCases.Config.PaymentFeed.Cycle.Boleto.PaymentFeedDataUseCase>().Keyed<IPaymentFeedDataUseCase>(FileType.Boleto);
            builder.RegisterType<Application.UseCases.Config.PaymentFeed.Cycle.Credit.PaymentFeedDataUseCase>().Keyed<IPaymentFeedDataUseCase>(FileType.Credit);

            builder.RegisterType<Application.UseCases.Config.PaymentFeed.Transaction.Boleto.PaymentFeedDataUseCase>().Keyed<IPaymentFeedDataTransactionUseCase>(FileType.Boleto);
            builder.RegisterType<Application.UseCases.Config.PaymentFeed.Transaction.Credit.PaymentFeedDataUseCase>().Keyed<IPaymentFeedDataTransactionUseCase>(FileType.Credit);

            builder.RegisterType<CnpjExpression>().Keyed<Expression>(TypeSearch.Cnpj);
            builder.RegisterType<CustomerCodeExpression>().Keyed<Expression>(TypeSearch.CustomerCode);
            builder.RegisterType<CustomerNameExpression>().Keyed<Expression>(TypeSearch.CustomerName);
            builder.RegisterType<ExpressionFactory>().As<IExpressionFactory>().InstancePerLifetimeScope();

            builder.RegisterType<ChargeBackTotalNotUsed>().Keyed<IChargeBackStrategy>(ChargeBackType.TotalNotUsed);
            builder.RegisterType<ChargeBackTotalUsed>().Keyed<IChargeBackStrategy>(ChargeBackType.TotalUsed);
            builder.RegisterType<ChargeBackPartiallUsed>().Keyed<IChargeBackStrategy>(ChargeBackType.PartialUsed);
            builder.RegisterType<ChargeBackDebtGranted>().Keyed<IChargeBackStrategy>(ChargeBackType.DebtGranted);
            builder.RegisterType<ChargeBackRectifiedBoleto>().Keyed<IChargeBackStrategy>(ChargeBackType.RetifiedBoleto);

            builder.RegisterType<Application.UseCases.FAT.Helper.ChargeBackTotalNotUsed>().Keyed<Application.UseCases.FAT.Helper.IChargeBackStrategy>(Application.UseCases.FAT.Helper.ChargeBackType.TotalNotUsed);
            builder.RegisterType<Application.UseCases.FAT.Helper.ChargeBackTotalUsed>().Keyed<Application.UseCases.FAT.Helper.IChargeBackStrategy>(Application.UseCases.FAT.Helper.ChargeBackType.TotalUsed);
            builder.RegisterType<Application.UseCases.FAT.Helper.ChargeBackDebtGranted>().Keyed<Application.UseCases.FAT.Helper.IChargeBackStrategy>(Application.UseCases.FAT.Helper.ChargeBackType.DebtGranted);
            builder.RegisterType<Application.UseCases.FAT.Helper.ChargeBackRectifiedBoleto>().Keyed<Application.UseCases.FAT.Helper.IChargeBackStrategy>(Application.UseCases.FAT.Helper.ChargeBackType.RetifiedBoleto);

            builder.RegisterType(typeof(UploadService)).As(typeof(IUploadService)).InstancePerDependency();
            builder.RegisterType<GetUploadTypeUseCase>().As<IGetUploadTypeUseCase>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<GetDatamartResult>().As<IGetDatamartResult>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<DeferralManager>().As<IDeferralStrategy>();
            builder.RegisterType<ShortTermInitialDeferralNFEmittedActivatedService>().Keyed<IDeferralStrategy>(DeferralType.ShortTermInitialDeferralNFEmittedActivatedService);
            builder.RegisterType<ShortTermInProgressDeferralNFEmittedWithServiceActivation>().Keyed<IDeferralStrategy>(DeferralType.ShortTermRecurringDeferralNFEmittedWithServiceActivation);
            builder.RegisterType<ShortTermInitialDeferralNFEmittedNotActivatedService>().Keyed<IDeferralStrategy>(DeferralType.ShortTermInitialDeferralNFEmittedNotActivatedService);
            builder.RegisterType<ShortTermRecurringDeferralNFEmittedActivatedService>().Keyed<IDeferralStrategy>(DeferralType.ShortTermRecurringDeferralNFEmittedActivatedService);
            builder.RegisterType<ShortTermInitialDeferralNFEmittedActivatedServiceWithDiscount>().Keyed<IDeferralStrategy>(DeferralType.ShortTermInitialDeferralNFEmittedActivatedServiceWithDiscount);
            builder.RegisterType<LongTermInitialDeferralNFEmittedActivatedService>().Keyed<IDeferralStrategy>(DeferralType.LongTermInitialDeferralNFEmittedActivatedService);
            builder.RegisterType<LongTermInitialDeferralNFEmittedNotActivatedService>().Keyed<IDeferralStrategy>(DeferralType.LongTermInitialDeferralNFEmittedNotActivatedService);
            builder.RegisterType<LongTermInProgressDeferralNFEmittedWithServiceActivation>().Keyed<IDeferralStrategy>(DeferralType.LongTermRecurringDeferralNFEmittedWithServiceActivation);
            builder.RegisterType<LongTermRecurringDeferralNFEmittedActivatedServiceWithLongBalanceRemaining>().Keyed<IDeferralStrategy>(DeferralType.LongTermRecurringDeferralNFEmittedActivatedServiceWithLongBalanceRemaining);
            builder.RegisterType<LongTermRecurringDeferralNFEmittedActivatedServiceWithShortBalanceRemaining>().Keyed<IDeferralStrategy>(DeferralType.LongTermRecurringDeferralNFEmittedActivatedServiceWithShortBalanceRemaining);
          
            builder.RegisterType<LongTermNFEmittedDeferralProvisionWithoutRevenueRecognition>().Keyed<IDeferralStrategy>(DeferralType.LongTermNFEmittedDeferralProvisionWithoutRevenueRecognition);
            builder.RegisterType<ShortTermInitialDeferralProvisionNotNFEmittedLessThan30PurchaseDays>().Keyed<IDeferralStrategy>(DeferralType.ShortTermInitialDeferralProvisionNotNFEmittedLessThan30PurchaseDays);
            builder.RegisterType<ShortTermRecurringDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays>().Keyed<IDeferralStrategy>(DeferralType.ShortTermRecurringDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays);
            builder.RegisterType<ShortTermInitialDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays>().Keyed<IDeferralStrategy>(DeferralType.ShortTermInitialDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays);
            builder.RegisterType<ShortTermNFEmittedDeferralProvisionWithRevenueRecognition>().Keyed<IDeferralStrategy>(DeferralType.ShortTermNFEmittedDeferralProvisionWithRevenueRecognition);
            builder.RegisterType<LongTermInitialDeferralProvisionNotNFEmittedLessThan30PurchaseDays>().Keyed<IDeferralStrategy>(DeferralType.LongTermInitialDeferralProvisionNotNFEmittedLessThan30PurchaseDays);
            builder.RegisterType<LongTermInitialDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays>().Keyed<IDeferralStrategy>(DeferralType.LongTermInitialDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays);
            builder.RegisterType<LongTermNFEmittedDeferralProvisionWithRevenueRecognition>().Keyed<IDeferralStrategy>(DeferralType.LongTermNFEmittedDeferralProvisionWithRevenueRecognition);
            builder.RegisterType<ShortTermNFEmittedDeferralProvisionWithoutRevenueRecognition>().Keyed<IDeferralStrategy>(DeferralType.ShortTermNFEmittedDeferralProvisionWithoutRevenueRecognition);
            builder.RegisterType<LongTermRecurringDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays>().Keyed<IDeferralStrategy>(DeferralType.LongTermRecurringDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays);

            

        }
    }
}
