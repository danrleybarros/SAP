using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices;
using Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices.RequestHandlers;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.PAY
{
    [TestCaseOrderer("Gcsb.Connect.SAP.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.SAP.Tests")]
    public class InvoicePaymentFilterHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly PayFilterHandler handler;

        public InvoicePaymentFilterHandlerTest(Fixture.ApplicationFixture applicationFixture)
        {
            handler = applicationFixture.Container.Resolve<PayFilterHandler>();
        }

        [Fact]
        public void ShouldProcessRequest()
        {
            var request = new GetOpenInvoicesRequest(SAP.Application.Boundaries.GetOpenInvoices.SearchType.CNPJ, "123")
            {
                OpenInvoicesOutput = new System.Collections.Generic.List<SAP.Application.Boundaries.GetOpenInvoices.InvoiceOutput>
                {
                    new SAP.Application.Boundaries.GetOpenInvoices.InvoiceOutput("","","","TST-1-00000001", DateTime.UtcNow, DateTime.UtcNow, 200, 0)
                }
            };

            handler.ProcessRequest(request);
            request.OpenInvoicesOutput.Should().BeEmpty();
        }
    }
}
