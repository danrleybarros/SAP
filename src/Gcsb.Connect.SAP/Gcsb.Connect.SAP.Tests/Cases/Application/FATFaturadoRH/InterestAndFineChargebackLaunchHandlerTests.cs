using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.FAT;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders.FinancialAccountsClient;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FATFaturadoRH
{
    public class InterestAndFineChargebackLaunchHandlerTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFinancialAccountsClient financialAccountsClient;
        private readonly IJsdnRepository jsdnRepository;
        private readonly InterestAndFineChargebackLaunchHandler interestAndFineChargebackLaunchHandler;

        public InterestAndFineChargebackLaunchHandlerTests(Fixture.ApplicationFixture fixture)
        {
            this.financialAccountsClient = fixture.Container.Resolve<IFinancialAccountsClient>();
            this.jsdnRepository = fixture.Container.Resolve<IJsdnRepository>();
            this.interestAndFineChargebackLaunchHandler = fixture.Container.Resolve<InterestAndFineChargebackLaunchHandler>();
        }

        [Fact]
        public void ReturnTwoInvoiceFourServiceWithDiscount()
        {
            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow);

            request.FinancialAccounts = new List<FinancialAccount>{
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Billed")
                    .WithAccountType("Billed")
                    .WithFinancialAccountType("FATO365CSPGW")
                    .WithFinancialAccountDeb("41435025")
                    .WithFinancialAccountCred("11215115")
                    .Build(),

                FinancialAccountBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Billed")
                    .WithAccountType("Discount")
                    .WithFinancialAccountType("DESCO365CSPGW")
                    .WithFinancialAccountDeb("41435025")
                    .WithFinancialAccountCred("11215115")
                    .Build()
            };

            new GetInterestAndFineFinancialAccountHandler(financialAccountsClient).ProcessRequest(request);

            var invoices = new List<Invoice> {
                InvoiceBuilder.New()
                .WithInvoiceNumber("VVL-1-00041867")
                .WithTotalInvoicePrice(25)
                .WithStoreAcronym("telerese")
                .WithCustomer(CustomerBuilder.New()
                    .WithBillingStateOrProvince("SAO PAULO")
                    .WithBillingZIPcode("03303-000")
                    .Build())
                .Build(),
                InvoiceBuilder.New()
                .WithInvoiceNumber("VVL-1-00041868")
                .WithTotalInvoicePrice(50)
                .WithStoreAcronym("telerese")
                .WithCustomer(CustomerBuilder.New()
                    .WithBillingStateOrProvince("SAO PAULO")
                    .WithBillingZIPcode("03303-000")
                    .Build())
                .Build(),
                InvoiceBuilder.New()
                .WithInvoiceNumber("VVL-1-00041869")
                .WithTotalInvoicePrice(75)
                .WithStoreAcronym("telerese")
                .WithCustomer(CustomerBuilder.New()
                    .WithBillingStateOrProvince("SAO PAULO")
                    .WithBillingZIPcode("03303-000")
                    .Build())
                .Build(),
                InvoiceBuilder.New()
                .WithInvoiceNumber("VVL-1-00041871")
                .WithTotalInvoicePrice(100)
                .WithStoreAcronym("telerese")
                .WithCustomer(CustomerBuilder.New()
                    .WithBillingStateOrProvince("SAO PAULO")
                    .WithBillingZIPcode("03303-000")
                    .Build())
                .Build()
            };

            invoices.ForEach(invoice =>
            {
                request.CounterchargeChargebackServices.AddRange(new List<ServiceFilter>
                {
                    new ServiceFilterBuilder()
                        .WithInvoice(invoice)
                        .WithGrandTotalRetailPrice((double?)invoice.TotalInvoicePrice)
                        .WithServiceCode("TESTESERVICE")                        
                        .WithServiceType("SaaS")
                        .WithReceivable("SPJURTBRAC")
                        .WithStoreAcronym("telerese")
                        .WithProviderCompanyAcronym("telerese")
                        .Build(),
                    new ServiceFilterBuilder()
                        .WithInvoice(invoice)
                        .WithGrandTotalRetailPrice((double?)invoice.TotalInvoicePrice/2)
                        .WithServiceCode("TESTESERVICE")                        
                        .WithServiceType("SaaS")
                        .WithReceivable("SPMULTBRAC")
                        .WithStoreAcronym("telerese")
                        .WithProviderCompanyAcronym("telerese")
                        .Build()
                });
            });

            request.CounterchargeDisputes.AddRange(jsdnRepository.GetCounterChargeDisputeByCycle(request.BillingCycleDate, request.BillingCycleDate.AddMonths(1).AddDays(-1)));

            request.Invoices = invoices;
            interestAndFineChargebackLaunchHandler.ProcessRequest(request);

            Assert.True(request.Lines.Count == 1);

            var lines = request.Lines[StoreType.TBRA];
           
            Assert.True(lines.Count == 16);

            Assert.True(lines.Find(p => p.FinancialAccount.Equals("JUROSATRASOPG") && p.AccountingAccount.Equals("11215115") && p.AccountingEntry == "C").LaunchValue == 50);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("JUROSATRASOPG") && p.AccountingAccount.Equals("11215115") && p.AccountingEntry == "D").LaunchValue == 50);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTAATRASOPG") && p.AccountingAccount.Equals("11215115") && p.AccountingEntry == "C").LaunchValue == 25);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTAATRASOPG") && p.AccountingAccount.Equals("11215115") && p.AccountingEntry == "D").LaunchValue == 25);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DEBRESTGW") && p.AccountingAccount.Equals("41911992") && p.AccountingEntry == "C").LaunchValue == 75);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DEBRESTGW") && p.AccountingAccount.Equals("11215115") && p.AccountingEntry == "D").LaunchValue == 75);
        }
    }
}
