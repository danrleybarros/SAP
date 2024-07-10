using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarECM;
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

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FATaFaturarECM.Handler
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("H")]
    public class LaunchHandlerAFaturarECMTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IUniqueStoreFinancialAccount uniqueStoreFinancialAccount;

        public LaunchHandlerAFaturarECMTest(Fixture.ApplicationFixture fixture)
        {
            this.uniqueStoreFinancialAccount = fixture.Container.Resolve<IUniqueStoreFinancialAccount>();
        }

        [Fact]
        public void ReturnTwoFinnancialAccountTwoFatAndWithoutDesc()
        {
            var dateNow = DateTime.UtcNow;
            var dateBillTo = new DateTime(dateNow.Year, dateNow.Month, 26);

            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FATAFATURARECM, Guid.NewGuid(), DateTime.UtcNow);

            request.Files.Add(FileBuilder.New().Build());

            request.FinancialAccounts = new List<FinancialAccount>{
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("CycleEstimation")
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
                    .WithInterfaceType("CycleEstimation")
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
                        InvoiceBuilder.New()
                        .WithTotalInvoicePrice(100)
                        .WithBillTo(dateBillTo)
                        .WithStoreAcronym("telerese")
                        .WithCustomer(CustomerBuilder.New()
                                        .WithBillingStateOrProvince("SAO PAULO")
                                        .WithBillingZIPcode("03303-000")
                                        .Build())
                        .Build())
                    .WithGrandTotalRetailPrice(90)
                    .WithTotalRetailPriceDiscountAmount(0)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };

            new GetAccountingAccountHandler().ProcessRequest(request);

            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>();
            request.Services.ForEach(p => request.Invoices.Add(p.Invoice));

            new LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 1);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Exists(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D"));
            Assert.True(lines.Exists(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C"));
            Assert.False(lines.Exists(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "D"));
            Assert.False(lines.Exists(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "C"));
        }

        [Fact]
        public void ReturnTwoFinnancialAccountTwoFatAndTwoDesc()
        {
            var dateNow = DateTime.UtcNow;
            var dateBillTo = new DateTime(dateNow.Year, dateNow.Month, 26);

            // FAT a Faturar
            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FATAFATURARECM, Guid.NewGuid(), dateBillTo);

            request.Files.Add(FileBuilder.New().Build());

            request.FinancialAccounts = new List<FinancialAccount>{
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("CycleEstimation")
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
                    .WithInterfaceType("CycleEstimation")
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
                        InvoiceBuilder.New()
                        .WithTotalInvoicePrice(100)
                        .WithBillTo(dateBillTo)
                        .WithStoreAcronym("telerese")
                        .WithCustomer(CustomerBuilder.New()
                                        .WithBillingStateOrProvince("SAO PAULO")
                                        .WithBillingZIPcode("03303-000")
                                        .Build())
                        .Build())
                    .WithGrandTotalRetailPrice(90)
                    .WithTotalRetailPriceDiscountAmount(30)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };

            new GetAccountingAccountHandler().ProcessRequest(request);

            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>();
            request.Services.ForEach(p => request.Invoices.Add(p.Invoice));
            request.Services.ForEach(service => service.TotalDiscount = service.TotalRetailPriceDiscountAmount);
            new LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 1);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").LaunchValue == 120);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").LaunchValue == 120);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "D").LaunchValue == 30);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "C").LaunchValue == 30);
        }

        [Fact]
        public void ReturnTwoInvoiceFourServiceWithDiscount()
        {
            var dateNow = DateTime.UtcNow;
            var dateBillTo = new DateTime(dateNow.Year, dateNow.Month, 26);

            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FATAFATURARECM, Guid.NewGuid(), dateBillTo);

            request.Files.Add(FileBuilder.New().Build());

            request.FinancialAccounts = new List<FinancialAccount>{
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("CycleEstimation")
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
                    .WithInterfaceType("CycleEstimation")
                    .WithAccountType("Discount")
                    .WithFinancialAccountType("DESCO365CSPGW")
                    .WithFinancialAccountDeb("41435025")
                    .WithFinancialAccountCred("11215115")
                    .Build()
            };

            var invoiceSP = InvoiceBuilder.New()
                        .WithTotalInvoicePrice(100)
                        .WithBillTo(dateBillTo)
                        .WithPaymentMethod("Boleto")
                        .WithStoreAcronym("telerese")
                        .WithCustomer(CustomerBuilder.New()
                                        .WithBillingStateOrProvince("SAO PAULO")
                                        .WithBillingZIPcode("03303-000")
                                        .Build())
                        .Build();

            var invoiceRJ = InvoiceBuilder.New()
                        .WithBillTo(dateBillTo)
                        .WithPaymentMethod("Boleto")
                        .WithStoreAcronym("telerese")
                        .WithCustomer(CustomerBuilder.New()
                                        .WithBillingStateOrProvince("RIO DE JANEIRO")
                                        .WithBillingZIPcode("09090-000")
                                        .Build())
                        .Build();

            request.Services = new List<ServiceFilter>
            {
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceSP)
                    .WithGrandTotalRetailPrice(270)
                    .WithTotalRetailPriceDiscountAmount(90)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceRJ)
                    .WithGrandTotalRetailPrice(60)
                    .WithTotalRetailPriceDiscountAmount(30)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
            };
            request.Services.ForEach(service => service.TotalDiscount = service.TotalRetailPriceDiscountAmount);
            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>() { invoiceSP, invoiceRJ };

            new GetAccountingAccountHandler().ProcessRequest(request);

            new LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 1);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "D").LaunchValue == 360);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "C").LaunchValue == 360);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "D").LaunchValue == 90);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "C").LaunchValue == 90);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "D").LaunchValue == 90);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "C").LaunchValue == 90);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "D").LaunchValue == 30);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "C").LaunchValue == 30);
        }

        [Fact]
        public void ReturnFinnancialAccountStoreCloudCoProviderTBRA()
        {
            var dateNow = DateTime.UtcNow;
            var dateBillTo = new DateTime(dateNow.Year, dateNow.Month, 26);

            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FATAFATURARECM, Guid.NewGuid(), DateTime.UtcNow);

            request.Files.Add(FileBuilder.New().Build());

            request.FinancialAccounts = new List<FinancialAccount>{
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("CloudCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(true)
                    .WithInterfaceType("CycleEstimation")
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
                    .WithInterfaceType("CycleEstimation")
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
                        InvoiceBuilder.New()
                        .WithTotalInvoicePrice(100)
                        .WithBillTo(dateBillTo)
                        .WithStoreAcronym("CloudCo")
                        .WithCustomer(CustomerBuilder.New()
                                        .WithBillingStateOrProvince("SAO PAULO")
                                        .WithBillingZIPcode("03303-000")
                                        .Build())
                        .Build())
                    .WithGrandTotalRetailPrice(90)
                    .WithTotalRetailPriceDiscountAmount(0)
                    .WithTotalDiscount(10)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("CloudCo")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),

                 new ServiceFilterBuilder()
                    .WithInvoice(
                        InvoiceBuilder.New()
                        .WithTotalInvoicePrice(100)
                        .WithBillTo(dateBillTo)
                        .WithStoreAcronym("telerese")
                        .WithCustomer(CustomerBuilder.New()
                                        .WithBillingStateOrProvince("SAO PAULO")
                                        .WithBillingZIPcode("03303-000")
                                        .Build())
                        .Build())
                    .WithGrandTotalRetailPrice(90)
                    .WithTotalRetailPriceDiscountAmount(0)
                    .WithTotalDiscount(10)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };

            new GetAccountingAccountHandler().ProcessRequest(request);

            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>();
            request.Services.ForEach(p => request.Invoices.Add(p.Invoice));

            new LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 2);

            var lines = request.Lines[StoreType.TLF2];

            Assert.True(lines.Count == 4);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").Type == "ECMINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").Type == "ECMINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").BillingOption == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").BillingOption == "");

            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "C").Type == "ECMINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("DESCO365CSPGW") && p.AccountingEntry == "D").Type == "ECMINT");
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
