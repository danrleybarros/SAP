using Gcsb.Connect.SAP.Application.Repositories;
using Application = Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions;
using System;

using Autofac.Features.Indexed;

namespace Gcsb.Connect.SAP.Infrastructure.SearchExpression
{
    public class ExpressionFactory : IExpressionFactory
    {
        private readonly IIndex<Application::TypeSearch, Application::Expression> expression;

        public ExpressionFactory(IIndex<Application::TypeSearch, Application::Expression> expression)
        {
            this.expression = expression;
        }

        public Application::Expression GetExpression(Application::TypeSearch typeSearch)
        {
            return expression[typeSearch];
        }
    }
}
