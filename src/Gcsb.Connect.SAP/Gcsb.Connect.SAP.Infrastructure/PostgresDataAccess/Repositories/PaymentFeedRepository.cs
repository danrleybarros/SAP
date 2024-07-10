using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class PaymentFeedRepository : IPaymentFeedWriteOnlyRepository, IPaymentFeedReadOnlyRepository
    {
        private IMapper mapper;

        public PaymentFeedRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(PaymentCreditCard paymentFeedDoc)
        {
            var model = mapper.Map<Entities.PaymentCreditCard>(paymentFeedDoc);
            var retorno = 0;

            using (var context = new Context())
            {
                context.PaymentFeedCreditCard.Add(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Add(List<PaymentCreditCard> paymentFeedDocs)
        {
            var model = mapper.Map<List<Entities.PaymentCreditCard>>(paymentFeedDocs);
            var retorno = 0;

            using (var context = new Context())
            {
                context.PaymentFeedCreditCard.AddRange(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Delete(PaymentCreditCard paymentFeedDoc)
        {
            var model = mapper.Map<Entities.PaymentCreditCard>(paymentFeedDoc);
            var retorno = 0;

            using (var context = new Context())
            {
                context.PaymentFeedCreditCard.Remove(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Add(PaymentBoleto paymentFeedDoc)
        {
            var model = mapper.Map<Entities.PaymentBoleto>(paymentFeedDoc);
            var retorno = 0;

            using (var context = new Context())
            {
                context.PaymentBoleto.Add(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Add(List<PaymentBoleto> paymentFeedDocs)
        {
            var model = mapper.Map<List<Entities.PaymentBoleto>>(paymentFeedDocs);
            var retorno = 0;

            using (var context = new Context())
            {
                context.PaymentBoleto.AddRange(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Delete(PaymentBoleto paymentFeedDoc)
        {
            var model = mapper.Map<Entities.PaymentBoleto>(paymentFeedDoc);
            var retorno = 0;

            using (var context = new Context())
            {
                context.PaymentBoleto.Remove(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int DeleteAll()
        {
            var retorno = 0;

            using (var context = new Context())
            {
                var model = context.PaymentFeedCreditCard;
                context.PaymentFeedCreditCard.RemoveRange(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public List<PaymentCreditCard> GetPaymentFeed()
        {
            var paymentFeedDocs = new List<PaymentCreditCard>();


            using (var context = new Context())
            {
                paymentFeedDocs = mapper.Map<List<PaymentCreditCard>>(context.PaymentFeedCreditCard.ToList());
            }

            return paymentFeedDocs;
        }

        public PaymentCreditCard GetPaymentFeed(string invoiceNumber)
        {
            PaymentCreditCard paymentFeedDoc;

            using (var context = new Context())
            {
                paymentFeedDoc = mapper.Map<PaymentCreditCard>(context.PaymentFeedCreditCard.Where(w => w.InvoiceNumberJsdn.Equals(invoiceNumber) && w.ResultCode >= 0 && w.ResultCode <= 99).FirstOrDefault());
            }

            return paymentFeedDoc;
        }

        public List<PaymentCreditCard> GetPaymentFeedCredit(List<string> invoiceNumbers)
        {
            using (var context = new Context())
            {
                return mapper.Map<List<PaymentCreditCard>>(context.PaymentFeedCreditCard.Where(w => invoiceNumbers.Contains(w.InvoiceNumberJsdn) && w.ResultCode >= 0 && w.ResultCode <= 99).ToList());
            }
        }

        public List<PaymentCreditCard> GetPaymentFeedCredit(Expression<Func<PaymentCreditCard, bool>> func)
        {
            using (var context = new Context())
            {
                return mapper.Map<List<PaymentCreditCard>>(context.PaymentFeedCreditCard.Where(mapper.Map<Expression<Func<Entities.PaymentCreditCard, bool>>>(func)).ToList());
            }
        }

        public PaymentCreditCard GetPaymentFeed(Guid Id)
        {
            PaymentCreditCard paymentFeedDoc;

            using (var context = new Context())
            {
                paymentFeedDoc = mapper.Map<PaymentCreditCard>(context.PaymentFeedCreditCard.Where(w => w.IdFile.Equals(Id)).FirstOrDefault());
            }

            return paymentFeedDoc;
        }

        public List<PaymentBoleto> GetPaymentFeedBoleto(List<string> invoiceNumbers)
        {
            using (var context = new Context())
            {
                return mapper.Map<List<PaymentBoleto>>(context.PaymentBoleto.Where(w => invoiceNumbers.Contains(w.InvoiceNumberJsdn)).ToList());
            }
        }

        public List<PaymentBoleto> GetPaymentFeedBoleto(Expression<Func<PaymentBoleto, bool>> func)
        {
            using (var context = new Context())
            {
                return mapper.Map<List<PaymentBoleto>>(context.PaymentBoleto.Where(mapper.Map<Expression<Func<Entities.PaymentBoleto, bool>>>(func)).ToList());
            }
        }

        public int DeleteBoleto(Expression<Func<PaymentBoleto, bool>> func)
        {
            using (var context = new Context())
            {
                var payments = context.PaymentBoleto.Where(mapper.Map<Expression<Func<Entities.PaymentBoleto, bool>>>(func)).ToList();                
                context.PaymentBoleto.RemoveRange(payments);
                return context.SaveChanges();
            }
        }

        public int DeleteCreditCard(Expression<Func<PaymentCreditCard, bool>> func)
        {
            using(var context = new Context())
            {
                var payments = context.PaymentFeedCreditCard.Where(mapper.Map<Expression<Func<Entities.PaymentCreditCard, bool>>>(func)).ToList();
                context.PaymentFeedCreditCard.RemoveRange(payments);
                return context.SaveChanges();
            }
        }
    }
}
