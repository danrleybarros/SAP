using Autofac;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Application.UseCases.GF.Master;
using Gcsb.Connect.SAP.Application.UseCases.GF.Master.RequestHandlers;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Gcsb.Connect.SAP.Tests.Builders;
using Gcsb.Connect.SAP.Tests.Builders.GF;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.Master.RequestHandlersTest
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class MountItemsHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IMountMasterHandler mountMasterHandler;
        private readonly IGetReturnNFHandler getReturnNFHandler;
        private readonly IGetInvoicesHandler getInvoiceHandler;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IReturnNFWriteOnlyRepository returnNFWriteOnlyRepository;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        private Guid idparent = Guid.NewGuid();
        private static MasterRequest request;

        public MountItemsHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.mountMasterHandler = fixture.Container.Resolve<MountMasterHandler>();
            this.getReturnNFHandler = fixture.Container.Resolve<GetReturnNFHandler>();
            this.getInvoiceHandler = fixture.Container.Resolve<GetInvoicesHandler>();
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
            this.returnNFWriteOnlyRepository = fixture.Container.Resolve<IReturnNFWriteOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
            this.fileWriteOnlyRepository = fixture.Container.Resolve<IFileWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void CustomerAddMany()
        {
            File file = FileBuilder.New().WithType(TypeRegister.BILL).WithStatus(Status.Success).Build();
            fileWriteOnlyRepository.Add(file); 

            Assert.True(customerWriteOnlyRepository.Add(Fixture.ApplicationFixture.Customers(new Guid(), "INV-088")) > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(1)]
        public void NFAddMany()
        {
            var model = new List<ReturnNF>()
            {
                new ReturnNFBuilder().WithInvoiceID("INV-0501").WithNumeroNF("123").WithFile(Builders.FileBuilder.New().WithId(idparent).Build()).Build(),
                new ReturnNFBuilder().WithInvoiceID("INV-0502").WithNumeroNF("456").WithFile(Builders.FileBuilder.New().WithId(idparent).Build()).Build(),
            };
            var idFileReturnNF = model.Select(s => s.FileId).FirstOrDefault();
            request = new MasterRequest(idFileReturnNF);
            Assert.True(returnNFWriteOnlyRepository.Add(model) > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(2)]
        public void MountListMasters()
        {
            getInvoiceHandler.ProcessRequest(request);
            getReturnNFHandler.ProcessRequest(request);
            mountMasterHandler.ProcessRequest(request);

            Assert.NotNull(request.Masters);
            Assert.True(request.Masters.Count > 0);
        }
    }
}
