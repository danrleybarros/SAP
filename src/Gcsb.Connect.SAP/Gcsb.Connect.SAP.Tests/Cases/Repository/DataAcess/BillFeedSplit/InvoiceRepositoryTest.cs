using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.DataAcess.BillFeedSplit
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class InvoiceRepositoryTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public InvoiceRepositoryTest(Fixture.ApplicationFixture fixture)
        {
            this.invoiceReadOnlyRepository = fixture.Container.Resolve<IInvoiceReadOnlyRepository>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(0)]
        public void InvoiceAddOneTest()
        {
            var model = InvoiceBuilder.New().Build();
            var ret = invoiceWriteOnlyRepository.Add(model);

            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(1)]
        public void InvoiceAddManyTest()
        {
            var model = new List<Invoice>()
            {
                InvoiceBuilder.New().WithInvoiceNumber("1").Build(),
                InvoiceBuilder.New().WithInvoiceNumber("2").Build(),
                InvoiceBuilder.New().WithInvoiceNumber("3").Build(),
                InvoiceBuilder.New().WithInvoiceNumber("4").Build(),
                InvoiceBuilder.New().WithInvoiceNumber("5").Build()
            };

            //InvoiceBuilder.New().Build();
            var ret = invoiceWriteOnlyRepository.Add(model);

            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "Create")]
        [TestPriority(2)]
        public void ReadAllInvoices()
        {
            Assert.True(invoiceReadOnlyRepository.GetAllInvoices().Count > 0);
        }

        [Theory]
        [InlineData("1")]
        [TestPriority(3)]
        public void ReadOneInvoices(string invoiceNumber)
        {
            Assert.NotNull(invoiceReadOnlyRepository.GetInvoice(invoiceNumber));
        }
    }
}
