using Autofac;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Application.UseCases.GF.Client;
using Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.Client
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class ClientUseCaseTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IClientUseCase clientUC;
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IFileGenerator<ClientObj> fileGenerator;
        private static ClientChainRequest requestChain;
        private readonly IDne dne;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public ClientUseCaseTests(Fixture.ApplicationFixture fixture)
        {
            this.invoiceReadOnlyRepository = fixture.Container.Resolve<IInvoiceReadOnlyRepository>();
            this.fileWriteOnlyRepository = fixture.Container.Resolve<IFileWriteOnlyRepository>();
            this.fileGenerator = fixture.Container.Resolve<IFileGenerator<ClientObj>>();
            this.clientUC = fixture.Container.Resolve<IClientUseCase>();
            this.dne = fixture.Container.Resolve<IDne>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
            this.returnNFWriteOnlyRepository = fixture.Container.Resolve<IReturnNFWriteOnlyRepository>();
            this.interfaceProgressUseCase = fixture.Container.Resolve<IInterfaceProgressUseCase>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void InvoiceAddMany()
        {
            var services1 = new List<ServiceInvoice>()
            {
                ServiceBuilder.New().WithServiceCode("azuremonth").WithServiceName("Azure").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-0013")
                    .WithCustomer(CustomerBuilder.New().WithBillingStateOrProvince("São Paulo").WithBillingZIPcode("18240-000").WithCustomerCode("00123").WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0001").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-0013")
                    .Build(),

                ServiceBuilder.New().WithServiceCode("windowsyear").WithServiceName("Windows").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-0013")
                    .WithCustomer(CustomerBuilder.New().WithBillingStateOrProvince("São Paulo").WithBillingZIPcode("18240-000").WithCustomerCode("00123").WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0001").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-0013")
                    .Build(),
            };

            var services2 = new List<ServiceInvoice>()
            {
                ServiceBuilder.New().WithServiceCode("azuremonth").WithServiceName("Azure").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-0014")
                    .WithCustomer(CustomerBuilder.New().WithBillingStateOrProvince("Espírito Santo").WithBillingZIPcode("11111-111").WithCustomerCode("00321").WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0002").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-0014")
                    .Build(),

                ServiceBuilder.New().WithServiceCode("windowsyear").WithServiceName("Windows").WithInvoice(
                    InvoiceBuilder.New().WithInvoiceNumber("INV-0014")
                    .WithCustomer(CustomerBuilder.New().WithBillingStateOrProvince("Espírito Santo").WithBillingZIPcode("11111-111").WithCustomerCode("00321").WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0002").Build()).WithIndividualInvoice("S").Build()).Build())
                    .WithInvoiceNumber("INV-0014")
                    .Build(),
            };

            var invoices = new List<Invoice>()
            {
                InvoiceBuilder.New().WithInvoiceNumber("INV-0013")
                    .WithCustomer(CustomerBuilder.New().WithBillingStateOrProvince("São Paulo").WithBillingZIPcode("18240-000").WithCustomerCode("00123").WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0001").Build()).WithIndividualInvoice("S").Build())
                    .WithServices(services1)
                    .Build(),
                InvoiceBuilder.New().WithInvoiceNumber("INV-0014")
                    .WithCustomer(CustomerBuilder.New().WithBillingStateOrProvince("Espírito Santo").WithBillingZIPcode("11111-111").WithCustomerCode("00321").WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0002").Build()).WithIndividualInvoice("S").Build())
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
                new ReturnNFBuilder().WithInvoiceID("INV-0013").WithNumeroNF("123").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-0014").WithNumeroNF("456").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
            };
            var idFileReturnNF = model.Select(s => s.FileId).FirstOrDefault();
            requestChain = new ClientChainRequest(idFileReturnNF);
            Assert.True(returnNFWriteOnlyRepository.Add(model) > 0);
        }

        [Fact]
        [Trait("Action", "Read")]
        [TestPriority(2)]
        public void ShouldExecuteGetInvoicesHandler()
        {
            new GetCustomersHandler(invoiceReadOnlyRepository).ProcessRequest(requestChain);
            Assert.True(requestChain.Customers != null && requestChain.Customers.Count > 0);
        }

        [Fact]
        [Trait("Action", "Read")]
        [TestPriority(3)]
        public void ShouldExecuteGetAdressHandler()
        {
            new GetAddressHandler(dne).ProcessRequest(requestChain);
            Assert.True(requestChain.Address != null && requestChain.Address.Count > 0);
        }


        [Fact]
        [Trait("Action", "Read")]
        [TestPriority(4)]
        public void ShouldExecutePrepareDataHandler()
        {
            new PrepareDataHandler().ProcessRequest(requestChain);
            Assert.True(requestChain.Clients != null && requestChain.Clients.Count > 0);
        }

        [Fact]
        [Trait("Action", "Add")]
        [TestPriority(5)]
        public void ShouldExecuteGetFileNameHandler()
        {
            new GetFileNameHandler().ProcessRequest(requestChain);
            Assert.True(!string.IsNullOrEmpty(requestChain.FileName));
        }

        [Fact]
        [Trait("Action", "Add")]
        [TestPriority(6)]
        public void ShouldExecuteSaveFileHandler()
        {
            new SaveFileHandler(fileWriteOnlyRepository, interfaceProgressUseCase).ProcessRequest(requestChain);
            Assert.True(requestChain.ClientFile != null && requestChain.ClientFile?.Id != default(Guid));
        }

        [Fact]
        [Trait("Action", "Add")]
        [TestPriority(7)]
        public void ShouldExecuteCreateClientHandler()
        {
            new CreateClientHandler(fileGenerator).ProcessRequest(requestChain);
            Assert.True(!string.IsNullOrEmpty(requestChain.ClientText));
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(8)]
        public void ShouldExecuteGenerateClientHandler()
        {
            Guid newGuid = Guid.NewGuid();
            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithInvoiceID("INV-0013").WithNumeroNF("123").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-0014").WithNumeroNF("456").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
            };

            var clientFile = Builders.FileBuilder.New().WithId(newGuid).Build();

            var idFileReturnNF = model.Select(s => s.FileId).FirstOrDefault();

            requestChain = new ClientChainRequest(idFileReturnNF);

            requestChain.ClientFile = clientFile;

            requestChain.FileName = clientFile.FileName;
            requestChain.ClientText = "teste";

            new GenerateClientHandler(fileGenerator).ProcessRequest(requestChain);
            Assert.True(requestChain.OutputFileSuccessfully);
        }

        [Fact]
        [Trait("Action", "Execute")]
        [TestPriority(9)]
        public void ShouldExecuteClientUseCase()
        {
            Guid newGuid = Guid.NewGuid();
            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithInvoiceID("INV-0013").WithNumeroNF("123").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-0014").WithNumeroNF("456").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
            };

            var clientFile = Builders.FileBuilder.New().WithId(newGuid).Build();

            var idFileReturnNF = model.Select(s => s.FileId).FirstOrDefault();

            requestChain = new ClientChainRequest(idFileReturnNF);

            requestChain.ClientFile = clientFile;

            requestChain.FileName = clientFile.FileName;
            requestChain.ClientText = "teste";


            var request = new ClientRequest(requestChain.IdFile);
            var ret = clientUC.Execute(request);
            Assert.True(ret == 1);
        }
    }
}
