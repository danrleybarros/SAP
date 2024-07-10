using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices.RequestHandlers;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System.Collections.Generic;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.CustomerServices.RequestHandlers
{
    [UseAutofacTestFramework]
    public class GetCustomersHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly GetCustomersHandler getCustomersHandler;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private static readonly string invoiceNumber = "VVL-1-00011705";

        public GetCustomersHandlerTest(Fixture.ApplicationFixture fixture)
        {
            getCustomersHandler = fixture.Container.Resolve<GetCustomersHandler>();
            customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
        }


        private void Mock()
        {
            var invoice = InvoiceBuilder.New().WithInvoiceNumber(invoiceNumber).Build();
            var customer = CustomerBuilder.New().WithInvoice(invoice).WithInvoiceNumber(invoiceNumber).Build();
            customerWriteOnlyRepository.Add(customer);
        }

        [Fact]
        public void ShouldGetCustomers()
        {
            Mock();

            var invoiceNumbers = new List<string> { invoiceNumber };
            var request = new CustomerServicesRequest(invoiceNumbers);
            
            var serviceInvoice = ServiceBuilder.New().WithInvoiceNumber(invoiceNumber).Build();
            request.ServicesInvoices.Add(serviceInvoice);
            getCustomersHandler.ProcessRequest(request);
            request.ServicesInvoices[0].Invoice.Customer.Should().NotBeNull();
        }
    }
}
