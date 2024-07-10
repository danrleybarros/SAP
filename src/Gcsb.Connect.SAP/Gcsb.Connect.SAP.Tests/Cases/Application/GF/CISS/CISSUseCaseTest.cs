using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Config;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using Gcsb.Connect.SAP.Application.UseCases.GF;
using Gcsb.Connect.SAP.Application.UseCases.GF.CISS;
using System;
using Xunit;
using System.IO;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using System.Linq;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using MassTransit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.CISS
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class CISSUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        public readonly IBillFeedReadCsvRepository billFeedReadCsvRepository;
        private readonly IBillFeedUseCase billFeedUC;
        private readonly IReturnNFReadCsvRepository returnNFReadCsvRepository;
        public readonly IFileGenerator<CISSRequest> fileGenerator;
        public readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;
        public readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        public readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        public readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        public readonly IFileReadOnlyRepository fileReadOnlyRepository;
        public readonly IReturnNFReadOnlyRepository returnNFReadOnlyRepository;
        public readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;
        public readonly ICISSUseCase cissUseCase;
        private readonly IFinancialAccountWriteOnlyRepository financialAccountWrite;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository;
        private readonly IReturnNFUseCase ReturnNFUC;
        private static Guid idFileReturnNF;

        public CISSUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.returnNFReadOnlyRepository = fixture.Container.Resolve<IReturnNFReadOnlyRepository>();
            this.returnNFReadCsvRepository = fixture.Container.Resolve<IReturnNFReadCsvRepository>();
            this.billFeedReadCsvRepository = fixture.Container.Resolve<IBillFeedReadCsvRepository>();
            this.billFeedUC = fixture.Container.Resolve<IBillFeedUseCase>();
            this.invoiceReadOnlyRepository = fixture.Container.Resolve<IInvoiceReadOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
            this.fileGenerator = fixture.Container.Resolve<IFileGenerator<CISSRequest>>();
            this.fileWriteOnlyRepository = fixture.Container.Resolve<IFileWriteOnlyRepository>();
            this.logWriteOnlyRepository = fixture.Container.Resolve<ILogWriteOnlyRepository>();
            this.fileReadOnlyRepository = fixture.Container.Resolve<IFileReadOnlyRepository>();
            this.serviceInvoiceReadOnlyRepository = fixture.Container.Resolve<IServiceInvoiceReadOnlyRepository>();
            this.ReturnNFUC = fixture.Container.Resolve<IReturnNFUseCase>();
            this.cissUseCase = fixture.Container.Resolve<ICISSUseCase>();
            this.financialAccountWrite = fixture.Container.Resolve<IFinancialAccountWriteOnlyRepository>();
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
            this.returnNFWriteOnlyRepository = fixture.Container.Resolve<IReturnNFWriteOnlyRepository>();
        }
        

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void InvoiceAddMany()
        {

            var customers = new List<Customer>()
            {
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-00001").Build()).WithIndividualInvoice("S").Build(),
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-00002").Build()).WithIndividualInvoice("S").Build()            
            };

            var services1 = new List<ServiceInvoice>()
            {
                Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithServiceCode("azuremonth").WithServiceName("Azure").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-00001")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-00001").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-00001")
                    .Build(),

                Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithServiceCode("azuremonth").WithServiceName("Azure").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-00001")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-00001").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-00001")
                    .Build(),

                Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithServiceCode("windowsyear").WithServiceName("Windows").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-00001")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-00001").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-00001")
                    .Build(),
            };

            var services2 = new List<ServiceInvoice>()
            {
                Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithServiceCode("azuremonth").WithServiceName("Azure").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-00002")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-00002").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-00002")
                    .Build(),

                Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithServiceCode("azuremonth").WithServiceName("Azure").WithGrandTotalRetailPrice(666).WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-00002")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-00002").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-00002")
                    .Build(),

                Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithServiceCode("windowsyear").WithServiceName("Windows").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-00002")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-00002").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-00002")
                    .Build(),
            };

            var invoices = new List<Invoice>()
            {
                InvoiceBuilder.New().WithInvoiceNumber("INV-00001")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-00001").Build()).WithIndividualInvoice("S").Build())
                    .WithServices(services1)
                    .Build(),
                InvoiceBuilder.New().WithInvoiceNumber("INV-00002")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-00002").Build()).WithIndividualInvoice("S").Build())
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
            Guid newGuid = Guid.NewGuid();
            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithInvoiceID("INV-00001").WithNumeroNF("123").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-00002").WithNumeroNF("456").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
            };
            idFileReturnNF = model.Select(s => s.FileId).FirstOrDefault();
            Assert.True(returnNFWriteOnlyRepository.Add(model) > 0);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(2)]
        public void ShouldCreateCISSUseCase()
        {
            Guid newGuid = Guid.NewGuid();

            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithInvoiceID("INV-00001").WithNumeroNF("123").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-00002").WithNumeroNF("456").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
            };

            idFileReturnNF = model.Select(s => s.FileId).FirstOrDefault();

            var request = new CISSRequest(idFileReturnNF);
            Assert.True(cissUseCase.Execute(request) > 0);
        }
    }
}
