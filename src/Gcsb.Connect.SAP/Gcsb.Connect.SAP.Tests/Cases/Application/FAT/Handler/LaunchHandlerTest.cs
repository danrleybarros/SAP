using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.GF;
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
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FAT.Handler
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("H")]

    public class LaunchHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IDne dne;
        private readonly IUniqueStoreFinancialAccount uniqueStoreFinancialAccount;

        public LaunchHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.dne = fixture.Container.Resolve<IDne>();
            this.uniqueStoreFinancialAccount = fixture.Container.Resolve<IUniqueStoreFinancialAccount>();
        }

        [Fact]
        public void ReturnTwoFinnancialAccountOneFatAndOneDesc()
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

            request.Services = new List<ServiceFilter>
            {
                new ServiceFilterBuilder()
                    .WithInvoice(
                        InvoiceBuilder
                            .New()
                            .WithTotalInvoicePrice(100)
                            .WithCustomer(CustomerBuilder.New()
                                .WithBillingStateOrProvince("SAO PAULO")
                                .WithBillingZIPcode("03303-000")
                                .Build())
                            .Build())
                    .WithGrandTotalRetailPrice(100)
                    .WithTotalRetailPriceDiscountAmount(0)
                    .WithServiceCode("TESTESERVICE")                   
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };

            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>();
            request.Services.ForEach(p => request.Invoices.Add(p.Invoice));
            new GetAccountingAccountHandler().ProcessRequest(request);

            new LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 1);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Count == 2);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").LaunchValue == 100);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").LaunchValue == 100);
        }

        [Fact]
        public void ReturnFourFinancialAccountTwoStates()
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

            request.Services = new List<ServiceFilter>
            {
                new ServiceFilterBuilder()
                    .WithInvoice(
                        InvoiceBuilder
                            .New()
                            .WithCustomer(CustomerBuilder.New()
                                .WithBillingStateOrProvince("SAO PAULO")
                                .WithBillingZIPcode("03303-000")
                                .Build())
                            .Build())
                    .WithGrandTotalRetailPrice(100)
                    .WithTotalRetailPriceDiscountAmount(0)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),

                    new ServiceFilterBuilder()
                    .WithInvoice(
                        InvoiceBuilder
                            .New()
                            .WithCustomer(CustomerBuilder.New()
                                .WithBillingStateOrProvince("RIO DE JANEIRO")
                                .WithBillingZIPcode("09090-000")
                                .Build())
                            .Build())
                    .WithGrandTotalRetailPrice(150)
                    .WithTotalRetailPriceDiscountAmount(0)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };

            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>();
            request.Services.ForEach(p => request.Invoices.Add(p.Invoice));
            new GetAccountingAccountHandler().ProcessRequest(request);

            new LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 1);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Count == 4);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "C").LaunchValue == 100);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "D").LaunchValue == 100);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "C").LaunchValue == 150);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "D").LaunchValue == 150);
        }

        [Fact]
        public void ReturnOneInvoiceTwoService()
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

            var uniqueInvoice = InvoiceBuilder.New()
                .WithTotalInvoicePrice(100)
                .WithCustomer(CustomerBuilder.New()
                    .WithBillingStateOrProvince("SAO PAULO")
                    .WithBillingZIPcode("03303-000")
                    .Build())
                .Build();

            request.Services = new List<ServiceFilter>
            {
                new ServiceFilterBuilder()
                    .WithInvoice(uniqueInvoice)
                    .WithGrandTotalRetailPrice(100)
                    .WithTotalRetailPriceDiscountAmount(0)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(uniqueInvoice)
                    .WithGrandTotalRetailPrice(150)
                    .WithTotalRetailPriceDiscountAmount(0)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };

            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>();
            request.Invoices.Add(uniqueInvoice);
            new GetAccountingAccountHandler().ProcessRequest(request);

            new LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 1);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").LaunchValue == 250);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").LaunchValue == 250);
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

            var invoiceSP = InvoiceBuilder.New()
                .WithTotalInvoicePrice(100)
                .WithCustomer(CustomerBuilder.New()
                    .WithBillingStateOrProvince("SAO PAULO")
                    .WithBillingZIPcode("03303-000")
                    .Build())
                .Build();

            var invoiceRJ = InvoiceBuilder.New()
                .WithCustomer(CustomerBuilder.New()
                    .WithBillingStateOrProvince("RIO DE JANEIRO")
                    .WithBillingZIPcode("09090-000")
                    .Build())
                .Build();

            request.Services = new List<ServiceFilter>
            {
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceSP)
                    .WithGrandTotalRetailPrice(100)
                    .WithTotalRetailPriceDiscountAmount(10)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceSP)
                    .WithGrandTotalRetailPrice(150)
                    .WithTotalRetailPriceDiscountAmount(20)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceRJ)
                    .WithGrandTotalRetailPrice(120)
                    .WithTotalRetailPriceDiscountAmount(10)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceRJ)
                    .WithGrandTotalRetailPrice(150)
                    .WithTotalRetailPriceDiscountAmount(20)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };
            request.Services.ForEach(service => service.TotalDiscount = service.TotalRetailPriceDiscountAmount);
            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>() { invoiceSP, invoiceRJ };
            new GetAccountingAccountHandler().ProcessRequest(request);

            new LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 1);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Count == 8);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "C").LaunchValue == 280);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "D").LaunchValue == 280);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "C").LaunchValue == 30);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "D").LaunchValue == 30);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "C").LaunchValue == 300);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "D").LaunchValue == 300);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "C").LaunchValue == 30);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "D").LaunchValue == 30);
        }

        [Theory]
        [InlineData("São Paulo", "04802080", "SP")]
        public void ReturnUF(string stateOrProvince, string zipCode, string UF)
        {
            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow)
            {
                Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>() {
                    InvoiceBuilder
                    .New()
                    .WithCustomer(CustomerBuilder.New().WithBillingStateOrProvince(stateOrProvince).WithBillingZIPcode(zipCode).Build())
                    .Build()
                }
            };

            new GetAddressHandler(dne).ProcessRequest(request);

            Assert.True(UF == (request.Address.Where(f => f.Cep.Equals(zipCode)).Select(v => v.Uf).FirstOrDefault() ?? Util.GetUFByState(stateOrProvince)));
        }

        [Fact]
        public void ReturnFinnancialAccountStoreCloudCoProviderTBRA()
        {
            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), DateTime.UtcNow);

            request.Files.Add(FileBuilder.New().Build());

            request.FinancialAccounts = new List<FinancialAccount>{
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("CloudCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(true)
                    .WithInterfaceType("Billed")
                    .WithAccountType("Billed")
                    .WithFinancialAccountType("FATO365CSPGW")
                    .WithFinancialAccountDeb("41435025")
                    .WithFinancialAccountCred("11215115")
                    .Build(),

                FinancialAccountBuilder.New()
                    .WithStoreAcronym("CloudCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(true)
                    .WithInterfaceType("Billed")
                    .WithAccountType("Discount")
                    .WithFinancialAccountType("DESCO365CSPGW")
                    .WithFinancialAccountDeb("41435025")
                    .WithFinancialAccountCred("11215115")
                    .Build()
            };

            request.Services = new List<ServiceFilter>
            {
                new ServiceFilterBuilder()
                    .WithInvoice(
                        InvoiceBuilder
                            .New()
                            .WithTotalInvoicePrice(100)
                            .WithStoreAcronym("CloudCo")
                            .WithCustomer(CustomerBuilder.New()
                                .WithBillingStateOrProvince("SAO PAULO")
                                .WithBillingZIPcode("03303-000")
                                .Build())
                            .Build())
                    .WithGrandTotalRetailPrice(100)
                    .WithTotalRetailPriceDiscountAmount(0)
                    .WithTotalDiscount(10)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("CloudCo")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };

            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>();
            request.Services.ForEach(p => request.Invoices.Add(p.Invoice));
            new GetAccountingAccountHandler().ProcessRequest(request);

            new LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 2);

            var lines = request.Lines[StoreType.TLF2];

            Assert.True(lines.Count == 4);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").Type == "FATINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").Type == "FATINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").BillingOption == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").BillingOption == "");

            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "C").Type == "FATINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "D").Type == "FATINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "C").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "D").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "C").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "D").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "C").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "D").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "C").BillingOption == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "D").BillingOption == "");
        }
    }
}
