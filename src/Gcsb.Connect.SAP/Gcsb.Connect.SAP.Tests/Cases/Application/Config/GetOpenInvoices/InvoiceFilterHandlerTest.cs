using FluentAssertions;
using Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices;
using Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices;
using Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices.RequestHandlers;
using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Application.Config.GetOpenInvoices
{
    public class InvoiceFilterHandlerTest
    {
        [Fact]
        public void ShouldProcessRequest()
        {
            var credit = new PaymentCreditCardBuilder().WithInvoiceNumberJsdn("123").WithTransactionAmount(10).Build();
            var boleto1 = new PaymentBoletoBuilder().WithInvoiceNumberJsdn("321").WithTransactionAmount(10).Build();
            var boleto2 = new PaymentBoletoBuilder().WithInvoiceNumberJsdn("321").WithTransactionAmount(10).Build();

            var invoices = new System.Collections.Generic.List<SAP.Domain.JSDN.BillFeedSplit.Invoice>
            {
                new InvoiceBuilder().WithInvoiceNumber("123").WithTotalInvoicePrice(10).Build(),
                new InvoiceBuilder().WithInvoiceNumber("321").WithTotalInvoicePrice(30).Build(),
                new InvoiceBuilder().WithInvoiceNumber("111").WithTotalInvoicePrice(20).Build(),
                new InvoiceBuilder().WithInvoiceNumber("222").WithTotalInvoicePrice(10).Build() 
            };

            var services = new System.Collections.Generic.List<SAP.Domain.JSDN.BillFeedSplit.ServiceInvoice>
            {
                Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithInvoiceNumber("123").WithDueDate(DateTime.UtcNow.AddDays(1)).Build(),
                Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithInvoiceNumber("321").WithDueDate(DateTime.UtcNow.AddDays(1)).Build(),
                Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithInvoiceNumber("111").WithDueDate(DateTime.UtcNow.AddDays(1)).Build(),
                Builders.JSDN.BillFeedSplit.ServiceBuilder.New().WithInvoiceNumber("222").WithDueDate(DateTime.UtcNow.AddDays(1)).Build(),
            };

            var customers = new System.Collections.Generic.List<SAP.Domain.JSDN.BillFeedSplit.Customer>
            {
                CustomerBuilder.New().WithCustomerCode("4567890").WithInvoiceNumber("123").Build(),
                CustomerBuilder.New().WithCustomerCode("4567891").WithInvoiceNumber("321").Build(),
                CustomerBuilder.New().WithCustomerCode("4567892").WithInvoiceNumber("111").Build(),
                CustomerBuilder.New().WithCustomerCode("4567893").WithInvoiceNumber("222").Build(),
            };

            var request = new GetOpenInvoicesRequest(SearchType.CustomerCode, "123")
            {
                Invoices = invoices,
                Services = services,
                Customers = customers
            };

            request.Payments.Add(credit);
            request.Payments.Add(boleto1);
            request.Payments.Add(boleto2);

            var handler = new InvoiceFilterHandler();
            handler.ProcessRequest(request);

            request.OpenInvoicesOutput.Should().HaveCount(3);
        }
    }
}
