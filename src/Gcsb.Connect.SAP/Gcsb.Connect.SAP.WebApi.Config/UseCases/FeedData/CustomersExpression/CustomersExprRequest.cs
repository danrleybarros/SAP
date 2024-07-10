using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersExpression
{
    public class CustomersExprRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public TypeSearch TypeSearch { get; private set; }
        public string Value { get; private set; }

        public CustomersExprRequest(TypeSearch typeSearch, string value)
        {
            TypeSearch = typeSearch;
            Value = value;
        }
    }
}
