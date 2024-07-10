using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.Items.RequestHandlersTest
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class GetNFsHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly GetInvoicesHandler getGetInvoicesHandler;
        private readonly GetNFsHandler getNFsHandler;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository;
        private static Guid idFile = Guid.NewGuid();

        public GetNFsHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.getGetInvoicesHandler = fixture.Container.Resolve<GetInvoicesHandler>();
            this.getNFsHandler = fixture.Container.Resolve<GetNFsHandler>();
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
            this.returnNFWriteOnlyRepository = fixture.Container.Resolve<IReturnNFWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void CustomerAddMany()
        { 
            Assert.True(customerWriteOnlyRepository.Add(Fixture.ApplicationFixture.Customers(idFile, "INV-089")) > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void NFAddMany()
        {
            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithFile(Builders.FileBuilder.New().WithId(idFile).Build()).WithInvoiceID("INV-0891").Build(),
                new ReturnNFBuilder().WithFile(Builders.FileBuilder.New().WithId(idFile).Build()).WithInvoiceID("INV-0894").Build()
            };

            Assert.True(returnNFWriteOnlyRepository.Add(model) > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(1)]
        public void ShouldGetListNFByInvoiceNumber()
        {
            var request = new ItemsRequest(idFile);
            getGetInvoicesHandler.ProcessRequest(request);
            getNFsHandler.ProcessRequest(request);

            Assert.True(request.ReturnNFs.Count > 0);
        }

        [Fact]
        [Trait("Action", "Exception")]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => getNFsHandler.ProcessRequest(null));
        }
    }
}