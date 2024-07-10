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

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FATaFaturarACM.Handler
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
        public void ShouldApplyMathOnLaunchValue()
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

            var request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FATAFATURARACM, Guid.NewGuid(), DateTime.UtcNow)
            {
                DeferralOffers = deferralOffers,
                DeferralFinancialAccounts = deferralFinancialAccounts,
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice> { InvoiceBuilder.New().WithInvoiceNumber("TLA-1-00124398").Build() }
            };

            deferralOffers.ForEach(offer => repository.Add(offer));
            launchDeferralHandler.ProcessRequest(request);

            var launchers = request.Lines.Where(w => w.Key == SAP.Domain.JSDN.Stores.StoreType.TBRA).SelectMany(w => w.Value).ToList();

            launchers.Should().HaveCount(4); 
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "11111111" && w.AccountingEntry == "C" && w.LaunchValue == 160000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "22222222" && w.AccountingEntry == "D" && w.LaunchValue == 160000).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "33333333" && w.AccountingEntry == "C" && Decimal.Compare(w.LaunchValue, Convert.ToDecimal(13333.33)) == 0).Should().BeTrue();
            launchers.Any(w => w.FinancialAccount == "FATO365CSPGW" && w.AccountingAccount == "44444444" && w.AccountingEntry == "D" && Decimal.Compare(w.LaunchValue, Convert.ToDecimal(13333.33)) == 0).Should().BeTrue();
            request.DeferralOffers.Select(s => s.TotalShortBalance).First().Should().Be(1000000);
        }

    }    
}
