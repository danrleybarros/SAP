using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed
{
    public interface IPaymentFeedWriteOnlyRepository
    {
        int Add(PaymentCreditCard paymentFeedDoc);

        int Add(List<PaymentCreditCard> paymentFeedDocs);

        int Delete(PaymentCreditCard paymentFeedDoc);

        int Add(PaymentBoleto paymentFeedDoc);

        int Add(List<PaymentBoleto> paymentFeedDocs);

        int Delete(PaymentBoleto paymentFeedDoc);

        int DeleteAll();
        int DeleteBoleto(Expression<Func<PaymentBoleto, bool>> func);
        int DeleteCreditCard(Expression<Func<PaymentCreditCard, bool>> func);
    }
}
