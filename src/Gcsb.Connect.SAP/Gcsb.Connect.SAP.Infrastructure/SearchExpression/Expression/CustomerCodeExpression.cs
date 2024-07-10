using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Infrastructure.SearchExpression.Expression
{
    public class CustomerCodeExpression : Application.UseCases.Config.AllCustomers.SearchExpressions.Expression
    {
        public override TypeSearch TypeSearch => TypeSearch.CustomerCode;

        public override Expression<Func<Customer, bool>> CustomerExpression
        {
            get => (s => Value.Contains(s.CustomerCode) || s.CustomerCode.Contains(Value));
        }
    }
}
