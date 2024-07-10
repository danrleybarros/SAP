using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.RequestHandlers
{
    public class GetCustomersHandler : Handler
    {
        private readonly IExpressionFactory expressionFactory;
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public GetCustomersHandler(IExpressionFactory expressionFactory, ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.expressionFactory = expressionFactory;
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public override void ProcessRequest(AllCustomersRequest request)
        {
            var expression = expressionFactory.GetExpression(request.SearchExpression.TypeSearch);
            var customerFilterExpress = expression.GetCustomerExpression(request.SearchExpression.Value);

            request.Customers.AddRange(customerReadOnlyRepository.GetCustomers(customerFilterExpress));

            sucessor?.ProcessRequest(request);
        }
    }
}
