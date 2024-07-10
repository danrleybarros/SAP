using FluentValidation;
using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersExpression;

namespace Gcsb.Connect.SAP.WebApi.Config.Validator
{
    public class CustomersExprRequestValidator : AbstractValidator<CustomersExprRequest>
    {
        public CustomersExprRequestValidator()
        {
            RuleFor(a => a.Value).NotNull().NotEmpty();
            RuleFor(a => a.TypeSearch).IsInEnum().NotEmpty().NotNull();
        }
    }
}
