using Autofac;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.UseCases.GF.Master;
using Gcsb.Connect.SAP.Application.UseCases.GF.Master.RequestHandlers;
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

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.Master.RequestHandlersTest
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class GetReturnNFHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IGetReturnNFHandler getReturnNFHandler;
        private readonly IGetInvoicesHandler getInvoiceHandler;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository;
        private static Guid fileId = Guid.NewGuid();

        public GetReturnNFHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.getReturnNFHandler = fixture.Container.Resolve<GetReturnNFHandler>();
            this.getInvoiceHandler = fixture.Container.Resolve<GetInvoicesHandler>();
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
            this.returnNFWriteOnlyRepository = fixture.Container.Resolve<IReturnNFWriteOnlyRepository>();
            this.fileWriteOnlyRepository = fixture.Container.Resolve<IFileWriteOnlyRepository>();
        }

        [Fact] 
        [Trait("Action", "None")]
        [TestPriority(0)]     
        public void CustomerAddMany()
        {
            Assert.True(customerWriteOnlyRepository.Add(Fixture.ApplicationFixture.Customers(fileId, "INV-005")) > 0);
        } 

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void ReturnNFAddMany()
        {
            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithFile(FileBuilder.New().WithId(fileId).Build()).WithInvoiceID("INV-0051").Build(),
                new ReturnNFBuilder().WithFile(FileBuilder.New().WithId(fileId).Build()).WithInvoiceID("INV-0054").Build()
            };

            Assert.True(returnNFWriteOnlyRepository.Add(model) > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(1)]
        public void GetInvoicesItems()
        {
            Guid idparent = Guid.NewGuid();

            var request = new MasterRequest(fileId);
            request.File = FileBuilder.New().WithIdParent(idparent).Build();
            getInvoiceHandler.ProcessRequest(request);
            getReturnNFHandler.ProcessRequest(request);

            Assert.NotNull(request.Invoices);
            Assert.True(request.Invoices.Count > 0);
        }
    }
}
