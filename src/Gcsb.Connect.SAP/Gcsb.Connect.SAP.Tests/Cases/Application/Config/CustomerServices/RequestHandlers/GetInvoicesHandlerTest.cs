using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices.RequestHandlers;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.CustomerServices.RequestHandlers
{
    public class GetInvoicesHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly GetInvoicesHandler getInvoicesHandler;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private static readonly string invoiceNumber = "VVL-1-00011706";

        public GetInvoicesHandlerTest(Fixture.ApplicationFixture fixture)
        {
            getInvoicesHandler = fixture.Container.Resolve<GetInvoicesHandler>();
            invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        private void Mock()
        {
            var customer = CustomerBuilder.New().Build();
            var invoice = InvoiceBuilder.New().WithInvoiceNumber(invoiceNumber).WithCustomer(customer).Build();
            invoiceWriteOnlyRepository.Add(invoice);
        }

        [Fact]
        public void ShouldGetInvoices()
        {
            Mock();

            var invoiceNumbers = new List<string> { invoiceNumber };
            var request = new CustomerServicesRequest(invoiceNumbers);
            var serviceInvoice = ServiceBuilder.New().WithInvoiceNumber(invoiceNumber).Build();
            request.ServicesInvoices.Add(serviceInvoice);
            getInvoicesHandler.ProcessRequest(request);
            request.ServicesInvoices[0].Invoice.Should().NotBeNull();
        }
    }
}
