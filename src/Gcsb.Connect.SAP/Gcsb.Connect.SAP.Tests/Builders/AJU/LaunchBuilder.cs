using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.AJU
{
    public class LaunchBuilder
    {
        public LaunchBuilder()
        {
            Defaults();
        }

        public int LineNumber;
        public DateTime LaunchDate;
        public string FinancialAccount;
        public string Complement;
        public decimal LaunchValue;
        public string CodeISS;
        public string ValueISS;
        public string Reason;
        public string Product;
        public string InternalOrder;
        public string CostObject;
        public DateTime BillingCycle;
        public string TaxCostCenter;
        public string LiquidValue;
        public string BusinessLocation;
        public string PaymentMethod;
        public string BillingOption;
        public string UF;
        public string TypeLaunchAccounting;
        public string AccountingAccount;
        public StoreType SType;


        public LaunchBuilder WithLineNumber(int linenumber)
        {
            LineNumber = linenumber;
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

        public LaunchBuilder WithLaunchValue(decimal launchvalue)
        {
            LaunchValue = launchvalue;
            return this;
        }

        public LaunchBuilder WithReason(string reason)
        {
            Reason = reason;
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

        public LaunchBuilder WithLiquidValue(string liquidvalue)
        {
            LiquidValue = liquidvalue;
            return this;
        }        

        public LaunchBuilder WithUF(string uf)
        {
            UF = uf;
            return this;
        }

        public LaunchBuilder WithPaymentMethod(string paymentMethod)
        {
            PaymentMethod = paymentMethod;
            return this;
        }

        public LaunchBuilder WithTypeLaunchAccounting(string typeLaunchAccounting)
        {
            TypeLaunchAccounting = typeLaunchAccounting;
            return this;
        }

        public LaunchBuilder WithAccountingAccount(string accountingAccount)
        {
            AccountingAccount = accountingAccount;
            return this;
        }

        public LaunchBuilder WithSType(StoreType storeType)
        {
            SType = storeType;
            return this;
        }

        public Domain.AJU.Launch Build()
            => new SAP.Domain.AJU.Launch(LineNumber, LaunchDate, FinancialAccount,Complement, LaunchValue,CodeISS, ValueISS , Product, InternalOrder, CostObject, BillingCycle, TaxCostCenter, LiquidValue, UF, PaymentMethod, TypeLaunchAccounting, AccountingAccount, SType);

        public void Defaults()
        {
            LineNumber = 1;
            LaunchDate = DateTime.UtcNow;
            FinancialAccount = "FATOFFICE365GW";
            LaunchValue = 1000.50m;
            Reason = "";
            Product = "";
            InternalOrder = "";
            CostObject = "";
            BillingCycle = DateTime.UtcNow.AddMonths(-1);
            TaxCostCenter = "";
            LiquidValue = "";
            BusinessLocation = "SP";
            UF = "SP";
            TypeLaunchAccounting = "C";
            AccountingAccount = "COFFICE365";
            SType = StoreType.TBRA;
        }
    }
}
