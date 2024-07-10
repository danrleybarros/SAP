using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Gcsb.Connect.Pkg.DynamicSearch.Domain;
using Gcsb.Connect.Pkg.DynamicSearch.Infrastructure;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.DynamicSearch
{
    public class DynamicRepository<T> : IDynamicRepository<T> where T : class
    {
        public string Table { get; private set; }
        public string Schema { get; private set; }

        private DbProperties GetCustomerProperties() => new DbProperties(Table, Schema);

        public List<T> Get(Expression<Func<T, bool>> expression)
        {
            using var context = new Context<T>(GetCustomerProperties());

            return context.Entity.Where(expression).ToList();
        }

        public List<T> GetAll()
        {
            using var context = new Context<T>(GetCustomerProperties());

            return context.Entity.ToList();
        }

        public T GetFirst(Expression<Func<T, bool>> expression)
        {
            using var context = new Context<T>(GetCustomerProperties());

            return context.Entity.Where(expression).FirstOrDefault();
        }

        public void ConfigDatabase(string schema, string table)
        {
            this.Schema = schema;
            this.Table = table;
        }
    }
}
