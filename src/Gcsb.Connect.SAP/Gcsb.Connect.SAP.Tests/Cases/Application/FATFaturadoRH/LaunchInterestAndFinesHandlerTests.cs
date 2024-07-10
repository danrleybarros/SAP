using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Application.UseCases.FAT;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Tests.Builders;
using Gcsb.Connect.SAP.Tests.Builders.FinancialAccountsClient;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FATFaturadoRH
{

    public class LaunchInterestAndFinesHandlerTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IFinancialAccountsClient financialAccountsClient;

        public LaunchInterestAndFinesHandlerTests(Fixture.ApplicationFixture fixture)
        {
            this.financialAccountsClient = fixture.Container.Resolve<IFinancialAccountsClient>();
        }

        [Fact]
        public void ReturnTwoInvoiceFourServiceWithDiscount()
        {
            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow);

            request.Files.Add(FileBuilder.New().Build());

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

            var invoiceSP = InvoiceBuilder.New()
                .WithTotalInvoicePrice(100)
                .WithStoreAcronym("telerese")
                .WithCustomer(CustomerBuilder.New()
                    .WithBillingStateOrProvince("SAO PAULO")
                    .WithBillingZIPcode("03303-000")
                    .Build())
                .Build();

            var invoiceRJ = InvoiceBuilder.New()
                .WithStoreAcronym("telerese")
                .WithCustomer(CustomerBuilder.New()
                    .WithBillingStateOrProvince("RIO DE JANEIRO")
                    .WithBillingZIPcode("09090-000")
                    .Build())
                .Build();

            request.InterestServices = new List<ServiceFilter>
            {
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceSP)
                    .WithGrandTotalRetailPrice(100)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceSP)
                    .WithGrandTotalRetailPrice(150)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceRJ)
                    .WithGrandTotalRetailPrice(120)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceRJ)
                    .WithGrandTotalRetailPrice(150)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };

            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>() { invoiceSP, invoiceRJ };

            new LaunchInterestAndFinesHandler().ProcessRequest(request);

            Assert.True(request.Lines.Count == 1);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Count == 4);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("JUROSATRASOPG") && p.UF.Equals("SP") && p.AccountingEntry == "C").LaunchValue == 250);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("JUROSATRASOPG") && p.UF.Equals("SP") && p.AccountingEntry == "D").LaunchValue == 250);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("JUROSATRASOPG") && p.UF.Equals("RJ") && p.AccountingEntry == "C").LaunchValue == 270);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("JUROSATRASOPG") && p.UF.Equals("RJ") && p.AccountingEntry == "D").LaunchValue == 270);
        }
    }
}
