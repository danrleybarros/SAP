using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption;
using Gcsb.Connect.SAP.Domain.Config.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.WebApi.Tests.Fixture;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.WebApi.Tests.Cases.Application.Config.CustomerConsumption
{
    public class CustomerConsumptionUseCaseTest : IClassFixture<ApplicationFixture>
    {
        private readonly ICustomerConsumptionUseCase customerConsumptionUseCase;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public CustomerConsumptionUseCaseTest(ApplicationFixture fixture)
        {
            customerConsumptionUseCase = fixture.Container.Resolve<ICustomerConsumptionUseCase>();
            invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        private void AddMock(string cnpj)
        {
            invoiceWriteOnlyRepository.DeleteAll();

            var invoices = new List<Invoice>();

            for (int i = 0; i < 3; i++)
            {
                invoices.Add(InvoiceBuilder.New()
                    .WithInvoiceNumber($"VVL-1-{i}")
                    .WithBillFrom(DateTime.UtcNow.AddMonths(-1))
                    .WithBillTo(DateTime.UtcNow.AddMonths(-1))
                    .WithServices(new List<ServiceInvoice> { ServiceBuilder.New().WithInvoiceNumber($"VVL-1-{i}").Build() })
                    .WithCustomer(CustomerBuilder.New().WithCustomerCNPJ(cnpj).Build())
                    .Build());
            }

            invoiceWriteOnlyRepository.Add(invoices);
        }

        //[Theory]
        //[InlineData("86982930000103")]
        //[InlineData("85362936000115")]
        //[InlineData("35160020000104")]
        //public void ShouldExecuteConsumptionUseCase(string cnpj)
        //{
        //    AddMock(cnpj);

        //    var request = new CustomerConsumptionRequest(DocumentType.CNPJ, cnpj);

        //    customerConsumptionUseCase.Execute(request);

        //    request.Customers.Should().NotBeNull();
        //    request.Customers.Should().HaveCountGreaterThan(0);
        //    request.Invoices.Should().NotBeNull();
        //    request.Invoices.Should().HaveCountGreaterThan(0);
        //    request.Services.Should().NotBeNull();
        //    request.Services.Should().HaveCountGreaterThan(0);
        //    request.Consumptions.Should().NotBeNull();
        //    request.Consumptions.Should().HaveCountGreaterThan(0);
        //}
    }
}
