using System;

namespace Gcsb.Connect.SAP.Tests.Builders.PAS
{
    public class BodyBuilder : Builder<Gcsb.Connect.SAP.Domain.PAS.Body>
    {

        public BodyBuilder()
        {
            Defaults();
        }

        public int LineNumber;
        public DateTime DocumentDate;
        public string CustomerName;
        public string Address;
        public string City;
        public string State;
        public long CEP;
        public string Doc;
        public decimal Value;
        public string Account;
        public string CostCenter;
        public string InternalOrder;
        public string TaxAccountDeb;
        public string TaxAccountCred;
        public string TaxCostCenter;
        public string CreditCard;
        public long NSU;
        public string AutorizationCode;
        public string Flag;
        public string Administrator;
        public string Acquirer;
        public string AccountingAccount;

        public BodyBuilder WithLineNumber(System.Int32 linenumber)
        {
            LineNumber = linenumber;
            return this;
        }
        public BodyBuilder WithDocumentDate(DateTime documentdate)
        {
            DocumentDate = documentdate;
            return this;
        }
        public BodyBuilder WithCustomerName(string customername)
        {
            CustomerName = customername;
            return this;
        }
        public BodyBuilder WithAddress(string address)
        {
            Address = address;
            return this;
        }
        public BodyBuilder WithCity(string city)
        {
            City = city;
            return this;
        }
        public BodyBuilder WithState(string state)
        {
            State = state;
            return this;
        }
        public BodyBuilder WithCEP(long cep)
        {
            CEP = cep;
            return this;
        }
        public BodyBuilder WithDoc(string doc)
        {
            Doc = doc;
            return this;
        }
        public BodyBuilder WithValue(Decimal value)
        {
            Value = value;
            return this;
        }
        public BodyBuilder WithAccount(string account)
        {
            Account = account;
            return this;
        }
        public BodyBuilder WithCostCenter(string costcenter)
        {
            CostCenter = costcenter;
            return this;
        }
        public BodyBuilder WithInternalOrder(string internalorder)
        {
            InternalOrder = internalorder;
            return this;
        }
        public BodyBuilder WithTaxAccountDeb(string taxaccountdeb)
        {
            TaxAccountDeb = taxaccountdeb;
            return this;
        }
        public BodyBuilder WithTaxAccountCred(string taxaccountcred)
        {
            TaxAccountCred = taxaccountcred;
            return this;
        }
        public BodyBuilder WithTaxCostCenter(string taxcostcenter)
        {
            TaxCostCenter = taxcostcenter;
            return this;
        }
        public BodyBuilder WithCreditCard(string creditcard)
        {
            CreditCard = creditcard;
            return this;
        }
        public BodyBuilder WithNSU(System.Int64 nsu)
        {
            NSU = nsu;
            return this;
        }
        public BodyBuilder WithAutorizationCode(string autorizationcode)
        {
            AutorizationCode = autorizationcode;
            return this;
        }
        public BodyBuilder WithFlag(string flag)
        {
            Flag = flag;
            return this;
        }
        public BodyBuilder WithAdministrator(string administrator)
        {
            Administrator = administrator;
            return this;
        }

        public new Domain.PAS.Body Build()
        {
            return new Domain.PAS.Body(
                                LineNumber,
                                DocumentDate,
                                CustomerName, 
                                Address,
                                City,
                                State,
                                CEP,
                                Doc,
                                Value,
                                Account,
                                CreditCard,
                                NSU,
                                AutorizationCode,
                                Flag);
        }

        public new void Defaults()
        {
            LineNumber = 666;
            DocumentDate = DateTime.UtcNow;
            CustomerName = RandomSap.GenerateName(new Random().Next(10, 18));
            Address = "Street 333";
            City = "São Paulo";
            State = "SP";
            CEP = 09121130;
            Doc = "59045774003";
            Value = (decimal)RandomSap.NextDouble(new Random(), 10, 100);
            Account = "ARRECGEN000GW";
            CreditCard = $"{new Random().Next(1000, 9999)}********{new Random().Next(1000, 9999)}";
            NSU = new Random().Next(1000000, 9999999);
            Flag = "1";
            Acquirer = "002";
            AutorizationCode = new Random().Next(10000000, 99999999).ToString();
            CostCenter = "29TR018233";
            AccountingAccount = "11211411";

        }
    }
}
