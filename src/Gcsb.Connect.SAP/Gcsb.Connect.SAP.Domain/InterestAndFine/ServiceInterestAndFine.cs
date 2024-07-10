namespace Gcsb.Connect.SAP.Domain.InterestAndFine
{
    public class ServiceInterestAndFine
    {
        public string InvoiceNumber { get; private set; }
        public string ServiceCode { get; private set; }
        public double Price { get; private set; }
        public double Quantity { get; private set; }
        public string Type { get; private set; }

        public ServiceInterestAndFine(string invoiceNumber, string serviceCode, double price,
            double quantity, string type)
        {
            InvoiceNumber = invoiceNumber;
            ServiceCode = serviceCode;
            Price = price;
            Quantity = quantity;
            Type = type;
        }
    }
}
