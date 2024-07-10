using Gcsb.Connect.SAP.Application.Repositories.Pay;
using Moq;
using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Tests.Builders.PAY;

namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class ServicePayMock
    {
        public Mock<IServicePay> Execute()
        {
            var mockServicePay = new Mock<IServicePay>();

            mockServicePay.Setup(i => i.Execute(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(new List<Domain.PAY.Critical> { CriticalBuilder.New().Build() });

            GetInvoicePayments(mockServicePay);

            return mockServicePay;
        }

        public void GetInvoicePayments(Mock<IServicePay> mock)
        {
            mock.Setup(i => i.GetInvoicePayment(It.IsAny<List<string>>()))
                .Returns((List<string> invoices) =>
                {
                    var response = new List<Domain.PAY.InvoicePayment>();
                    invoices.ForEach(a =>
                    {
                        response.Add(InvoicePaymentBuilder.New().WithInvoiceNumber(a).Build());
                        response.Add(InvoicePaymentBuilder.New().WithInvoiceNumber(a).Build());
                    });
                    return response;
                });
        }
    }
}
