using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.Items
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class ItemsUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IItemsUseCase itemsUseCase;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository;
        private static Guid idFile = Guid.NewGuid();

        public ItemsUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            this.itemsUseCase = fixture.Container.Resolve<IItemsUseCase>();
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
            this.returnNFWriteOnlyRepository = fixture.Container.Resolve<IReturnNFWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void InvoiceAddMany()
        {
            var customer1 = CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0601").WithIdFile(idFile)
                .WithServices(Fixture.ApplicationFixture.ServiceInvoices.Select(i => i.Build()).ToList()).Build())
                    .WithIndividualInvoice("S").WithCustomerCode("abc").Build();
            var customer2 = CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0602").WithIdFile(idFile)
               .WithServices(Fixture.ApplicationFixture.ServiceInvoices.Select(i => i.Build()).ToList()).Build())
                   .WithIndividualInvoice("S").WithCustomerCode("abc").Build();

            var model = new List<Invoice>()
            {
                InvoiceBuilder.New().WithInvoiceNumber("INV-0601").WithStoreCode("abc").WithIdFile(idFile).WithCustomer(customer1)
                .WithServices(Fixture.ApplicationFixture.ServiceInvoices.Select(i=> i.Build()).ToList()).Build(),
                InvoiceBuilder.New().WithInvoiceNumber("INV-0602").WithStoreCode("abc").WithIdFile(idFile).WithCustomer(customer2)
                .WithServices(Fixture.ApplicationFixture.ServiceInvoices.Select(i=> i.Build()).ToList()).Build(),
            };

            Assert.True(invoiceWriteOnlyRepository.Add(model) > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void NFAddMany()
        {
            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithFile(Builders.FileBuilder.New().WithId(idFile).Build()).WithInvoiceID(("INV-0601")).Build(),
                new ReturnNFBuilder().WithFile(Builders.FileBuilder.New().WithId(idFile).Build()).WithInvoiceID(("INV-0602")).Build()
            };

            Assert.True(returnNFWriteOnlyRepository.Add(model) > 0);
        }

        [Fact]
        [Trait("Action", "Execute")]
        [TestPriority(1)]
        public void ShouldExecuteUseCase()
        {
            Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");

            var request = new ItemsRequest(idFile);

            itemsUseCase.Execute(request);

            Assert.True(request.Invoices.Count > 0);
            Assert.True(request.Items.Count > 0);
            Assert.True(request.Logs.Count > 0);
        }

        [Fact]
        [Trait("Action", "Exception")]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => itemsUseCase.Execute(null));
        }
    }
}
