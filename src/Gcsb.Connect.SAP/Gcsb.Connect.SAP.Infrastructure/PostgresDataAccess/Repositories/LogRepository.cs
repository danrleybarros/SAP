using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class LogRepository : ILogWriteOnlyRepository, ILogReadOnlyRepository
    {
        private IMapper mapper;

        public LogRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Log logError)
        {
            var model = mapper.Map<Entities.Log>(logError);
            var retorno = 0;

            using (var context = new Context())
            {
                context.Log.Add(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public void Add(List<Log> logs)
        {
            var model = mapper.Map<List<Entities.Log>>(logs);
            var retorno = 0;

            using (var context = new Context())
            {
                context.Log.AddRange(model);
                retorno = context.SaveChanges();
            }
        }

        public int DeleteLogs(Expression<Func<Log, bool>> condition)
        {
            using (var context = new Context())
            {
                var predicate = mapper.Map<Expression<Func<Entities.Log, bool>>>(condition);
                var logs = context.Log.Where(predicate).ToList();
                context.Log.RemoveRange(logs);
                return context.SaveChanges();
            }
        }

        public int DeleteLogsDetails(Expression<Func<LogDetail, bool>> condition)
        {
            using (var context = new Context())
            {
                var predicate = mapper.Map<Expression<Func<Entities.LogDetail, bool>>>(condition);
                var logs = context.LogDetail.Where(predicate).ToList();
                context.LogDetail.RemoveRange(logs);
                return context.SaveChanges();
            }
        }

        public List<Log> GetLogs(Expression<Func<Log, bool>> condition)
        {
            using (var context = new Context())
            {
                var predicate = mapper.Map<Expression<Func<Entities.Log, bool>>>(condition);
                return mapper.Map<List<Log>>(context.Log.Include(s=>s.LogDetails).Where(predicate).ToList());
            }
        }

        public List<Log> GetLogsByDate(DateTime dateIni, DateTime dateEnd)
        {
            var listaLogs = new List<Log>();

            using (var context = new Context())
            {
                listaLogs = mapper.Map<List<Log>>(context.Log.Where(s => s.DateLog >= dateIni && s.DateLog <= dateEnd).Select(s => s).ToList());
            }

            return listaLogs;
        }

        public List<Log> GetLogsByFileId(Guid id)
        {
            var listaLogs = new List<Log>();

            using (var context = new Context())
            {
                listaLogs = mapper.Map<List<Log>>(context.Log.Where(s => s.FileId == id).Select(s => s).ToList());
            }

            return listaLogs;
        }

        public List<Log> GetLogsByServiceAndDate(string service, DateTime dateIni, DateTime dateEnd)
        {
            var listaLogs = new List<Log>();

            using (var context = new Context())
            {
                listaLogs = mapper.Map<List<Log>>(context.Log.Where(s => s.Service == service && s.DateLog >= dateIni && s.DateLog <= dateEnd).Select(s => s).ToList());
            }

            return listaLogs;
        }
    }
}
