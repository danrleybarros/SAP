using Autofac;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.Config.CustomersConsumption.RequestHandlers;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using System.Collections.Generic;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.CustomerConsumption
{
    public class MountConsumptionDataHandlerTest : IClassFixture<Fixture.ApplicationFixture>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public MountConsumptionDataHandlerTest(Fixture.ApplicationFixture fixture)
        {
            customerReadOnlyRepository = fixture.Container.Resolve<ICustomerReadOnlyRepository>();
            invoiceReadOnlyRepository = fixture.Container.Resolve<IInvoiceReadOnlyRepository>();
        }

        [Fact]
        public void ShouldGetPaymentValueBoleto()
        {
            var handler = new MountConsumptionDataHandler(customerReadOnlyRepository, invoiceReadOnlyRepository);

            var paymentBoleto = new PaymentBoletoBuilder().WithInvoiceNumberJsdn("123").WithValorRecebido(50m).Build();
            var paymentCredit = new PaymentCreditCardBuilder().WithInvoiceNumberJsdn("321").WithTransactionAmount(10m).Build();

            var result = handler.GetPaymentValue("123", new List<PaymentCreditCard> { paymentCredit }, new List<PaymentBoleto> { paymentBoleto });

            Assert.Equal(50m, result.Value, 1);
        }

        [Fact]
        public void ShouldGetPaymentValueCreditCard()
        {
            var handler = new MountConsumptionDataHandler(customerReadOnlyRepository, invoiceReadOnlyRepository);

            var paymentBoleto = new PaymentBoletoBuilder().WithInvoiceNumberJsdn("123").WithValorRecebido(50m).Build();
            var paymentCredit = new PaymentCreditCardBuilder().WithInvoiceNumberJsdn("321").WithTransactionAmount(10m).Build();

            var result = handler.GetPaymentValue("321", new List<PaymentCreditCard> { paymentCredit }, new List<PaymentBoleto> { paymentBoleto });

            Assert.Equal(10m, result.Value, 1);
        }

        [Fact]
        public void ShouldGetPaymentValueZero()
        {
            var handler = new MountConsumptionDataHandler(customerReadOnlyRepository, invoiceReadOnlyRepository);

            var paymentBoleto = new PaymentBoletoBuilder().WithInvoiceNumberJsdn("123").WithValorRecebido(50m).Build();
            var paymentCredit = new PaymentCreditCardBuilder().WithInvoiceNumberJsdn("321").WithTransactionAmount(10m).Build();

            var result = handler.GetPaymentValue("111", new List<PaymentCreditCard> { paymentCredit }, new List<PaymentBoleto> { paymentBoleto });

            Assert.Equal(0, result.Value, 1);
        }
    }
}
