using Gcsb.Connect.SAP.Domain.FAT.FATaFaturarACM;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.FAT.FAT56
{
    public class LaunchBuilder
    {
        private static int index = 0;
        public int NumberLine;

        public DateTime LaunchDate;

        public string FinancialAccount;

        public string Complement;

        public decimal LaunchValue;

        public string ISSCode;

        public string ISSValue;

        public string Product;

        public string InternalOrder;

        public string UF;

        public string CostObject;

        public DateTime BillingCycle;

        public string TaxCostCenter;

        public string NetValue;

        public string PaymentMethod;

        public string BillingOption;

        public string AccountingEntry;

        public string AccountingAccount;
        public StoreType SType;
        public bool IsDiscount;

        public static LaunchBuilder New()
        {
            string[] accounts = { "FATCLOUDGW", "FATOFFICE365GW", "DESCCLOUDGW", "DESCOFFICE365GW" };



            var ret = new LaunchBuilder
            {
                NumberLine = 1,
                LaunchDate = new DateTime(2019, 01, 05), // 05/01/2019
                FinancialAccount = accounts[index],
                Complement = "",
                LaunchValue = 1000.00m,
                ISSCode = "",
                ISSValue = "",
                Product = "",
                InternalOrder = "T2929SP",
                UF = "SP",
                CostObject = "",
                BillingCycle = new DateTime(2019, 03, 31), // 31/03/2019
                TaxCostCenter = "",
                NetValue = "",
                PaymentMethod = "Cartão de Crédito",
                AccountingEntry = "C",
                AccountingAccount = "Crédito",
                SType = StoreType.TBRA
            };
            index++;
            if (index >= accounts.Length)
            { index = 0; }
            return ret;
        }

        public LaunchBuilder WithNumberLine(int numberline)
        {
            NumberLine = numberline;
            return this;
        }

        public LaunchBuilder WithLaunchDate(DateTime launchdate)
        {
            LaunchDate = launchdate;
            return this;
        }

        public LaunchBuilder WithFinancialAccount(string financialaccount)
        {
            FinancialAccount = financialaccount;
            return this;
        }

        public LaunchBuilder WithComplement(string complement)
        {
            Complement = complement;
            return this;
        }

        public LaunchBuilder WithLaunchValue(decimal launchvalue)
        {
            LaunchValue = launchvalue;
            return this;
        }

        public LaunchBuilder WithISSCode(string isscode)
        {
            ISSCode = isscode;
            return this;
        }

        public LaunchBuilder WithISSValue(string issvalue)
        {
            ISSValue = issvalue;
            return this;
        }

        public LaunchBuilder WithProduct(string product)
        {
            Product = product;
            return this;
        }

        public LaunchBuilder WithInternalOrder(string internalorder)
        {
            InternalOrder = internalorder;
            return this;
        }

        public LaunchBuilder WithUF(string uf)
        {
            UF = uf;
            return this;
        }

        public LaunchBuilder WithCostObject(string costobject)
        {
            CostObject = costobject;
            return this;
        }

        public LaunchBuilder WithBillingCycle(DateTime billingcycle)
        {
            BillingCycle = billingcycle;
            return this;
        }

        public LaunchBuilder WithTaxCostCenter(string taxcostcenter)
        {
            TaxCostCenter = taxcostcenter;
            return this;
        }

        public LaunchBuilder WithNetValue(string netvalue)
        {
            NetValue = netvalue;
            return this;
        }

        public LaunchBuilder WithPaymentMethod(string paymentMethod)
        {
            PaymentMethod = paymentMethod;
            return this;
        }

        public LaunchBuilder WithAccountingEntry(string accountingEntry)
        {
            AccountingEntry = accountingEntry;
            return this;
        }

        public LaunchBuilder WithAccountingAccount(string accountingAccount)
        {
            AccountingAccount = accountingAccount;
            return this;
        }

        public LaunchBuilder WithStoreType(StoreType storeType)
        {
            SType = storeType;
            return this;
        }

        public LaunchBuilder WithIsDiscount(bool isDiscount)
        {
            IsDiscount = isDiscount;
            return this;
        }

        public LaunchACM Build()
        {
            return new LaunchACM(NumberLine, LaunchDate, FinancialAccount, Complement, LaunchValue, ISSCode, ISSValue, Product, InternalOrder, UF, CostObject, BillingCycle, TaxCostCenter, NetValue, PaymentMethod, AccountingEntry, AccountingAccount, SType, IsDiscount);
        }
    }
}
