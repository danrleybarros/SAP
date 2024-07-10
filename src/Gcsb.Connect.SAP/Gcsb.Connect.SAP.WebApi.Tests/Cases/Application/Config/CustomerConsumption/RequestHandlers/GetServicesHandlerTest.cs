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
    public class GetServicesHandlerTest : IClassFixture<ApplicationFixture>
    {
        private readonly GetServicesHandler getServicesHandler;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public GetServicesHandlerTest(ApplicationFixture fixture)
        {
            getServicesHandler = fixture.Container.Resolve<GetServicesHandler>();
            invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        private CustomerConsumptionRequest AddMock(string cnpj)
        {
            invoiceWriteOnlyRepository.DeleteAll();

            var invoices = new List<Invoice>();

            var request = new CustomerConsumptionRequest(DocumentType.CNPJ, cnpj)
            {
                Customers = new List<Customer>
                {
                    CustomerBuilder.New().WithCustomerCNPJ(cnpj).Build(),
                    CustomerBuilder.New().WithCustomerCNPJ(cnpj).Build(),
                    CustomerBuilder.New().WithCustomerCNPJ(cnpj).Build(),
                }
            };

            for (int i = 0; i < request.Customers.Count; i++)
            {                
                invoices.Add(InvoiceBuilder.New()
                    .WithInvoiceNumber($"VVL-1-{i}")
                    .WithBillFrom(DateTime.UtcNow.AddMonths(-1))
                    .WithBillTo(DateTime.UtcNow.AddMonths(-1))
                    .WithServices(new List<ServiceInvoice> { ServiceBuilder.New().WithInvoiceNumber($"VVL-1-{i}").Build() })
                    .Build());

                request.Customers[i].SetInvoiceNumber($"VVL-1-{i}");
            }

            invoiceWriteOnlyRepository.Add(invoices);

            return request;
        }

        [Theory]
        [InlineData("04190705000170")]
        [InlineData("49385273000190")]
        [InlineData("70493333000185")]
        public void ShouldGetServices(string cnpj)
        {
            var request = AddMock(cnpj);

            getServicesHandler.ProcessRequest(request);

            request.Services.Should().NotBeNull();
            request.Services.Should().HaveCountGreaterThan(1);
        }
    }
}
