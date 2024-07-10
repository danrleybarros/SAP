using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook;
using Gcsb.Connect.SAP.Domain.Config;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.Config;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.AxiliaryBook
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class AxiliaryBookTest : IClassFixture<Fixture.ApplicationFixture>
    {
        public readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository;
        private readonly IAxiliaryBookUseCase axiliaryBookUseCase;
        private readonly IFinancialAccountWriteOnlyRepository financialAccountWriteOnlyRepository;
        private static Guid idFileReturnNF = Guid.NewGuid();

        public AxiliaryBookTest(Fixture.ApplicationFixture fixture)
        {
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
            this.returnNFWriteOnlyRepository = fixture.Container.Resolve<IReturnNFWriteOnlyRepository>();
            this.axiliaryBookUseCase = fixture.Container.Resolve<IAxiliaryBookUseCase>();
            this.financialAccountWriteOnlyRepository = fixture.Container.Resolve<IFinancialAccountWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void InvoiceAddMany()
        {

            var customers = new List<Customer>()
            {
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0001").Build()).WithIndividualInvoice("S").Build(),
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0002").Build()).WithIndividualInvoice("S").Build()
            };

            var services1 = new List<ServiceInvoice>()
            {
                ServiceBuilder.New().WithServiceCode("office365").WithServiceName("Office 365 Business Essentials").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-0001")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0001").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-0001")
                    .Build(),

                ServiceBuilder.New().WithServiceCode("AzureAdvancedThreatProtectionforUsers").WithServiceName("Azure Advanced Threat Protection for Users").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-0001")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0001").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-0001")
                    .Build(),

               ServiceBuilder.New().WithServiceCode("Dynamics365AIforSales").WithServiceName("Dynamics365AIforSales	Dynamics 365 AI for Sales").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-0001")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0001").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-0001")
                    .Build(),
            };

            var services2 = new List<ServiceInvoice>()
            {
               ServiceBuilder.New().WithServiceCode("microsoftazureubuntustack").WithServiceName("MicrosoftAzure Ubuntu Stack").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-0002")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0002").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-0002")
                    .Build(),

                ServiceBuilder.New().WithServiceCode("microsoftazurewindowsstack").WithServiceName("MicrosoftAzure Windows Stack").WithGrandTotalRetailPrice(666).WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-0002")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0002").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-0002")
                    .Build(),

                ServiceBuilder.New().WithServiceCode("microsoftazurewindowsstack").WithServiceName("MicrosoftAzure Windows Stack").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-0002")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0002").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-0002")
                    .Build(),
            };

            var invoices = new List<Invoice>()
            {
                InvoiceBuilder.New().WithInvoiceNumber("INV-0001")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0001").Build()).WithIndividualInvoice("S").Build())
                    .WithServices(services1)
                    .Build(),
                InvoiceBuilder.New().WithInvoiceNumber("INV-0002")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0002").Build()).WithIndividualInvoice("S").Build())
                    .WithServices(services2)
                    .Build(),
            };

            Assert.True(invoiceWriteOnlyRepository.Add(invoices) > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(1)]
        public void NFAddMany()
        {

            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithInvoiceID("INV-0001").WithNumeroNF("123").WithFile(Builders.FileBuilder.New().WithId(idFileReturnNF).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-0002").WithNumeroNF("456").WithFile(Builders.FileBuilder.New().WithId(idFileReturnNF).Build()).Build(),
            };

            Assert.True(returnNFWriteOnlyRepository.Add(model) > 0);
        }


        [Fact]
        [TestPriority(0)]
        public void ShouldAddManyFinancialAccounts()
        {
            var accounts = new List<FinancialAccount>()
            {
                FinancialAccountBuilder.New().WithServiceCode("office365")
                .WithFaturamentoFAT("FATOFFICE365GW").Build(),
                 FinancialAccountBuilder.New().WithServiceCode("AzureAdvancedThreatProtectionforUsers")
                .WithFaturamentoFAT("FATOFFICE365GW").Build(),
                 FinancialAccountBuilder.New().WithServiceCode("Dynamics365AIforSales")
                .WithFaturamentoFAT("FATOFFICE365GW").Build(),

                FinancialAccountBuilder.New().WithServiceCode("microsoftazureubuntustack")
                .WithFaturamentoFAT("FATCLOUDGW").Build(),

                 FinancialAccountBuilder.New().WithServiceCode("microsoftazurewindowsstack")
                .WithFaturamentoFAT("FATCLOUDGW").Build(),

            };

            Assert.True(financialAccountWriteOnlyRepository.Add(accounts) > 0);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(2)]
        public void ShouldCreateBookAxiliaryUseCase()
        {
            var request = new AxiliaryBookRequest(idFileReturnNF);
            axiliaryBookUseCase.Execute(request);

            Assert.NotNull(request.Logs);
            Assert.NotNull(request.File);
        }

    }
}
