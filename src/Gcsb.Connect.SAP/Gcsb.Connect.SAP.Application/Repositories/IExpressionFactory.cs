
using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IExpressionFactory
    {
        Expression GetExpression(TypeSearch typeSearch);
    }
}
