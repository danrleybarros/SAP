using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.Deferral;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Application.UseCases.FAT;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.Deferral;
using Gcsb.Connect.SAP.Tests.Builders.FinancialAccountsClient;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Xunit;
using YamlDotNet.Core;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FATFaturadoRH
{
    public class LaunchDeferralProvisionHandlerTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly LaunchDeferralHandler launchDeferralHandler;
        private readonly IFinancialAccountsClient financialAccountsClient;
        private readonly IDeferralOfferWriteOnlyRepository repository;

        public LaunchDeferralProvisionHandlerTests(Fixture.ApplicationFixture fixture)
        {
            this.launchDeferralHandler = fixture.Container.Resolve<LaunchDeferralHandler>();
            this.financialAccountsClient = fixture.Container.Resolve<IFinancialAccountsClient>();
            this.repository = fixture.Container.Resolve<IDeferralOfferWriteOnlyRepository>();
        }

        [Fact(DisplayName = "US58602 - Cenário 1: Diferimento provisionado INICIAL com número de parcelas MENOR OU IGUAL a 12, a menos de 30 dias da data da compra")]
        [Trait("Categoria", "Diferimento Provisionado")]
        public void ShouldAddLaunchShortTermInitialDeferralProvisionNotNFEmittedLessThan30PurchaseDaysWithSuccess()
        {
            var accountingAccounts = financialAccountsClient.GetAccountDetailsByService(new List<string>() { "Office365EnterpriseE3" }, new List<string>() { "Billing" });

            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(41435025).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(12)
                                    .WithIsActive(true)
                                    .WithIsProvisioned(true)
                                    .WithPurchaseDate(DateTime.UtcNow.AddDays(26))
                                    .WithDeferralStatus(SAP.Domain.Deferral.DeferralStatus.New)
                                    .WithIsNFEmitted(false)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalShortBalance(1200000)
                                    .Build()
            };

            var request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow)
            {
                DeferralOffers = deferralOffers,
                AccountingAccounts = accountingAccounts,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice> { InvoiceBuilder.New().WithInvoiceNumber("TLA-1-00124398").Build() }
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(2);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41435025" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11211142" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();

        }

        [Fact(DisplayName = "US58602 - Cenário 2: Diferimento Provisionado MENSAL com número de parcelas MENOR OU IGUAL a 12")]
        [Trait("Categoria", "Diferimento Provisionado")]
        public void ShouldAddLaunchShortTermRecurringDeferralProvisionNotNFEmittedGreaterThan30PurchaseDaysWithSuccess()
        {
            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTerm(DeferralAccountBuilder.New().WithCredit(41431068).Build())
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithDebit(21191113).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(12)
                                    .WithIsActive(true)
                                    .WithPurchaseDate(DateTime.UtcNow.AddDays(-31))
                                    .WithIsProvisioned(true)
                                    .WithDeferralStatus(SAP.Domain.Deferral.DeferralStatus.InProgress)
                                    .WithIsNFEmitted(false)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalShortBalance(1200000)
                                    .WithInstallmentAmount(100000)

                                    .Build()
            };

            var request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow)
            {
                DeferralOffers = deferralOffers,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice> { InvoiceBuilder.New().WithInvoiceNumber("TLA-1-00124398").Build() }
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(2);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41431068" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21191113" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalShortBalance).First().Should().Be(1100000);
        }

        [Fact(DisplayName = "US58602 - Cenário 3: Diferimento Provisionado INICIAL com número de parcelas MENOR OU IGUAL a 12, a mais de 30 dias da data da compra")]
        [Trait("Categoria", "Diferimento Provisionado")]
        public void ShouldAddLaunchShortTermInitialDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays()
        {
            var accountingAccounts = financialAccountsClient.GetAccountDetailsByService(new List<string>() { "Office365EnterpriseE3" }, new List<string>() { "Billing" });

            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTerm(DeferralAccountBuilder.New().WithCredit(99999999).Build())
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(41435025).WithDebit(11215115).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(12)
                                    .WithIsActive(true)
                                    .WithIsProvisioned(true)
                                    .WithPurchaseDate(DateTime.UtcNow.AddDays(-31))
                                    .WithDeferralStatus(SAP.Domain.Deferral.DeferralStatus.New)
                                    .WithIsNFEmitted(false)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalShortBalance(1200000)
                                    .WithTotalBalance(1200000)
                                    .WithInstallmentAmount(100000)

                                    .Build()
            };

            var request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow)
            {
                DeferralOffers = deferralOffers,
                AccountingAccounts = accountingAccounts,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice> { InvoiceBuilder.New().WithInvoiceNumber("TLA-1-00124398").Build() }
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(4);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41435025" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11211142" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "99999999" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11215115" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalShortBalance).First().Should().Be(1100000);
        }

        [Fact(DisplayName = "US58602 - Cenário 4: Emissão da Nota Fiscal para serviço com diferimento provisionado com número de parcelas MENOR OU IGUAL a 12 e sem reconhecimento de receita")]
        [Trait("Categoria", "Diferimento Provisionado")]
        public void ShouldAddLaunchShortTermInitialRecurringNFEmittedDeferralProvisionWithSuccess()
        {
            var accountingAccounts = financialAccountsClient.GetAccountDetailsByService(new List<string>() { "Office365EnterpriseE3" }, new List<string>() { "Billed", "Billing" });
            var invoice = $"TLA-1-{DateTime.Now.ToString("MMddmmssff")}";

            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTerm(DeferralAccountBuilder.New().WithCredit(11515142).WithDebit(41431068).Build())
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(21345639).WithDebit(31549785).Build())
                                               .WithShortTermLowProvision(DeferralAccountBuilder.New().WithDebit(21191113).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber(invoice)
                                    .WithNumberOfInstallments(12)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralProvisionStarted(false)
                                    .WithCurrentInstallment(0)
                                    .WithIsProvisioned(true)
                                    .WithDeferralStatus(SAP.Domain.Deferral.DeferralStatus.InProgress)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(1200000)
                                    .WithTotalShortBalance(1200000)
                                    .WithInstallmentAmount(100000)
                                    .Build()
            };

            var request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow)
            {
                DeferralOffers = deferralOffers,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                AccountingAccounts = accountingAccounts,
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice> { InvoiceBuilder.New().WithInvoiceNumber(invoice).Build() }
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(6);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41431068" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11515142" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21191113" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41435025" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "31549785" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21345639" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
        }

        [Fact(DisplayName = "US58602 - Cenário 5: Emissão da Nota Fiscal para serviço com diferimento provisionado com número de parcelas MENOR OU IGUAL a 12 e com reconhecimento de receita")]
        [Trait("Categoria", "Diferimento Provisionado")]
        public void ShouldAddLaunchShortTermRecurringNFEmittedDeferralProvisionWithSuccess()
        {
            var accountingAccounts = financialAccountsClient.GetAccountDetailsByService(new List<string>() { "Office365EnterpriseE3" }, new List<string>() { "Billed", "Billing" });

            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTerm(DeferralAccountBuilder.New().WithCredit(11515142).WithDebit(41431068).Build())
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(21191113).WithDebit(44231562).Build())
                                               .WithShortTermLowProvision(DeferralAccountBuilder.New().WithDebit(21191113).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(12)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithIsProvisioned(true)
                                    .WithDeferralStatus(SAP.Domain.Deferral.DeferralStatus.InProgress)
                                    .WithDeferralProvisionStarted(true)
                                    .WithCurrentInstallment(2)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(1200000)
                                    .WithTotalShortBalance(1000000)
                                    .WithInstallmentAmount(100000)
                                    .Build()
            };

            var request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow)
            {
                DeferralOffers = deferralOffers,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                AccountingAccounts = accountingAccounts,
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice> { InvoiceBuilder.New().WithInvoiceNumber("TLA-1-00124398").Build() }
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(8);
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41431068" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11515142" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21191113" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41435025" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41431068" && w.AccountingEntry == "D" && w.LaunchValue == 200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21191113" && w.AccountingEntry == "C" && w.LaunchValue == 200000).Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "44231562" && w.AccountingEntry == "D" && w.LaunchValue == 300000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21191113" && w.AccountingEntry == "C" && w.LaunchValue == 300000).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalShortBalance).First().Should().Be(900000);
        }

        [Fact(DisplayName = "US58602 - Cenário 6: Diferimento provisionado INICIAL com número de parcelas MAIOR que 12, a menos de 30 dias da data da compra")]
        [Trait("Categoria", "Diferimento Provisionado")]
        public void ShouldAddLaunchLongTermInitiallProvisionNotNFEmittedLessThan30PurchaseDaysWithSuccess()
        {
            var accountingAccounts = financialAccountsClient.GetAccountDetailsByService(new List<string>() { "Office365EnterpriseE3" }, new List<string>() { "Billing" });

            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(41435025).Build())
                                               .WithLongTermProvision(DeferralAccountBuilder.New().WithCredit(12121212).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(24)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(false)
                                    .WithDeferralProvisionStarted(false)
                                    .WithIsProvisioned(true)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(2400000)
                                    .WithTotalShortBalance(1200000)
                                    .WithTotalLongBalance(1200000)
                                    .WithInstallmentAmount(100000)
                                    .WithPurchaseDate(DateTime.UtcNow.AddDays(2))
                                    .Build()
            };

            var request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow)
            {
                DeferralOffers = deferralOffers,
                AccountingAccounts = accountingAccounts,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice> { InvoiceBuilder.New().WithInvoiceNumber("TLA-1-00124398").Build() }
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(4);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41435025" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11211142" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "12121212" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11211142" && w.LaunchValue == 1200000).Should().BeTrue();
        }

        [Fact(DisplayName = "US58602 - Cenário 8: Diferimento provisionado INICIAL com número de parcelas MAIOR que 12, a mais de 30 dias da data da compra")]
        [Trait("Categoria", "Diferimento Provisionado")]
        public void ShouldAddLaunchLongTermInitialDeferralProvisionNotNFEmittedGreaterThan30PurchaseDaysWithSuccess()
        {
            var accountingAccounts = financialAccountsClient.GetAccountDetailsByService(new List<string>() { "Office365EnterpriseE3" }, new List<string>() { "Billing" });
            var services = new List<ServiceFilter>
            {
                ServiceFilterBuilder.New()
                                    .WithStoreAcronym("telerese")
                                    .WithProviderCompanyAcronym("cloudco")
                                    .WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("TLA-1-00124398").Build())
                                    .WithGrandTotalRetailPrice(1200000)
                                    .Build()
            };

            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(21191113).WithDebit(21191114).Build())
                                               .WithLongTermLow(DeferralAccountBuilder.New().WithCredit(21191113).Build())
                                               .WithLongTermProvision(DeferralAccountBuilder.New().WithCredit(21191113).Build())
                                               .WithLongTermLowProvision(DeferralAccountBuilder.New().WithDebit(191113).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(24)
                                    .WithIsActive(true)
                                    .WithIsProvisioned(true)
                                    .WithPurchaseDate(DateTime.UtcNow.AddDays(-31))
                                    .WithDeferralStatus(SAP.Domain.Deferral.DeferralStatus.New)
                                    .WithIsNFEmitted(false)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(2400000)
                                    .WithTotalShortBalance(1200000)
                                    .WithTotalLongBalance(1100000)
                                    .WithInstallmentAmount(100000)
                                    .Build()
            };

            var request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow)
            {
                Services = services,
                DeferralOffers = deferralOffers,
                AccountingAccounts = accountingAccounts,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                Invoices = services.Select(s => s.Invoice).ToList()
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(8);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21191113" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11211142" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21191113" && w.AccountingEntry == "C" && w.LaunchValue == 1100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11211142" && w.AccountingEntry == "D" && w.LaunchValue == 1100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21191113" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "191113" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21191113" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21191114" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalLongBalance).First().Should().Be(1000000);

        }

        [Fact(DisplayName = "US58602 - Cenário 9: Emissão da Nota Fiscal para serviço com diferimento provisionado com número de parcelas MAIOR que 12 e sem reconhecimento de receita")]
        [Trait("Categoria", "Diferimento Provisionado")]
        public void ShouldAddLaunchLongTermNFEmittedDeferralProvisionWithoutRevenueRecognitionWithSuccess()
        {
            var accountingAccounts = financialAccountsClient.GetAccountDetailsByService(new List<string>() { "Office365EnterpriseE3" }, new List<string>() { "Billing", "Billed" });
            var invoice = $"TLA-1-{DateTime.Now.ToString("MMddmmssff")}";

            var services = new List<ServiceFilter>
            {
                ServiceFilterBuilder.New()
                                    .WithStoreAcronym("telerese")
                                    .WithProviderCompanyAcronym("cloudco")
                                    .WithInvoice(InvoiceBuilder.New().WithInvoiceNumber(invoice).Build())
                                    .WithGrandTotalRetailPrice(1200000)
                                    .Build()
            };

            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTerm(DeferralAccountBuilder.New().WithCredit(12121212).WithDebit(21212121).Build())
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(41414141).WithDebit(14141414).Build())
                                               .WithShortTermLowProvision(DeferralAccountBuilder.New().WithCredit(91919191).WithDebit(19191919).Build())
                                               .WithLongTerm(DeferralAccountBuilder.New().WithCredit(94949494).WithDebit(49494949).Build())
                                               .WithLongTermLow(DeferralAccountBuilder.New().WithCredit(63636363).WithDebit(36363636).Build())
                                               .WithLongTermProvision(DeferralAccountBuilder.New().WithCredit(75757575).WithDebit(57575757).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber(invoice)
                                    .WithNumberOfInstallments(24)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralProvisionStarted(false)
                                    .WithCurrentInstallment(0)
                                    .WithIsProvisioned(true)
                                    .WithHasDiscount(false)
                                    .WithDeferralStatus(SAP.Domain.Deferral.DeferralStatus.InProgress)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(2400000)
                                    .WithTotalShortBalance(1200000)
                                    .WithTotalLongBalance(1200000)
                                    .WithInstallmentAmount(100000)
                                    .Build()
            };

            var request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow)
            {
                Services = services,
                DeferralOffers = deferralOffers,
                AccountingAccounts = accountingAccounts,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                Invoices = services.Select(s => s.Invoice).ToList()
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(12);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21212121" && w.LaunchValue == 2400000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "12121212" && w.LaunchValue == 2400000 && w.AccountingEntry == "C").Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "19191919" && w.LaunchValue == 1200000 && w.AccountingEntry == "D").Should().BeTrue(); //12000
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41435025" && w.LaunchValue == 1200000 && w.AccountingEntry == "C").Should().BeTrue();

            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "57575757" && w.LaunchValue == 1200000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41435025" && w.LaunchValue == 1200000 && w.AccountingEntry == "C").Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "12121212" && w.LaunchValue == 1200000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "94949494" && w.LaunchValue == 1200000 && w.AccountingEntry == "C").Should().BeTrue();

            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "36363636" && w.LaunchValue == 100000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41414141" && w.LaunchValue == 100000 && w.AccountingEntry == "C").Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "14141414" && w.LaunchValue == 100000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41414141" && w.LaunchValue == 100000 && w.AccountingEntry == "C").Should().BeTrue();
        }

        [Fact(DisplayName = "US58602 - Cenário 10: Emissão da Nota Fiscal para serviço com diferimento provisionado com número de parcelas MAIOR que 12 e com reconhecimento de receita")]
        [Trait("Categoria", "Diferimento Provisionado")]
        public void ShouldAddLaunchLongTermNFEmittedDeferralProvisionWithRevenueRecognitionWithSuccess()
        {
            var accountingAccounts = financialAccountsClient.GetAccountDetailsByService(new List<string>() { "Office365EnterpriseE3" }, new List<string>() { "Billing" });
            var invoice = $"TLA-1-{DateTime.Now.ToString("MMddmmssff")}";

            var services = new List<ServiceFilter>
            {
                ServiceFilterBuilder.New()
                                    .WithStoreAcronym("telerese")
                                    .WithProviderCompanyAcronym("cloudco")
                                    .WithInvoice(InvoiceBuilder.New().WithInvoiceNumber(invoice).Build())
                                    .WithGrandTotalRetailPrice(1200000)
                                    .Build()
            };

            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTerm(DeferralAccountBuilder.New().WithCredit(12121212).WithDebit(21212121).Build())
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(41414141).WithDebit(14141414).Build())
                                               .WithShortTermLowProvision(DeferralAccountBuilder.New().WithCredit(91919191).WithDebit(19191919).Build())
                                               .WithLongTerm(DeferralAccountBuilder.New().WithCredit(94949494).WithDebit(49494949).Build())
                                               .WithLongTermLow(DeferralAccountBuilder.New().WithCredit(63636363).WithDebit(36363636).Build())
                                               .WithLongTermLowProvision(DeferralAccountBuilder.New().WithCredit(95959595).WithDebit(59595959).Build())
                                               .WithLongTermProvision(DeferralAccountBuilder.New().WithCredit(75757575).WithDebit(57575757).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber(invoice)
                                    .WithNumberOfInstallments(24)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithIsProvisioned(true)
                                    .WithDeferralStatus(SAP.Domain.Deferral.DeferralStatus.InProgress)
                                    .WithDeferralProvisionStarted(true)
                                    .WithHasDiscount(false)
                                    .WithCurrentInstallment(2)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(2400000)
                                    .WithTotalShortBalance(1200000)
                                    .WithTotalLongBalance(1000000)
                                    .WithInstallmentAmount(100000)
                                    .Build()
            };


            var request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow)
            {
                Services = services,
                DeferralOffers = deferralOffers,
                AccountingAccounts = accountingAccounts,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                Invoices = services.Select(s => s.Invoice).ToList()
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(16); 

            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21212121" && w.LaunchValue == 2400000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "12121212" && w.LaunchValue == 2400000 && w.AccountingEntry == "C").Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "19191919" && w.LaunchValue == 1200000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41435025" && w.LaunchValue == 1200000 && w.AccountingEntry == "C").Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "57575757" && w.LaunchValue == 1200000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41435025" && w.LaunchValue == 1200000 && w.AccountingEntry == "C").Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "21212121" && w.LaunchValue == 200000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41414141" && w.LaunchValue == 200000 && w.AccountingEntry == "C").Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "59595959" && w.LaunchValue == 200000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41414141" && w.LaunchValue == 200000 && w.AccountingEntry == "C").Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "12121212" && w.LaunchValue == 1200000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "94949494" && w.LaunchValue == 1200000 && w.AccountingEntry == "C").Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "36363636" && w.LaunchValue == 300000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "14141414" && w.LaunchValue == 300000 && w.AccountingEntry == "C").Should().BeTrue();
            
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "14141414" && w.LaunchValue == 300000 && w.AccountingEntry == "D").Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "41414141" && w.LaunchValue == 300000 && w.AccountingEntry == "C").Should().BeTrue();
            
            request.DeferralOffers.Select(s => s.TotalLongBalance).First().Should().Be(900000);
        }
    }
}
