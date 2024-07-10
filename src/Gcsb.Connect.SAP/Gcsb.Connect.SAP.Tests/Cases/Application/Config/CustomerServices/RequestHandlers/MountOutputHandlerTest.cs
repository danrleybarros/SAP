using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices.RequestHandlers;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.CustomerServices.RequestHandlers
{
    [UseAutofacTestFramework]
    public class MountOutputHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly MountOutputHandler mountOutputHandler;
        private readonly IServiceInvoiceWriteOnlyRepository serviceInvoiceWriteOnlyRepository;
        private static readonly string invoiceNumber = $"VVL-1-000{new Random().Next(0, 9999)}";
        private ServiceInvoice serviceInvoice;

        public MountOutputHandlerTest(Fixture.ApplicationFixture fixture)
        {
            mountOutputHandler = fixture.Container.Resolve<MountOutputHandler>();
            serviceInvoiceWriteOnlyRepository = fixture.Container.Resolve<IServiceInvoiceWriteOnlyRepository>();
        }

        private void Mock()
        {
            var customer = CustomerBuilder.New().WithInvoiceNumber(invoiceNumber).Build();
            var invoice = InvoiceBuilder.New().WithCustomer(customer).WithInvoiceNumber(invoiceNumber).Build();
            serviceInvoice = ServiceBuilder.New().WithInvoice(invoice).WithInvoiceNumber(invoiceNumber).Build();
            serviceInvoiceWriteOnlyRepository.Add(serviceInvoice);
        }

        [Fact]
        public void ShouldMountOutput()
        {
            Mock();

            var invoiceNumbers = new List<string> { invoiceNumber };
            var request = new CustomerServicesRequest(invoiceNumbers);

            request.ServicesInvoices.Add(serviceInvoice);
            mountOutputHandler.ProcessRequest(request);
            request.CustomerServices.Should().HaveCountGreaterThan(0);
        }
    }
}
