using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Boundaries.AllCustomers
{
    public class AllCustomersOutput
    {
        public string Cnpj { get; private set; }
        public string CustomerCode { get; private set; }
        public string CustomerCodeStr { get => $"7{ CustomerCode.PadLeft(9, '0') }"; }
        public string CustomerName { get; private set; }
        public string StoreAcronym { get; private set; }
        public string StoreName { get; private set; }

        public AllCustomersOutput(string cnpj, string customerCode, string customerName, string storeAcronym, string storeName)
        {
            Cnpj = cnpj;
            CustomerCode = customerCode;
            CustomerName = customerName;
            StoreAcronym = storeAcronym;
            StoreName = storeName;
        }
    }
}
