using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption.RequestHandlers;
using Gcsb.Connect.SAP.Domain.Config.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.WebApi.Tests.Fixture;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.WebApi.Tests.Cases.Application.Config.CustomerConsumption.RequestHandlers
{
    public class GetInvoicesHandlerTest : IClassFixture<ApplicationFixture>
    {
        private readonly GetInvoicesHandler getInvoicesHandler;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public GetInvoicesHandlerTest(ApplicationFixture fixture)
        {
            getInvoicesHandler = fixture.Container.Resolve<GetInvoicesHandler>();
            invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        private CustomerConsumptionRequest AddMock(string cnpj)
        {
            invoiceWriteOnlyRepository.DeleteAll();

            var invoices = new List<Invoice>();

            for (int i = 0; i < 3; i++)
                invoices.Add(InvoiceBuilder.New()
                    .WithInvoiceNumber($"VVL-0-{i}")
                    .WithBillFrom(DateTime.UtcNow.AddMonths(-1))
                    .WithBillTo(DateTime.UtcNow.AddMonths(-1))
                    .Build());

            var request = new CustomerConsumptionRequest(DocumentType.CNPJ, cnpj)
            {
                Customers = new List<Customer>
                {
                    CustomerBuilder.New().WithCustomerCNPJ(cnpj).WithInvoice(invoices[0]).Build(),
                    CustomerBuilder.New().WithCustomerCNPJ(cnpj).WithInvoice(invoices[1]).Build(),
                    CustomerBuilder.New().WithCustomerCNPJ(cnpj).WithInvoice(invoices[2]).Build(),
                }
            };

            request.Customers.ForEach(f => f.SetInvoiceNumber(f.Invoice.InvoiceNumber));

            invoiceWriteOnlyRepository.Add(invoices);

            return request;
        }

        [Theory]
        [InlineData("57616119000100")]
        [InlineData("32883026000111")]
        [InlineData("78214664000140")]
        public void ShouldGetInvoices(string cnpj)
        {
            var request = AddMock(cnpj);

            getInvoicesHandler.ProcessRequest(request);

            request.Invoices.Should().NotBeNull();
            request.Invoices.Should().HaveCountGreaterThan(1);
        }
    }
}
