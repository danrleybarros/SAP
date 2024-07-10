using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Repository.DataAcess.BillFeedSplit
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class CustomerRepositoryTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private ICustomerReadOnlyRepository customerReadOnlyRepository;

        public CustomerRepositoryTest(Fixture.ApplicationFixture fixture)
        {
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
            this.customerReadOnlyRepository = fixture.Container.Resolve<ICustomerReadOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void CustomerAdd()
        {
            var model = CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0101").Build())
                    .WithIndividualInvoice("S").Build();

            var ret = customerWriteOnlyRepository.Add(model);

            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void CustomerAddMany()
        {
            var model = new List<Customer>()
            {
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0102").Build())
                    .WithIndividualInvoice("S").Build(),
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0103").Build())
                    .WithIndividualInvoice("N").Build(),
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New().WithInvoiceNumber("INV-0104").Build())
                    .WithIndividualInvoice("N").Build(),
            };

            var ret = customerWriteOnlyRepository.Add(model);
            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(1)]
        public void CustomerRemove()
        {
            var ret = customerWriteOnlyRepository.Delete(customerReadOnlyRepository.GetCustomer("INV-0101"));

            Assert.True(ret > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(2)]
        public void CustomerGetOne()
        {
            var ret = customerReadOnlyRepository.GetCustomer("INV-0102");

            Assert.NotNull(ret);
            Assert.Equal("INV-0102", ret.InvoiceNumber);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(2)]
        public void CustomerGetMany()
        {
            var ret = customerReadOnlyRepository.GetCustomers(new List<string> { "INV-0102", "INV-0103" });

            Assert.NotNull(ret);
            Assert.Equal("INV-0102", ret[0].Invoice.InvoiceNumber);
            Assert.Equal("INV-0103", ret[1].Invoice.InvoiceNumber);
        }

        [Theory]
        [TestPriority(2)]
        [InlineData("S")]
        [InlineData("N")]
        public void GetCustomerByStatus(string status)
        {
            var ret = customerReadOnlyRepository.GetCustomers(status);

            Assert.NotNull(ret);
            Assert.True(ret.Count > 0);
        }
    }
}
