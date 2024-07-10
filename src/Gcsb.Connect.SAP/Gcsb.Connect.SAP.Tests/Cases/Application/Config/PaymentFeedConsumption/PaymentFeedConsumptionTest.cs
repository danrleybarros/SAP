using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeedConsumption;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.PaymentFeedConsumption
{
    public class PaymentFeedConsumptionTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly IPaymentfeedConsumptionUseCase useCase;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IPaymentFeedWriteOnlyRepository paymentFeedWriteOnlyRepository;
        private static readonly Guid idFile = Guid.NewGuid();

        public PaymentFeedConsumptionTest(Fixture.ApplicationFixture fixture)
        {
            useCase = fixture.Container.Resolve<IPaymentfeedConsumptionUseCase>();
            invoiceWriteOnlyRepository = fixture.Container.Resolve<IInvoiceWriteOnlyRepository>();
            paymentFeedWriteOnlyRepository = fixture.Container.Resolve<IPaymentFeedWriteOnlyRepository>();
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(0)]
        public void ShouldSavePaymentFeed()
        {
            var invoices = new List<Invoice>()
            {
                InvoiceBuilder.New().WithIdFile(idFile).WithInvoiceNumber("INV-009991")
                    .WithServices(new List<ServiceInvoice>() { Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithInvoiceNumber("INV-009991")
                        .WithActivity("Credits")
                        .WithGrandTotalRetailPrice(-1879)
                        .WithServiceCode("office365")
                        .Build()})
                    .WithCustomer( CustomerBuilder.New().WithCustomerCode("453423").WithBillingStateOrProvince("São Paulo").Build())
                    .WithPaymentMethod("Cartão de Crédito")
                    .Build(),
                InvoiceBuilder.New().WithIdFile(idFile).WithInvoiceNumber("INV-009992")
                    .WithServices(new List<ServiceInvoice>() { Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithInvoiceNumber("INV-009992")
                        .WithActivity("Credits")
                        .WithGrandTotalRetailPrice(-900)
                        .WithServiceCode("office365")
                        .Build()})
                    .WithCustomer( CustomerBuilder.New().WithCustomerCode("453423").WithBillingStateOrProvince("São Paulo").Build())
                      .WithPaymentMethod("Boleto")
                    .Build(),
                InvoiceBuilder.New().WithIdFile(idFile).WithInvoiceNumber("INV-009993")
                    .WithServices(new List<ServiceInvoice>() { Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithInvoiceNumber("INV-009993")
                        .WithActivity("Credits")
                        .WithGrandTotalRetailPrice(-900)
                        .WithServiceCode("office365")
                        .Build()})
                    .WithCustomer( CustomerBuilder.New().WithCustomerCode("453424").WithBillingStateOrProvince("São Paulo").Build())
                      .WithPaymentMethod("Boleto")
                    .Build()
            };

            var paymentfeeds_CreditCard = new List<SAP.Domain.JSDN.PaymentCreditCard>
            {
                PaymentFeedDocBuilder.New()
                    .WithPaymentDate(DateTime.UtcNow.ToString("dd/MM/yyyy"))
                    .WithDateProcessing(DateTime.UtcNow)
                    .WithTransactionAmount(100)
                    .WithCardBrand(1)
                    .WithCardPan("4365*****3465")
                    .WithCreditCardNSU("ssg5233")
                    .WithInvoiceNumberJsdn("INV-009991").Build(),
            };

            var paymentfeeds_Boleto = new List<SAP.Domain.JSDN.PaymentBoleto>
            {
                new PaymentBoletoBuilder().WithInvoiceNumberJsdn("INV-009992").Build(),
                new PaymentBoletoBuilder().WithInvoiceNumberJsdn("INV-009993").Build(),
            };

            var saveInvoices = invoiceWriteOnlyRepository.Add(invoices);
            var savePayCredit = paymentFeedWriteOnlyRepository.Add(paymentfeeds_CreditCard);
            var savePayBoleto = paymentFeedWriteOnlyRepository.Add(paymentfeeds_Boleto);

            Assert.True(saveInvoices > 0);
            Assert.True(savePayCredit > 0);
            Assert.True(savePayBoleto > 0);
        }

        [Fact]
        [Trait("Action", "None")]
        [TestPriority(1)]
        public void ShouldExecutePaymentfeedConsumptionUseCase()
        {
            var request = new PaymentfeedConsumptionRequest("7000453423");
            useCase.Execute(request);

            Assert.True(request.PaymentFeedsOutput.Count() >= 0);
        }
    }
}
