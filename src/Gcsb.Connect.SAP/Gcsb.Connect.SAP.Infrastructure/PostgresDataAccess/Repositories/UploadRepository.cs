using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.Domain.Upload;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class UploadRepository : IUploadReadOnlyRepository, IUploadWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public UploadRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Domain.Upload.Upload upload)
        {
            var model = mapper.Map<Entities.Upload>(upload);
            using (Context context = new Context())
            {
                context.Upload.Add(model);
                context.SaveChanges();
            }
            return 1;
        }

        public int Delete(Guid id)
        {
            using (var context = new Context())
            {
                var model = context.Upload.FirstOrDefault(f => f.Id == id);
                context.Upload.Remove(model);
                return context.SaveChanges();
            }
        }

        public Domain.Upload.Upload GetById(Guid Id)
        {
            using (var context = new Context())
            {
                return mapper.Map<Domain.Upload.Upload>(context.Upload.FirstOrDefault(s => s.Id == Id));
            }
        }

        public List<Domain.Upload.Upload> GetAll()
        {
            var list = new List<Domain.Upload.Upload>();
            using (var context = new Context())
            {
                list = mapper.Map<List<Domain.Upload.Upload>>(context.Upload.ToList());
            }
            return list;
        }

        public int Update(Domain.Upload.Upload upload)
        {
            using (var context = new Context())
            {
                context.Upload.Update(mapper.Map<Entities.Upload>(upload));
                return context.SaveChanges();
            }
        }
    }
}
