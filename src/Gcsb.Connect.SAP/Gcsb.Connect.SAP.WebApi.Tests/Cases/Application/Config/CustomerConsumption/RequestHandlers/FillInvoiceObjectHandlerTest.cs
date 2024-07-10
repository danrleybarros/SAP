using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption.RequestHandlers;
using Gcsb.Connect.SAP.Domain.Config.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.WebApi.Tests.Fixture;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.WebApi.Tests.Cases.Application.Config.CustomerConsumption.RequestHandlers
{
    public class FillInvoiceObjectHandlerTest : IClassFixture<ApplicationFixture>
    {
        private readonly FillInvoiceObjectHandler fillInvoiceObjectHandler;

        public FillInvoiceObjectHandlerTest(ApplicationFixture fixture)
        {
            fillInvoiceObjectHandler = fixture.Container.Resolve<FillInvoiceObjectHandler>();
        }

        [Theory]
        [InlineData("86982930000103")]
        [InlineData("85362936000115")]
        [InlineData("35160020000104")]
        public void ShouldFillInvoiceObject(string cnpj)
        {
            var request = new CustomerConsumptionRequest(DocumentType.CNPJ, cnpj)
            {
                Customers = new List<Customer> { CustomerBuilder.New().WithCustomerCNPJ(cnpj).Build() },
                Invoices = new List<Invoice> { InvoiceBuilder.New().WithInvoiceNumber("VVL-0-1").Build() },
                Services = new List<ServiceInvoice> { ServiceBuilder.New().WithInvoiceNumber("VVL-0-1").Build() }
            };

            fillInvoiceObjectHandler.ProcessRequest(request);

            request.Invoices.ForEach(f =>
            {
                f.Customer.Should().NotBeNull();
                f.Services.Should().HaveCountGreaterThan(0);
            });
        }
    }
}
