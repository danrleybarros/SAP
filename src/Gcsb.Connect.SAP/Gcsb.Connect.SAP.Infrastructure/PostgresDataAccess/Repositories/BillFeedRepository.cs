using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Gcsb.Connect.SAP.Application.Boundaries.Deferral;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.JSDN;


namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class BillFeedRepository : IBillFeedReadOnlyRepository, IBillFeedWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public BillFeedRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(IEnumerable<BillFeedDoc> billFeedDoc)
        {
            var model = mapper.Map<List<Entities.BillFeedDoc>>(billFeedDoc.ToList());
            var retorno = 0;

            using (var context = new Context())
            {
                context.BillFeed.AddRange(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Add(BillFeedDoc billFeedDoc)
        {
            var model = mapper.Map<Entities.BillFeedDoc>(billFeedDoc);
            var retorno = 0;

            using (var context = new Context())
            {
                context.BillFeed.Add(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Delete(BillFeedDoc billFeedDoc)
        {
            var model = mapper.Map<Entities.BillFeedDoc>(billFeedDoc);
            var retorno = 0;

            using (var context = new Context())
            {
                context.BillFeed.Remove(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Delete(Expression<Func<BillFeedDoc, bool>> func)
        {
            using (var context = new Context())
            {
                var listBill = context.BillFeed.Where(mapper.Map<Expression<Func<Entities.BillFeedDoc, bool>>>(func)).ToList();
                context.BillFeed.RemoveRange(listBill);
                return context.SaveChanges();
            }
        }

        public List<BillFeedDoc> GetBillFeed()
        {
            var listBillFeedDoc = new List<BillFeedDoc>();

            using (var context = new Context())
            {
                listBillFeedDoc = mapper.Map<List<BillFeedDoc>>(context.BillFeed).Select(s => s).ToList();
            }

            return listBillFeedDoc;
        }

        public List<BillFeedDoc> GetBillFeed(Expression<Func<BillFeedDoc, bool>> where)
        {
            var listBillFeedDoc = new List<BillFeedDoc>();

            using (var context = new Context())
            {
                var listBill = context.BillFeed.Where(mapper.Map<Expression<Func<Entities.BillFeedDoc, bool>>>(where)).ToList();
                var invoices = listBill.Select(s => s.InvoiceNumber).Distinct().ToList();

                listBillFeedDoc = mapper.Map<List<BillFeedDoc>>(context.BillFeed.Where(w => invoices.Contains(w.InvoiceNumber)).ToList());
            }

            return listBillFeedDoc;
        }

        public BillFeedCycleDate GetCycleByBillFeedId(Guid billFeedId)
        {
            using var context = new Context();

            var cycleDate = default(BillFeedCycleDate);
            var billfeed = context.BillFeed.Where(w => w.IdFile == billFeedId).ToList();

            if (billfeed.Any())
                cycleDate = new BillFeedCycleDate { BillFrom = billfeed.Min(m => m.BillFrom ?? default(DateTime)), BillTo = billfeed.Max(m => m.BillTo ?? default(DateTime)) };

            return cycleDate;
        }
    }
}
