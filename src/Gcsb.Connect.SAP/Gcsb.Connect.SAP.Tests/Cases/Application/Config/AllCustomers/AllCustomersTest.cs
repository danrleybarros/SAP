using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers;
using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.AllCustomers
{
    public class AllCustomersTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IAllCustomersUseCase allCustomersUseCase;
        private static readonly Guid idFile = Guid.NewGuid();

        public AllCustomersTest(Fixture.ApplicationFixture fixture)
        {
            this.customerWriteOnlyRepository = fixture.Container.Resolve<ICustomerWriteOnlyRepository>();
            this.allCustomersUseCase = fixture.Container.Resolve<IAllCustomersUseCase>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void ShouldSaveCustomer()
        {
            var invoicePrefix = "INV-070";
            var services = Fixture.ApplicationFixture.ServiceInvoices;

            var customers = new List<Customer>
            {
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New()
                    .WithIdFile(idFile)
                    .WithInvoiceNumber($"{invoicePrefix}1")
                    .WithServices(services.Select(i => i.Build()).ToList()).Build())
                    .WithIndividualInvoice("S")
                    .WithCustomerCode("453423")
                    .WithCustomerCNPJ("47100110000199")
                    .WithFirstName("Alan")
                    .WithLastName("Barros")
                    .Build(),
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New()
                    .WithIdFile(idFile)
                    .WithInvoiceNumber($"{invoicePrefix}2")
                    .WithServices(services.Select(i => i.Build()).ToList()).Build())
                    .WithIndividualInvoice("S")
                    .WithCustomerCode("453424")
                    .WithCustomerCNPJ("48260072000102")
                    .WithFirstName("João")
                    .WithLastName("Barros")
                    .Build(),
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New()
                    .WithIdFile(idFile)
                    .WithInvoiceNumber($"{invoicePrefix}3")
                    .WithServices(services.Select(i => i.Build()).ToList()).Build())
                    .WithIndividualInvoice("N")
                    .WithCustomerCode("453425")
                    .WithCustomerCNPJ("76469791000165")
                    .WithFirstName("Bryan")
                    .WithLastName("Barros")
                    .Build(),
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New()
                    .WithIdFile(idFile)
                    .WithInvoiceNumber($"{invoicePrefix}4")
                    .WithServices(services.Select(i => i.Build()).ToList()).Build())
                    .WithIndividualInvoice("N")
                    .WithCustomerCode("453426")
                    .WithCustomerCNPJ("99229358000158")
                    .WithFirstName("Daniel")
                    .WithLastName("Barros")
                    .WithCompanyName("Daniel Barros Ltda")
                    .Build(),
                CustomerBuilder.New().WithInvoice(InvoiceBuilder.New()
                    .WithIdFile(idFile)
                    .WithInvoiceNumber($"{invoicePrefix}5")
                    .WithServices(services.Select(i => i.Build()).ToList()).Build())
                    .WithIndividualInvoice("N")
                    .WithCustomerCode("7000453427")
                    .WithCustomerCNPJ("99229358000159")
                    .WithFirstName("Daniel")
                    .WithLastName("Barross")
                    .WithCompanyName("Daniel Barros Ltda")
                    .Build()
            };

            Assert.True(customerWriteOnlyRepository.Add(customers) > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(TypeSearch.Cnpj, "48260072000102")]
        [InlineData(TypeSearch.CustomerCode, "453")]
        [InlineData(TypeSearch.CustomerCode, "7000453426")]
        [InlineData(TypeSearch.CustomerName, "Daniel Barros")]
        [TestPriority(1)]
        public void ShouldExecuteAllCustomersUseCase(TypeSearch typeSearch, string value)
        {
            var request = new AllCustomersRequest(typeSearch, value);
            allCustomersUseCase.Execute(request);

            Assert.True(request.AllCustomersOutputs.Count() >= 1);
        }
    }
}
