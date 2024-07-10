using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.IndividualReportService
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class IndividualReportServiceUseCaseTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IISIUseCase ISIUseCase; 
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IFileGenerator<ISIObj> fileGenerator;
        private readonly IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository;
        private static ISIChainRequest requestChain;

        public IndividualReportServiceUseCaseTests(Fixture.ApplicationFixture fixture)
        {
            this.ISIUseCase = fixture.Container.Resolve<IISIUseCase>(); 
            this.invoiceReadOnlyRepository = fixture.Container.Resolve<IInvoiceReadOnlyRepository>();
            this.fileWriteOnlyRepository = fixture.Container.Resolve<IFileWriteOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
            this.returnNFWriteOnlyRepository = fixture.Container.Resolve<IReturnNFWriteOnlyRepository>();
            this.fileGenerator = fixture.Container.Resolve<IFileGenerator<ISIObj>>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void InvoiceAddMany()
        { 

            var invoices = new List<Invoice>()
            {
                InvoiceBuilder.New().WithInvoiceNumber("INV-0501")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0521").Build()).WithIndividualInvoice("S").Build())
                    .WithServices(Fixture.ApplicationFixture.ServiceInvoices.Select(i=> i.Build()).ToList())
                    .Build(),
                InvoiceBuilder.New().WithInvoiceNumber("INV-0502")
                    .WithCustomer(CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0522").Build()).WithIndividualInvoice("S").Build())
                    .WithServices(Fixture.ApplicationFixture.ServiceInvoices.Select(i=> i.Build()).ToList())
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
                new ReturnNFBuilder().WithInvoiceID("INV-0501").WithNumeroNF("123").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-0502").WithNumeroNF("456").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
            };
            var idFileReturnNF = model.Select(s => s.FileId).FirstOrDefault();
            requestChain = new ISIChainRequest(idFileReturnNF);
            Assert.True(returnNFWriteOnlyRepository.Add(model) > 0);
        }

        [Fact]
        [Trait("Action", "Read")]
        [TestPriority(2)]
        public void ShouldExecutePrepareDataHandler()
        {
            new PrepareDataHandler(invoiceReadOnlyRepository).ProcessRequest(requestChain);
            Assert.True(requestChain.Lines.Count > 0 && requestChain.Lines != null);
        }

        [Fact]
        [Trait("Action", "Add")]
        [TestPriority(3)]
        public void ShouldExecuteGetFileNameHandler()
        {
            new GetFileNameHandler().ProcessRequest(requestChain);
            Assert.True(!string.IsNullOrEmpty(requestChain.ISIFileName));
        }

        [Fact]
        [Trait("Action", "Add")]
        [TestPriority(4)]
        public void ShouldExecuteSaveFileHandler()
        {
            new SaveFileHandler(fileWriteOnlyRepository).ProcessRequest(requestChain);
            Assert.True(requestChain.ISIFile != null && requestChain.ISIFile?.Id != default(Guid));
        }

        [Fact]
        [Trait("Action", "Add")]
        [TestPriority(5)]
        public void ShouldExecuteCreateISIFileHandler()
        {
            new CreateISIFileHandler(fileGenerator).ProcessRequest(requestChain);
            Assert.True(!string.IsNullOrEmpty(requestChain.ISIDoc));
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(6)]
        public void ShouldExecuteSaveISIHandler()
        {
            Guid newGuid = Guid.NewGuid();
            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithInvoiceID("INV-0501").WithNumeroNF("123").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-0502").WithNumeroNF("456").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
            };

            var file = FileBuilder.New().Build();
            var idFileReturnNF = model.Select(s => s.FileId).FirstOrDefault();
            requestChain = new ISIChainRequest(idFileReturnNF);

            requestChain.ISIFile = file;
            requestChain.ISIFileName = file.FileName;
            new SaveISIHandler(fileGenerator).ProcessRequest(requestChain);
            Assert.True(requestChain.OutputSuccessfully);
        }

        [Fact]
        [Trait("Action", "Execute")]
        [TestPriority(7)]
        public void ShouldExecuteISIRequest()
        {
            Guid newGuid = Guid.NewGuid();
            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithInvoiceID("INV-0501").WithNumeroNF("123").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-0502").WithNumeroNF("456").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
            };

            var file = FileBuilder.New().Build();

            var idFileReturnNF = model.Select(s => s.FileId).FirstOrDefault();
            requestChain = new ISIChainRequest(idFileReturnNF);

            requestChain.ISIFile = file;
            requestChain.ISIFileName = file.FileName;

            ISIRequest request = new ISIRequest(requestChain.IdFile);
            var ret = ISIUseCase.Execute(request);
            //Assert.True(ret == 1);
        }
    }
}
