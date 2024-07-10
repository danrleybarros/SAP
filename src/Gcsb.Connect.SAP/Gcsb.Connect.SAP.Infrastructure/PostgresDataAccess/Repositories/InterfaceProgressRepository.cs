using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.Domain.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class InterfaceProgressRepository : IInterfaceProgressRepository
    {
        private readonly IMapper mapper;

        public InterfaceProgressRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(InterfaceProgress interfaceProgress)
        {
            var model = mapper.Map<Entities.InterfaceProgress>(interfaceProgress);
            using (Context context = new Context())
            {
                context.InterfaceProgress.Add(model);
                return context.SaveChanges();
            }            
        }

        public int Add(List<InterfaceProgress> interfacesProgress)
        {
            var model = mapper.Map<List<Entities.InterfaceProgress>>(interfacesProgress);
            using (Context context = new Context())
            {
                context.InterfaceProgress.AddRange(model);
                return context.SaveChanges();
            }
        }

        public int Delete(InterfaceProgress interfaceProgress)
        {
            using (var context = new Context())
            {
                var model = context.InterfaceProgress.FirstOrDefault(f => f.Id == interfaceProgress.Id);
                context.InterfaceProgress.Remove(model);
                return context.SaveChanges();
            }
        }

        public List<InterfaceProgress> GetAll()
        {
            var list = new List<Domain.Upload.InterfaceProgress>();
            using (var context = new Context())
            {
                list = mapper.Map<List<Domain.Upload.InterfaceProgress>>(context.InterfaceProgress.ToList());
            }
            return list;
        }

        public List<InterfaceProgress> GetByFilter(Expression<Func<InterfaceProgress, bool>> expression)
        {
            using var context = new Context();
            var expr = mapper.Map<Expression<Func<Entities.InterfaceProgress, bool>>>(expression);            
            return mapper.Map<List<InterfaceProgress>>(context.InterfaceProgress.Where(expr).ToList());                     
        }

        public int Update(InterfaceProgress interfaceProgress)
        {
            using (var context = new Context())
            {                
                context.InterfaceProgress.Update(mapper.Map<Entities.InterfaceProgress>(interfaceProgress));
                return context.SaveChanges();
            }
        }
    }
}
