﻿using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport.RequestHandlers;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.GF.IndividualReportNF.RequestHandlersTest
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class MountIndividualReportHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly GetStoresHandler getStoresHandler;
        private readonly MountIndividualReportHandler mountIndividualReport;
        private readonly GetInvoicesHandler getGetInvoicesHandler;
        private readonly GetLocalizationHandler getUfHandlers;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private static readonly Guid idFile = Guid.NewGuid();

        public MountIndividualReportHandlerTest(Fixture.ApplicationFixture fixture)
        {
            this.getStoresHandler = fixture.Container.Resolve<GetStoresHandler>();
            this.mountIndividualReport = fixture.Container.Resolve<MountIndividualReportHandler>();
            this.getGetInvoicesHandler = fixture.Container.Resolve<GetInvoicesHandler>();
            this.getUfHandlers = fixture.Container.Resolve<GetLocalizationHandler>();
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
        [Trait("Action", "Create")]
        public void ShouldMountIndividualReportNF()
        {
            IncludeInvoices("IOTCo");

            var request = new IndividualReportRequestNF(idFile);

            getStoresHandler.ProcessRequest(request);
            getGetInvoicesHandler.ProcessRequest(request);
            getUfHandlers.ProcessRequest(request);
            mountIndividualReport.ProcessRequest(request);

            Assert.True(request.IndividualReports.Count > 0);
        }

        [Fact]
        [Trait("Action", "Exception")]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<NullReferenceException>(() => mountIndividualReport.ProcessRequest(null));
        }
    }
}
