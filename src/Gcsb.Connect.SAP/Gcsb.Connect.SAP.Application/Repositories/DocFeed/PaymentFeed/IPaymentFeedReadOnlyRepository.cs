using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed
{
    public interface IPaymentFeedReadOnlyRepository
    {
        List<PaymentCreditCard> GetPaymentFeed();

        PaymentCreditCard GetPaymentFeed(string invoiceNumber);

        PaymentCreditCard GetPaymentFeed(Guid Id);

        List<PaymentCreditCard> GetPaymentFeedCredit(List<string> invoiceNumbers);

        List<PaymentBoleto> GetPaymentFeedBoleto(List<string> invoiceNumbers);

        List<PaymentCreditCard> GetPaymentFeedCredit(Expression<Func<PaymentCreditCard, bool>> func);

        List<PaymentBoleto> GetPaymentFeedBoleto(Expression<Func<PaymentBoleto, bool>> func);
    }
}
