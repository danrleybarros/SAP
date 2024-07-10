using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions
{
    public abstract class Expression
    {
        public abstract TypeSearch TypeSearch { get; }
        public string Value { get; set; }
        public abstract Expression<Func<Domain.JSDN.BillFeedSplit.Customer, bool>> CustomerExpression { get; }

        public virtual Expression<Func<Domain.JSDN.BillFeedSplit.Customer, bool>> GetCustomerExpression(
            string value)
        {
            Value = value;
            return CustomerExpression;
        }
    }
}
