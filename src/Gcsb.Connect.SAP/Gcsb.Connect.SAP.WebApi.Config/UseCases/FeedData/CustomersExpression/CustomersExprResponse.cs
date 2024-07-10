namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CustomersExpression
{
    public class CustomersExprResponse
    {
        public string Cnpj { get; private set; }
        public string CustomerCode { get; private set; }
        public string CustomerName { get; private set; }
        public string StoreAcronym { get; private set; }
        public string StoreName { get; private set; }

        public CustomersExprResponse(string cnpj, string customerCode, string customerName, string storeAcronym, string storeName)
        {
            Cnpj = cnpj;
            CustomerCode = customerCode;
            CustomerName = customerName;
            StoreAcronym = storeAcronym;
            StoreName = storeName;
        }
    }
}
