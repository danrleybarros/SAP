using Autofac;
using FluentAssertions;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.CounterChargeDispute;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.CounterchargeDispute.RequestHandlers
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
            var invoice = InvoiceBuilder.New().WithInvoiceNumber("VVL-1-00032389").WithCycleCode(new DateTime(2021, 11, 01)).Build();
            invoiceWriteOnlyRepository.Add(invoice);

            var request = new CounterchargeDisputeRequest(new DateTime(2021, 11, 01), new DateTime(2021, 11, 30));
            var counterChargeDisputeAdjustment = CounterchargeDisputeBuilder.New().WithTipoTransacao("Adjustment").WithNumeroFatura("VVL-1-00032389").WithReferenciaCicloFaturamento(DateTime.MinValue).WithCicloNulo(true).Build();
            var counterChargeDisputeBilling = CounterchargeDisputeBuilder.New().WithTipoTransacao("Billing").WithNumeroFatura("VVL-1-00032389").WithReferenciaCicloFaturamento(DateTime.MinValue).WithCicloNulo(true).Build();
            request.CounterchargeDisputesAdjustment.Add(counterChargeDisputeAdjustment);
            request.CounterchargeDisputesBilling.Add(counterChargeDisputeBilling);

            getInvoiceCycleHandler.ProcessRequest(request);

            request.CounterchargeDisputesAdjustment[0].Ciclo.Should().Be("11");
            request.CounterchargeDisputesAdjustment[0].ReferenciaCicloFaturamento.Should().BeSameDateAs(new DateTime(2021, 11, 01));

            request.CounterchargeDisputesBilling[0].Ciclo.Should().Be("11");
            request.CounterchargeDisputesBilling[0].ReferenciaCicloFaturamento.Should().BeSameDateAs(new DateTime(2021, 11, 01));
        }
    }
}
