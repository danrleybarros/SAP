using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
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

namespace Gcsb.Connect.SAP.Tests.Cases.Application.FATaFaturarECM.Handler
{
    public class LaunchContractualFineHandlerTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IUniqueStoreFinancialAccount uniqueStoreFinancialAccount;

        public LaunchContractualFineHandlerTests(Fixture.ApplicationFixture fixture)
        {
            this.uniqueStoreFinancialAccount = fixture.Container.Resolve<IUniqueStoreFinancialAccount>(); ;
        }

        [Fact]
        public void ExecuteLaunchAndGet4LaunchesAsExpected()
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
                    .WithAccountType("ContractualFine")
                    .WithFinancialAccountType("MULTACONTRATFAT")
                    .WithFinancialAccountDeb("41951119")
                    .WithFinancialAccountCred("11215115")
                    .Build()
            };

            new GetContractualFineAccountHandler().ProcessRequest(request);

            var invSP = InvoiceBuilder.New()
                        .WithInvoiceNumber("123")
                        .WithTotalInvoicePrice(100)                        
                        .WithStoreAcronym("telerese")
                        .WithCustomer(CustomerBuilder.New()
                                        .WithBillingStateOrProvince("SAO PAULO")
                                        .WithBillingZIPcode("03303-000")
                                        .Build())
                        .Build();

            var invSC = InvoiceBuilder.New()
            .WithInvoiceNumber("456")            
            .WithStoreAcronym("telerese")
            .WithCustomer(CustomerBuilder.New()
                            .WithBillingStateOrProvince("SANTA CATARINA")
                            .WithBillingZIPcode("01330-010")
                            .Build())
            .Build();
                        
            request.ContractualFineServices = new List<ServiceFilter>
            {
                new ServiceFilterBuilder()
                    .WithInvoice(invSP)
                    .WithGrandTotalRetailPrice(50)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invSP)
                    .WithGrandTotalRetailPrice(80)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invSC)
                    .WithGrandTotalRetailPrice(90)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invSC)
                    .WithGrandTotalRetailPrice(10)
                    .WithServiceCode("TESTESERVICE")                    
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("telerese")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };

            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>() { invSP, invSC };
            new LaunchContractualFineHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 1);
            var lines = request.Lines[StoreType.TBRA];
            Assert.True(lines.Count == 4);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").LaunchValue == 130);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").LaunchValue == 130);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").LaunchValue == 100);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").LaunchValue == 100);
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
                    .WithAccountType("ContractualFine")
                    .WithFinancialAccountType("MULTACONTRATFAT")
                    .WithFinancialAccountDeb("41951119")
                    .WithFinancialAccountCred("11215115")
                    .Build()
            };

            new GetContractualFineAccountHandler().ProcessRequest(request);

            var invSP = InvoiceBuilder.New()
                .WithInvoiceNumber("123")
                .WithTotalInvoicePrice(100)
                .WithStoreAcronym("CloudCo")
                .WithCustomer(CustomerBuilder.New()
                    .WithBillingStateOrProvince("SAO PAULO")
                    .WithBillingZIPcode("03303-000")
                    .Build())
                .Build();

            var invSC = InvoiceBuilder.New()
                .WithInvoiceNumber("456")
                .WithStoreAcronym("CloudCo")
                .WithCustomer(CustomerBuilder.New()
                    .WithBillingStateOrProvince("SANTA CATARINA")
                    .WithBillingZIPcode("01330-010")
                    .Build())
                .Build();

            request.ContractualFineServices = new List<ServiceFilter>
            {
                new ServiceFilterBuilder()
                    .WithInvoice(invSP)
                    .WithGrandTotalRetailPrice(50)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("CloudCo")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invSP)
                    .WithGrandTotalRetailPrice(80)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("CloudCo")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invSC)
                    .WithGrandTotalRetailPrice(90)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("CloudCo")
                    .WithProviderCompanyAcronym("telerese")
                    .Build(),
                new ServiceFilterBuilder()
                    .WithInvoice(invSC)
                    .WithGrandTotalRetailPrice(10)
                    .WithServiceCode("TESTESERVICE")
                    .WithServiceType("SaaS")
                    .WithStoreAcronym("CloudCo")
                    .WithProviderCompanyAcronym("telerese")
                    .Build()
            };

            request.Invoices = new List<SAP.Domain.JSDN.BillFeedSplit.Invoice>() { invSP, invSC };
            new LaunchContractualFineHandler(uniqueStoreFinancialAccount).ProcessRequest(request);

            Assert.True(request.Lines.Count == 2);
            var lines = request.Lines[StoreType.TLF2];

            Assert.True(lines.Count == 4);
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").Type == "FATINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").Type == "FATINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").BillingOption == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SP") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").BillingOption == "");

            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").Type == "FATINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").Type == "FATINT");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").CostCenter == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").InternalOrder == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").PaymentMethod == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "C" && p.AccountingAccount == "11215115").BillingOption == "");
            Assert.True(lines.Find(p => p.FinancialAccount.Equals("MULTACONTRATFAT") && p.UF.Equals("SC") && p.AccountingEntry == "D" && p.AccountingAccount == "41951119").BillingOption == "");                        
        }

    }
}
