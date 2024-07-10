using Autofac;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.UseCases.GF.Master;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Gcsb.Connect.SAP.Tests.Builders;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.Master
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class MasterUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IMasterUseCase MasterUseCase;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private static Guid idFileReturnNF;

        public MasterUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.MasterUseCase = fixture.Container.Resolve<IMasterUseCase>();
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
            this.returnNFWriteOnlyRepository = fixture.Container.Resolve<IReturnNFWriteOnlyRepository>();
            this.fileWriteOnlyRepository = fixture.Container.Resolve<IFileWriteOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
            this.fileReadOnlyRepository = fixture.Container.Resolve<IFileReadOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void InvoiceAddMany()
        {
            File file = FileBuilder
                .New()
                .WithType(TypeRegister.BILLCSV)
                .WithStatus(Status.Success)
                .WithId(Guid.NewGuid())
                .Build();
            fileWriteOnlyRepository.Add(file);  

            Assert.True(invoiceWriteOnlyRepository.Add(Fixture.ApplicationFixture.Invoices("INV-008")) > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void NFAddMany()
        {
            Guid idparent = fileReadOnlyRepository.GetFiles(TypeRegister.BILLCSV,
                Status.Success).FirstOrDefault().Id;

            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithInvoiceID("INV-0081").WithFile(FileBuilder.New().WithId(idparent).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-0082").WithFile(FileBuilder.New().WithId(idparent).Build()).Build(),
            };

            idFileReturnNF = model.Select(s => s.FileId).FirstOrDefault();
            Assert.True(returnNFWriteOnlyRepository.Add(model) > 0);
        }

        [Fact]
        [Trait("Action", "Execute")]
        [TestPriority(1)]
        public void ShouldExecuteUseCase()
        {
            Guid idparent = fileReadOnlyRepository.GetFiles(TypeRegister.BILLCSV,
                Status.Success).FirstOrDefault().Id;

            Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");

            var request = new MasterRequest(idFileReturnNF);
            request.File = FileBuilder.New().WithIdParent(idparent).Build();

            MasterUseCase.Execute(request);

            Assert.True(request.Invoices.Count > 0);
            Assert.True(request.Masters.Count > 0);
            Assert.True(request.Logs.Count > 0);
        }

        [Fact]
        [Trait("Action", "Exception")]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MasterUseCase.Execute(null));
        }
    }
}
