using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarACM;
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

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FATaFaturarACM.Handler
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    [Collection("H")]
    public class LaunchHandlerAFaturarACMTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IUniqueStoreFinancialAccount uniqueStoreFinancialAccount;

        public LaunchHandlerAFaturarACMTest(Fixture.ApplicationFixture fixture)
        {
            this.uniqueStoreFinancialAccount = fixture.Container.Resolve<IUniqueStoreFinancialAccount>(); ;
        }

        [Fact]
        public void ReturnFourFinnancialAccountTwoFatAndTwoDescWithoutFATFaturado()
        {
            var dateNow = DateTime.UtcNow;
            var dateBillTo = new DateTime(dateNow.Year, dateNow.Month, 26);

            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FATAFATURARACM, Guid.NewGuid(), DateTime.UtcNow);

            request.Files.Add(FileBuilder.New().Build());

            request.FinancialAccounts = new List<FinancialAccount>{
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Billing")                    
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
                    .WithInterfaceType("Billing")                    
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

            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").LaunchValue == 12);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").LaunchValue == 12);
        }

        [Fact]
        public void ReturnFourFinnancialAccountTwoFatAndTwoDescWithFATFaturado()
        {
            var dateNow = DateTime.UtcNow;
            var dateBillTo = new DateTime(dateNow.Year, dateNow.Month, 26);
            var datePreviousMonth = dateBillTo.AddMonths(-1);

            // FAT a Faturar
            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FATAFATURARACM, Guid.NewGuid(), dateBillTo);

            request.Files.Add(FileBuilder.New().Build());

            request.FinancialAccounts = new List<FinancialAccount>{
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Billing")                    
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
                    .WithInterfaceType("Billing")                    
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
                    .WithTotalDiscount(0)
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

            // FAT Faturado, mes anterior
            FATRequest requestAFaturar = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), datePreviousMonth);

            request.Files.Add(FileBuilder.New().Build());
            requestAFaturar.FinancialAccounts = new List<FinancialAccount>{
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

            requestAFaturar.Services = new List<ServiceFilter>
            {
                new ServiceFilterBuilder()
                    .WithInvoice(
                        InvoiceBuilder.New()
                        .WithTotalInvoicePrice(120)
                        .WithBillTo(dateBillTo)
                        .WithStoreAcronym("telerese")
                        .WithCustomer(CustomerBuilder.New()
                                        .WithBillingStateOrProvince("SAO PAULO")
                                        .WithBillingZIPcode("03303-000")
                                        .Build())
                        .Build())
                    .WithGrandTotalRetailPrice(120)
                    .WithTotalDiscount(0)
                    .WithTotalRetailPriceDiscountAmount(0)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")                    
                    .Build()
            };

            requestAFaturar.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>();
            requestAFaturar.Services.ForEach(p => requestAFaturar.Invoices.Add(p.Invoice));
            new GetAccountingAccountHandler().ProcessRequest(requestAFaturar);

            new SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH.LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(requestAFaturar);

            request.LaunchEstimativas = requestAFaturar.LaunchItems;

            new LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 1);

            var lines = request.Lines[StoreType.TBRA];

            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").LaunchValue == 12);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").LaunchValue == 12);
        }

        [Fact]
        public void ReturnTwoInvoiceFourServiceWithDiscount()
        {
            var dateNow = DateTime.UtcNow;
            var dateBillTo = new DateTime(dateNow.Year, dateNow.Month, 26);
            var datePreviousMonth = dateBillTo.AddMonths(-1);
            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FATAFATURARACM, Guid.NewGuid(), dateBillTo);
            request.Files.Add(FileBuilder.New().Build());
            request.FinancialAccounts = new List<FinancialAccount>{
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("telerese")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(false)
                    .WithInterfaceType("Billing")
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
                    .WithInterfaceType("Billing")
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
                    .Build()
            };
            request.Services.ForEach(service => service.TotalDiscount = service.TotalRetailPriceDiscountAmount);
            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>() { invoiceSP, invoiceRJ };
            // FAT Faturado, mes anterior
            FATRequest requestAFaturar = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FAT, Guid.NewGuid(), datePreviousMonth);
            requestAFaturar.Files.Add(FileBuilder.New().Build());
            requestAFaturar.FinancialAccounts = new List<FinancialAccount>
            {
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
            var invoiceSPFaturado = InvoiceBuilder.New()
                    .WithTotalInvoicePrice(120)
                    .WithBillTo(datePreviousMonth)
                    .WithPaymentMethod("Boleto")
                    .WithStoreAcronym("telerese")
                    .WithCustomer(CustomerBuilder.New()
                                    .WithBillingStateOrProvince("SAO PAULO")
                                    .WithBillingZIPcode("03303-000")
                                    .Build())
                    .Build();
            requestAFaturar.Services = new List<ServiceFilter>
            {
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceSPFaturado)
                    .WithGrandTotalRetailPrice(120)
                    .WithTotalRetailPriceDiscountAmount(30)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invoiceSPFaturado)
                    .WithGrandTotalRetailPrice(180)
                    .WithTotalRetailPriceDiscountAmount(30)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };
            new GetAccountingAccountHandler().ProcessRequest(request);
            requestAFaturar.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>();
            requestAFaturar.Services.ForEach(p => requestAFaturar.Invoices.Add(p.Invoice));
            new GetAccountingAccountHandler().ProcessRequest(requestAFaturar);
            new SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH.LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(requestAFaturar);
            request.LaunchEstimativas = requestAFaturar.LaunchItems;
            new LaunchHandler(uniqueStoreFinancialAccount).ProcessRequest(request);
            Assert.True(request.Lines.Count == 1);
            var lines = request.Lines[StoreType.TBRA];
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "D").LaunchValue == 48);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("SP") && p.AccountingEntry == "C").LaunchValue == 48);          
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "D").LaunchValue == 12);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.UF.Equals("RJ") && p.AccountingEntry == "C").LaunchValue == 12);
           
        }

        [Fact]
        public void ReturnFinnancialAccountStoreCloudCoProviderTBRA()
        {
            var dateNow = DateTime.UtcNow;
            var dateBillTo = new DateTime(dateNow.Year, dateNow.Month, 26);

            FATRequest request = new FATRequest(Messaging.Messages.File.Enum.TypeRegister.FATAFATURARACM, Guid.NewGuid(), DateTime.UtcNow);
            
            request.Files.Add(FileBuilder.New().Build());

            request.FinancialAccounts = new List<FinancialAccount>{
                FinancialAccountBuilder.New()
                    .WithStoreAcronym("CloudCo")
                    .WithServiceCode("TESTESERVICE")
                    .WithProviderCompanyAcronym("telerese")
                    .WithHaveIntercompany(true)
                    .WithInterfaceType("Billing")                    
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
                    .WithInterfaceType("Billing")                    
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

            Assert.True(lines.Count == 2);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").Type == "ACMINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").Type == "ACMINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "C").BillingOption == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("FATO365CSPGW") && p.AccountingEntry == "D").BillingOption == "");
            
        }
    }
}
