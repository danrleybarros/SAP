using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.Items.RequestHandlersTest
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class MountItemsHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly MountItemsHandler mountItemsHandler;
        private readonly GetInvoicesHandler getGetInvoicesHandler;
        private readonly GetIbgeCodHandlers getIbgeCodHandlers;
        private readonly GetNFsHandler getNFsHandler;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository;
        private static ItemsRequest request;

        public MountItemsHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.mountItemsHandler = fixture.Container.Resolve<MountItemsHandler>();
            this.getGetInvoicesHandler = fixture.Container.Resolve<GetInvoicesHandler>();
            this.getIbgeCodHandlers = fixture.Container.Resolve<GetIbgeCodHandlers>();
            this.getNFsHandler = fixture.Container.Resolve<GetNFsHandler>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
            this.returnNFWriteOnlyRepository = fixture.Container.Resolve<IReturnNFWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void CustomerAddMany()
        { 
            Assert.True(customerWriteOnlyRepository.Add(Fixture.ApplicationFixture.Customers(new Guid(), "INV-0600")) > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void NFAddMany()
        {
            Guid newGuid = Guid.NewGuid();
            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithInvoiceID("INV-06001").WithNumeroNF("123").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-06002").WithNumeroNF("456").WithFile(Builders.FileBuilder.New().WithId(newGuid).Build()).Build(),
            };
            var idFileReturnNF = model.Select(s => s.FileId).FirstOrDefault();
            request = new ItemsRequest(idFileReturnNF);
            Assert.True(returnNFWriteOnlyRepository.Add(model) > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(1)]
        public void MountListItems()
        {
            getGetInvoicesHandler.ProcessRequest(request);
            getNFsHandler.ProcessRequest(request);
            getIbgeCodHandlers.ProcessRequest(request);
            mountItemsHandler.ProcessRequest(request);

            Assert.NotNull(request.Items);
            Assert.True(request.Items.Count > 0);
        }

        [Fact]
        [Trait("Action", "Exception")]
        [TestPriority(2)]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => mountItemsHandler.ProcessRequest(null));
        }
    }
}
