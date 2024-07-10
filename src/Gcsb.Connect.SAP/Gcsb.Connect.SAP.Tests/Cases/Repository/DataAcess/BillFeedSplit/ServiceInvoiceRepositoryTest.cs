using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.DataAcess.BillFeedSplit
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class ServiceInvoiceRepositoryTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository;
        private readonly IServiceInvoiceWriteOnlyRepository serviceWriteOnlyRepository;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private static Guid idFileBillFeed;

        public ServiceInvoiceRepositoryTest(Fixture.ApplicationFixture fixture)
        {
            this.serviceReadOnlyRepository = fixture.Container.Resolve<IServiceInvoiceReadOnlyRepository>();
            this.serviceWriteOnlyRepository = fixture.Container.Resolve<IServiceInvoiceWriteOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(0)]
        public void InvoiceAddOneTest()
        {
            var model = ServiceBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("106").Build()).Build();
            var ret = serviceWriteOnlyRepository.Add(model);
            idFileBillFeed = model.Invoice.IdFile;
            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(1)]
        public void InvoiceAddManyTest()
        {
            var ret = serviceWriteOnlyRepository.Add(
                new List<ServiceInvoice>
            {
                ServiceBuilder.New().WithServiceCode("azuremonth").WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("103").Build()).Build(),
                ServiceBuilder.New().WithServiceCode("windowsyear").WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("104").Build()).Build()
            });

            Assert.True(ret > 0);
        }

        [Theory]
        [InlineData("106")]
        [TestPriority(2)]
        public void ReadOneInvoices(string invoiceNumber)
        {
            Assert.True(serviceReadOnlyRepository.GetServices(invoiceNumber).Count > 0);
        }

        [Theory]
        [InlineData("103")]
        [TestPriority(3)]
        public void ReadManyInvoices(string invoiceNumber)
        {
            var lista = new List<string>()
            {
                invoiceNumber
            };

            Assert.True(serviceReadOnlyRepository.GetServices(lista).Count > 0);
        }

        [Fact]
        [TestPriority(4)]
        [Trait("Action", "None")]
        public void AddSomeInvoicesToTestNextMethods()
        {
            var ret = invoiceWriteOnlyRepository.Add(Fixture.ApplicationFixture.Invoices("INV-073"));
            Assert.True(ret > 0);
        }

        [Fact]
        [TestPriority(5)]
        [Trait("Action", "None")]
        public void ReadSomeServices()
        {
            var ret = serviceReadOnlyRepository.GetServices(idFileBillFeed, "N").Count > 0 || serviceReadOnlyRepository.GetServices(idFileBillFeed, "S").Count > 0;
            Assert.True(ret);
        }
    }
}
