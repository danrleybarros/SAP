namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions
{
    public class SearchExpression
    {
        public TypeSearch TypeSearch { get; private set; }
        public string Value { get; private set; }

        public SearchExpression(TypeSearch typeSearch, string value)
        {
            TypeSearch = typeSearch;
            Value = value;
        }
    }
}
