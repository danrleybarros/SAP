using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.Deferral;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Application.UseCases.FAT;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.Deferral;
using Gcsb.Connect.SAP.Tests.Builders.FinancialAccountsClient;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FATFaturadoRH
{
    public class LaunchDeferralHandlerTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly LaunchDeferralHandler launchDeferralHandler;
        private readonly IFinancialAccountsClient financialAccountsClient;
        private readonly IDeferralOfferWriteOnlyRepository repository;

        public LaunchDeferralHandlerTests(Fixture.ApplicationFixture fixture)
        {
            this.launchDeferralHandler = fixture.Container.Resolve<LaunchDeferralHandler>();
            this.financialAccountsClient = fixture.Container.Resolve<IFinancialAccountsClient>();
            this.repository = fixture.Container.Resolve<IDeferralOfferWriteOnlyRepository>();
        }

        [Fact(DisplayName = "US58606 - Cenário 1: Diferimento INICIAL com número de parcelas MENOR ou IGUAL a 12")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLaunchShortTermInitialDeferralWithSuccess()
        {

            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTerm(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(33333333).WithDebit(44444444).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(12)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralStarted(false)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(1200000)
                                    .WithTotalShortBalance(1100000)
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

            launchers.Should().HaveCount(4);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "44444444" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "33333333" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalShortBalance).First().Should().Be(1000000); 
        }

        [Fact(DisplayName = @"US58606 - Cenário 2: Diferimento MENSAL com número de parcelas MENOR OU IGUAL a 12
                              US58601 - Cenário 5: Diferimento MENSAL com número de parcelas MENOR OU IGUAL a 12")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLaunchShortTermRecurringDeferralWithSucess()
        {
            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(12)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralStarted(true)
                                    .WithCurrentInstallment(2)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(1200000)
                                    .WithTotalShortBalance(1100000)
                                    .WithInstallmentAmount(100000)
                                    .WithDeferralStatus(SAP.Domain.Deferral.DeferralStatus.InProgress)
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
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalShortBalance).First().Should().Be(1000000);

        }

        [Fact(DisplayName = @"US58606 - Cenário 2: Diferimento MENSAL com número de parcelas MENOR OU IGUAL a 12 (Ultima Parcela)
                              US58601 - Cenário 5: Diferimento MENSAL com número de parcelas MENOR OU IGUAL a 12 (Ultima Parcela)")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLastInstallmentLaunchShortTermRecurringDeferralWithSucess()
        {
            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(12)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralStarted(true)
                                    .WithCurrentInstallment(11)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(1100)
                                    .WithTotalShortBalance(91.67)
                                    .WithTotalLongBalance(0)
                                    .WithInstallmentAmount(91.67)
                                    .WithDeferralStatus(SAP.Domain.Deferral.DeferralStatus.InProgress)
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
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 91.63M).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 91.63M).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalShortBalance).First().Should().Be(0);
            request.DeferralOffers.FirstOrDefault().DeferralStatus.Should().Be(DeferralStatus.Completed);
        }

        [Fact(DisplayName = "US58606 - Cenário 3: Diferimento INICIAL com número de parcelas MAIOR que 12")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLaunchLongTermInitialDeferralWithSucess()
        {
            var accountingAccounts = financialAccountsClient.GetAccountDetailsByService(new List<string>() { "Office365EnterpriseE3" }, new List<string>() { "Billed" });

            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTerm(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(33333333).WithDebit(44444444).Build())
                                               .WithLongTerm(DeferralAccountBuilder.New().WithCredit(55555555).WithDebit(66666666).Build())
                                               .WithLongTermLow(DeferralAccountBuilder.New().WithCredit(77777777).WithDebit(88888888).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(24)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralStarted(false)
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
                DeferralOffers = deferralOffers,
                AccountingAccounts = accountingAccounts,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice> { InvoiceBuilder.New().WithInvoiceNumber("TLA-1-00124398").Build() }
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(8);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 2400000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 2400000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "55555555" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "44444444" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "88888888" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "33333333" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "44444444" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalLongBalance).First().Should().Be(1100000);

        }

        [Fact(DisplayName = @"US58606 - Cenário 4: Diferimento MENSAL com número de parcelas MAIOR que 12
                              US58601 - Cenário 6: Diferimento MENSAL com número de parcelas MAIOR que 12")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLaunchLongTermRecurringWithSucess()
        {
            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())
                                               .WithLongTermLow(DeferralAccountBuilder.New().WithDebit(33333333).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(24)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralStarted(true)
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
                DeferralOffers = deferralOffers,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice> { InvoiceBuilder.New().WithInvoiceNumber("TLA-1-00124398").Build() }
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(4);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "33333333" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            
            request.DeferralOffers.Select(s => s.TotalLongBalance).First().Should().Be(900000);
        }

        [Fact(DisplayName = @"US58606 - Cenário 5: Diferimento MENSAL com número de parcelas MAIOR que 12 com saldo a curto prazo
                              US58601 - Cenário 7: Diferimento MENSAL com número de parcelas MAIOR que 12 com saldo a curto prazo")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLaunchLongTermRecurringWithShortBalanceRemainingWithSucess()
        {
            var accountingAccounts = financialAccountsClient.GetAccountDetailsByService(new List<string>() { "Office365EnterpriseE3" }, new List<string>() { "Billed" });
           
            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())                                             
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(24)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralStarted(true)
                                    .WithCurrentInstallment(2)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(2400000)
                                    .WithTotalShortBalance(1100000)
                                    .WithTotalLongBalance(0)
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

            launchers.Should().HaveCount(2);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalShortBalance).First().Should().Be(1000000);

        }

        [Fact(DisplayName = @"US58606 - Cenário 5: Diferimento MENSAL com número de parcelas MAIOR que 12 com saldo a curto prazo (Ultima Parcela)
                              US58601 - Cenário 7: Diferimento MENSAL com número de parcelas MAIOR que 12 com saldo a curto prazo (Ultima Parcela)")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLastInstallmentLaunchLongTermRecurringWithShortBalanceRemainingWithSuccess()
        {
            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(24)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralStarted(true)
                                    .WithCurrentInstallment(23)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(2300)
                                    .WithTotalShortBalance(95.83)
                                    .WithTotalLongBalance(0)
                                    .WithDeferralStatus(DeferralStatus.InProgress)
                                    .WithInstallmentAmount(95.83)
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
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 95.91m).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 95.91m).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalShortBalance).First().Should().Be(0);

        }

        [Fact(DisplayName = "US58606 - Cenário 6: Diferimento INICIAL com número de parcelas MENOR ou IGUAL a 12 e oferta com desconto condicional")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLaunchShortTermInitialWithDiscountDeferralWithSuccess()
        {
            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTerm(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(33333333).WithDebit(44444444).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(12)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralStarted(false)
                                    .WithHasDiscount(true)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(1200000)
                                    .WithTotalShortBalance(1100000)
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

            launchers.Should().HaveCount(4);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "44444444" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "33333333" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalShortBalance).First().Should().Be(1000000);
        }

        [Fact(DisplayName = "US58601 - Cenário 1: Diferimento INICIAL com número de parcelas MENOR ou IGUAL a 12")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLaunchShortTermInitialDeferralNotActivedServiceWithSuccess()
        {
           
            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTerm(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(12)
                                    .WithDeferralStatus(DeferralStatus.New)
                                    .WithIsNFEmitted(true)
                                    .WithIsActive(false)                                   
                                    .WithDeferralStarted(false)
                                    .WithHasDiscount(false)
                                    .WithIsProvisioned(false)    
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
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice> { InvoiceBuilder.New().WithInvoiceNumber("TLA-1-00124398").Build() }
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(2);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();

        }

        [Fact(DisplayName = "US58601 - Cenário 2: Diferimento INICIAL com número de parcelas MAIOR que 12")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLaunchLongTermInitialDeferralNotActivedServiceWithSucess()
        {
            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTerm(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())
                                               .WithLongTerm(DeferralAccountBuilder.New().WithCredit(33333333).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(24)
                                    .WithIsActive(false)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralStarted(false)
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
                DeferralOffers = deferralOffers,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice> { InvoiceBuilder.New().WithInvoiceNumber("TLA-1-00124398").Build() }
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(4);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 2400000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 2400000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "33333333" && w.AccountingEntry == "C" && w.LaunchValue == 1200000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "D" && w.LaunchValue == 1200000).Should().BeTrue();

        }

        [Fact(DisplayName = "US58601 - Cenário 3: Ativação de serviço com diferimento iniciado com número de parcelas MENOR OU IGUAL a 12")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLaunchShortTermRecurringDeferralWithServiceActivationWithSucess()
        {
            var deferralFinancialAccounts = new List<DeferralFinancialAccount>
            {
                DeferralFinancialAccountBuilder.New()
                                               .WithInterface("Billed")
                                               .WithFinancialAccount("FATO365CSPGW")
                                               .WithServiceCode("Office365EnterpriseE3")
                                               .WithOfferCode("Office365EnterpriseE3Offer")
                                               .WithStore("telerese")
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(12)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralStarted(false)
                                    .WithCurrentInstallment(0)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(1200000)
                                    .WithTotalShortBalance(1200000)
                                    .WithInstallmentAmount(100000)
                                    .WithDeferralStatus(SAP.Domain.Deferral.DeferralStatus.InProgress)
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
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalShortBalance).First().Should().Be(1100000);

        }
              
        [Fact(DisplayName = "US58601 - Cenário 4: Ativação de serviço com diferimento iniciado com número de parcelas MAIOR que 12")]
        [Trait("Categoria", "Diferimento")]
        public void ShouldAddLaunchLongTermInitialActiveServiceWithSuccess()
        {
            var accountingAccounts = financialAccountsClient.GetAccountDetailsByService(new List<string>() { "Office365EnterpriseE3" }, new List<string>() { "Billed" });
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
                                               .WithShortTermProvision(DeferralAccountBuilder.New().WithCredit(11111111).WithDebit(22222222).Build())
                                               .WithLongTermLow(DeferralAccountBuilder.New().WithCredit(33333333).WithDebit(44444444).Build())
                                               .Build()

            };

            var deferralOffers = new List<SAP.Domain.Deferral.DeferralOffer>()
            {
                DeferralOfferBuilder.New()
                                    .WithInvoiceNumber("TLA-1-00124398")
                                    .WithNumberOfInstallments(24)
                                    .WithIsActive(true)
                                    .WithIsNFEmitted(true)
                                    .WithDeferralStarted(false)
                                    .WithServiceCode("Office365EnterpriseE3")
                                    .WithOfferCode("Office365EnterpriseE3Offer")
                                    .WithStoreAcronym("telerese")
                                    .WithTotalBalance(2400000)
                                    .WithIsProvisioned(false)
                                    .WithTotalShortBalance(1200000)
                                    .WithTotalLongBalance(1200000)
                                    .WithInstallmentAmount(100000)
                                    .WithDeferralStatus(DeferralStatus.InProgress)
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

            launchers.Should().HaveCount(4);
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "44444444" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 100000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 100000).Should().BeTrue();
            

            request.DeferralOffers.Select(s => s.TotalLongBalance).First().Should().Be(1100000);

        }

    }
}
