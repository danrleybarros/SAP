using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomerServices;
using Gcsb.Connect.SAP.WebApi.Infraestructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.SAP.Tests.Cases.WebApi.Controllers.FeedData.CustomerServices
{
    [UseAutofacTestFramework]
    public class FeedControllerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly ICustomerServicesUseCase customerServicesUseCase;
        private readonly CustomerServicesPresenter presenter;
        private readonly IdentityParser identityParser;
        private readonly IServiceInvoiceWriteOnlyRepository serviceInvoiceWriteOnlyRepository;
        private static readonly string invoiceNumber = $"VVL-1-000{new Random().Next(0, 1000)}";

        public FeedControllerTest(Fixture.ApplicationFixture fixture)
        {
            customerServicesUseCase = fixture.Container.Resolve<ICustomerServicesUseCase>();
            presenter = fixture.Container.Resolve<CustomerServicesPresenter>();
            identityParser = fixture.Container.Resolve<IdentityParser>();
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
        public void ShouldExecuteController()
        {
            Mock();
            var invoiceNumbers = new List<string>() { invoiceNumber };
            var request = new SAP.WebApi.Config.UseCases.FeedData.CustomerServices.CustomerServicesRequest() { InvoiceNumbers = invoiceNumbers };
            var controller = new FeedController(customerServicesUseCase, presenter, identityParser);
            var output = controller.CustomerServices(request);
            output.Should().BeOfType<OkObjectResult>();
        }
    }
}
