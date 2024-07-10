using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.SearchExpression.Expression
{
    public class CnpjExpression : Application.UseCases.Config.AllCustomers.SearchExpressions.Expression
    {
        public override TypeSearch TypeSearch => TypeSearch.Cnpj;

        public override Expression<Func<Customer, bool>> CustomerExpression
        {
            get => (s => s.CustomerCNPJ.Contains(Value));
        }
    }
}
