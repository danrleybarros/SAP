using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption.RequestHandlers;
using Gcsb.Connect.SAP.Domain.Config.Enum;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.WebApi.Tests.Fixture;
using Xunit;

namespace Gcsb.Connect.SAP.WebApi.Tests.Cases.Application.Config.CustomerConsumption.RequestHandlers
{
    public class GetCustomerHandlerTest : IClassFixture<ApplicationFixture>
    {
        private readonly GetCustomerHandler getCustomerHandler;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public GetCustomerHandlerTest(ApplicationFixture fixture)
        {
            this.getCustomerHandler = fixture.Container.Resolve<GetCustomerHandler>();
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
        }

        private void AddMock(string cnpj)
        {
            var customer = CustomerBuilder.New().WithCustomerCNPJ(cnpj).Build();

            customerWriteOnlyRepository.Add(customer);
        }

        [Theory]
        [InlineData("88500068000180")]
        [InlineData("20715699000183")]
        [InlineData("08407437000156")]
        public void ShouldGetCustomers(string cnpj)
        {
            AddMock(cnpj);

            var request = new CustomerConsumptionRequest(DocumentType.CNPJ, cnpj);

            getCustomerHandler.ProcessRequest(request);

            request.Customers.Should().NotBeNull();
            request.Customers.Should().HaveCount(1);
        }

        [Fact]
        public void ShouldNotFindCustomer()
        {
            var request = new CustomerConsumptionRequest(DocumentType.CNPJ, "73363594000179");

            getCustomerHandler.ProcessRequest(request);

            request.Customers.Should().NotBeNull();
            request.Customers.Should().HaveCount(0);
        }
    }
}
