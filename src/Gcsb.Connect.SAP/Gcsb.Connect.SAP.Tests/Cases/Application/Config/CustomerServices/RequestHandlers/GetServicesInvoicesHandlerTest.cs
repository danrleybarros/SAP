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
    public class GetServicesInvoicesHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly GetServicesInvoicesHandler getServicesInvoicesHandler;
        private readonly IServiceInvoiceWriteOnlyRepository serviceInvoiceWriteOnlyRepository;
        private static readonly string invoiceNumber = "VVL-1-00011707";

        public GetServicesInvoicesHandlerTest(Fixture.ApplicationFixture fixture)
        {
            getServicesInvoicesHandler = fixture.Container.Resolve<GetServicesInvoicesHandler>();
            serviceInvoiceWriteOnlyRepository = fixture.Container.Resolve<IServiceInvoiceWriteOnlyRepository>();
        }

        private void Mock()
        {
            var customer = CustomerBuilder.New().Build();
            var invoice = InvoiceBuilder.New().WithInvoiceNumber(invoiceNumber).WithCustomer(customer).Build();
            var serviceInvoice = ServiceBuilder.New().WithInvoice(invoice).WithInvoiceNumber(invoiceNumber).Build();
            serviceInvoiceWriteOnlyRepository.Add(serviceInvoice);
        }

        [Fact]
        public void ShouldGetServices()
        {
            Mock();

            var invoiceNumbers = new List<string> { invoiceNumber };
            var request = new CustomerServicesRequest(invoiceNumbers);
            getServicesInvoicesHandler.ProcessRequest(request);
            request.ServicesInvoices.Should().NotBeEmpty();
        }
    }
}
