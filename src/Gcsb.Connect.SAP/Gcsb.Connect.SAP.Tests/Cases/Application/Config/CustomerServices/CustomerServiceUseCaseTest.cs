using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.CustomerServices
{
    [UseAutofacTestFramework]
    public class CustomerServiceUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly ICustomerServicesUseCase customerServicesUseCase;
        private readonly IServiceInvoiceWriteOnlyRepository serviceInvoiceWriteOnlyRepository;
        private static readonly string invoiceNumber = "VVL-1-00011709";

        public CustomerServiceUseCaseTest(Fixture.ApplicationFixture fixture)
        {
            customerServicesUseCase = fixture.Container.Resolve<ICustomerServicesUseCase>();
            serviceInvoiceWriteOnlyRepository = fixture.Container.Resolve<IServiceInvoiceWriteOnlyRepository>();
        }

        private void Mock()
        {
            var customer = CustomerBuilder.New().WithInvoiceNumber(invoiceNumber).Build();
            var invoice = InvoiceBuilder.New().WithCustomer(customer).WithInvoiceNumber(invoiceNumber).Build();
            var serviceInvoice = ServiceBuilder.New().WithInvoice(invoice).WithInvoiceNumber(invoiceNumber).Build();
            serviceInvoiceWriteOnlyRepository.Add(serviceInvoice);
        }

        [Fact]
        public void ShouldExecuteUseCase()
        {
            Mock();
            var invoiceNumbers = new List<string> { invoiceNumber };
            var request = new CustomerServicesRequest(invoiceNumbers);
            customerServicesUseCase.Execute(request);
            request.Logs.Select(l => l.TypeLog).Should().NotContain(Messaging.Messages.Log.Enum.TypeLog.Error);
        }
    }
}
