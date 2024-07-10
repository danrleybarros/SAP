using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Fixture;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.IndividualReportNF
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class IndividualReportNFUseCaseTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IIndividualReportNFUseCase individualReportNF;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private static readonly Guid idFile = Guid.NewGuid();

        public IndividualReportNFUseCaseTest(ApplicationFixture fixture)
        {
            this.individualReportNF = fixture.Container.Resolve<IIndividualReportNFUseCase>();
            this.invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        private int IncludeInvoices(params string[] storeAcronym)
        {
            var invoices = new List<Invoice>();

            storeAcronym.ToList().ForEach(f => invoices.Add(InvoiceBuilder.New()
                .WithIdFile(idFile)
                .WithInvoiceNumber($"INV-{new Random().Next(1000, 99999)}")
                .WithCustomer(CustomerBuilder.New().WithIndividualInvoice("S").Build())
                .WithStoreAcronym(f)
                .Build()));

            return invoiceWriteOnlyRepository.Add(invoices);
        }

        [Fact]
        [Trait("Action", "None")]
        public void CustomerAddMany()
        {
            IncludeInvoices("cloudco", "telerese").Should().BeGreaterThan(0);
        }

        [Fact]
        [Trait("Action", "Execute")]
        public void ShouldExecuteUseCase()
        {
            IncludeInvoices("IOTCo");

            var request = new IndividualReportRequestNF(idFile);

            individualReportNF.Execute(request);

            request.Stores.Should().NotBeNullOrEmpty();
            request.Invoices.Should().NotBeNullOrEmpty();
            request.UfOutputs.Should().NotBeNullOrEmpty();
            request.Logradouros.Should().NotBeNullOrEmpty();
            request.IndividualFiles.Should().HaveCountGreaterThan(0);
            request.IndividualReports.Should().NotBeNullOrEmpty();
            request.Files.Should().NotBeNullOrEmpty();
        }

        [Fact]
        [Trait("Action", "Exception")]
        [TestPriority(3)]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => individualReportNF.Execute(null));
        }
    }
}
