using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption.RequestHandlers;
using Gcsb.Connect.SAP.Domain.Config.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.WebApi.Tests.Fixture;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.WebApi.Tests.Cases.Application.Config.CustomerConsumption.RequestHandlers
{
    public class MountConsumptionDataHandlerTest : IClassFixture<ApplicationFixture>
    {
        private readonly MountConsumptionDataHandler mountConsumptionDataHandler;

        public MountConsumptionDataHandlerTest(ApplicationFixture fixture)
        {
            mountConsumptionDataHandler = fixture.Container.Resolve<MountConsumptionDataHandler>();
        }

        [Theory]
        [InlineData("86982930000103")]
        [InlineData("85362936000115")]
        [InlineData("35160020000104")]
        public void ShouldMountResponseData(string cnpj)
        {
            var customer = CustomerBuilder.New().WithCustomerCNPJ(cnpj).WithCustomerCode("400063").Build();

            var request = new CustomerConsumptionRequest(DocumentType.CNPJ, cnpj)
            {
                Customers = new List<Customer> { customer },
                Invoices = new List<Invoice> { InvoiceBuilder.New().WithInvoiceNumber("VVL-0-1").WithCustomer(customer).Build() },
                Services = new List<ServiceInvoice> { ServiceBuilder.New().WithInvoiceNumber("VVL-0-1").Build() }
            };

            mountConsumptionDataHandler.ProcessRequest(request);

            request.Consumptions.Should().NotBeNull();
            request.Consumptions.Should().HaveCountGreaterThan(0);
        }
    }
}
