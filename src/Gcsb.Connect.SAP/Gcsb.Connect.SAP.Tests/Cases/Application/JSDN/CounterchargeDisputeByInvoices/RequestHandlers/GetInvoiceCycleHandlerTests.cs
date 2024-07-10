using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDisputeByInvoices;
using Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDisputeByInvoices.RequestHandlers;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.CounterChargeDispute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.JSDN.CounterchargeDisputeByInvoices.RequestHandlers
{
    public class GetInvoiceCycleHandlerTests : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly GetInvoiceCycleHandler getInvoiceCycleHandler;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;

        public GetInvoiceCycleHandlerTests(Fixture.ApplicationFixture fixture)
        {
            getInvoiceCycleHandler = fixture.Container.Resolve<GetInvoiceCycleHandler>();
            invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
        }

        [Fact]
        public void ShouldGetCycle()
        {
            var invoice = InvoiceBuilder.New().WithInvoiceNumber("VVL-1-00032780").WithCycleCode(new DateTime(2021, 11, 01)).Build();
            invoiceWriteOnlyRepository.Add(invoice);

            var request = new CounterchargeDisputeByInvoicesRequest(new List<string> { "VVL-1-00032780" });
            var counterChargeDisputeAdjustment = CounterchargeDisputeBuilder.New().WithTipoTransacao("Adjustment").WithNumeroFatura("VVL-1-00032780").WithReferenciaCicloFaturamento(DateTime.MinValue).WithCicloNulo(true).Build();
            var counterChargeDisputeBilling = CounterchargeDisputeBuilder.New().WithTipoTransacao("Billing").WithNumeroFatura("VVL-1-00032780").WithReferenciaCicloFaturamento(DateTime.MinValue).WithCicloNulo(true).Build();
            request.CounterchargeDisputes.Add(new CounterchargeDisputeInvoice(counterChargeDisputeAdjustment));
            request.CounterchargeDisputes.Add(new CounterchargeDisputeInvoice(counterChargeDisputeBilling));

            getInvoiceCycleHandler.ProcessRequest(request);

            var adjustment = request.CounterchargeDisputes.FirstOrDefault(d => d.TipoTransacao.Equals("Adjustment"));
            adjustment.Ciclo.Should().Be("11");
            adjustment.ReferenciaCicloFaturamento.Should().BeSameDateAs(new DateTime(2021, 11, 01));

            var billing = request.CounterchargeDisputes.FirstOrDefault(d => d.TipoTransacao.Equals("Billing"));
            billing.Ciclo.Should().Be("11");
            billing.ReferenciaCicloFaturamento.Should().BeSameDateAs(new DateTime(2021, 11, 01));
        }
    }
}
