using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class ReturnNFRepository : IReturnNFReadOnlyRepository, IReturnNFWriteOnlyRepository
    {
        IMapper mapper;
        public ReturnNFRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Guid Add(ReturnNF NF)
        {
            var model = mapper.Map<Entities.ReturnNF>(NF);
            using (Context context = new Context())
            {
                context.ReturnNF.Add(model);
                context.SaveChanges();
                return model.Id;
            }
        }

        public int Add(List<ReturnNF> NFs)
        {
            var ret = 0;

            using (Context context = new Context())
            {
                context.ReturnNF.AddRange(mapper.Map<List<Entities.ReturnNF>>(NFs));
                ret = context.SaveChanges();
            }

            return ret;
        }

        public List<ReturnNF> GetReturnNF()
        {
            var lList = new List<ReturnNF>();

            using (var context = new Context())
            {
                lList = mapper.Map<List<ReturnNF>>(context.ReturnNF);
            }

            return lList;
        }

        public ReturnNF GetReturnNF(string InvoiceId)
        {
            using (var context = new Context())
            {
                var returnnf = mapper.Map<ReturnNF>(context.ReturnNF.Where(w => InvoiceId == w.InvoiceID).FirstOrDefault());
                return returnnf;
            }
        }

        public List<ReturnNF> GetReturnNF(ReturnNF request)
        {
            var lList = new List<ReturnNF>();

            using (var context = new Context())
            {
                IQueryable<Entities.ReturnNF> lstreturn = context.ReturnNF;

                if (request.FileId != null && request.FileId != Guid.Empty)
                    lstreturn = lstreturn.Where(f => f.FileId.Equals(request.FileId));

                if (!string.IsNullOrEmpty(request.InvoiceID))
                    lstreturn = lstreturn.Where(f => f.InvoiceID.Equals(request.InvoiceID));

                if (!string.IsNullOrEmpty(request.NumeroNF))
                    lstreturn = lstreturn.Where(f => f.NumeroNF.Equals(request.NumeroNF));

                if (!string.IsNullOrEmpty(request.NFCancelada))
                    lstreturn = lstreturn.Where(f => f.NFCancelada.Equals(request.NFCancelada));


                lList = mapper.Map<List<ReturnNF>>(lstreturn.ToList());
            }

            return lList;
        }

        public List<ReturnNF> GetReturnNF(List<string> Invoices)
        {
            using var context = new Context();
            var returnnf = mapper.Map<List<ReturnNF>>(context.ReturnNF.Where(w => Invoices.Contains(w.InvoiceID)).ToList());

            return returnnf;
        }

        public List<ReturnNF> GetReturnNF(Guid ReturnNFFile)
        {
            using var context = new Context();
            var returnNFs = context.ReturnNF.Where(f => f.FileId.Equals(ReturnNFFile)).ToList();

            return mapper.Map<List<ReturnNF>>(returnNFs);
        }
    }
}
