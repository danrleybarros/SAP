using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;

namespace Gcsb.Connect.SAP.Domain.FAT.FATaFaturarECM
{
    public class LaunchECM : Launch
    {
        protected override string type => "ECM";

        protected override string lauchDateFormat => "01MMyyyy";

        protected override string billingCycleFormat => $"01{string.Format(billingCycleDateFormat, BillingCycle)}";

        public LaunchECM(int numberline, DateTime launchdate, string financialaccount, string complement, decimal launchvalue, string isscode, string issvalue, string product, string internalorder, string uf, string costobject, DateTime billingcycle, string taxcostcenter,
            string netvalue, string paymentMethod, string accountingEntry, string accountingAccount, StoreType storeType, bool isDiscount)
            : base(numberline, launchdate, financialaccount, complement, launchvalue, isscode, issvalue, product, internalorder, uf, costobject, billingcycle, taxcostcenter, netvalue, paymentMethod, accountingEntry, accountingAccount, storeType, isDiscount)
        { }

        public LaunchECM(int numberLine, DateTime launchDate, string financialAccount, decimal launchValue, string internalOrder, string uf, DateTime billingCycle, 
            string paymentMethod, string accountingEntry, string accountingAccount, StoreType storeType, bool isDiscount)
            : base(numberLine, launchDate, financialAccount, launchValue, internalOrder, uf, billingCycle, paymentMethod, accountingEntry, accountingAccount, storeType, isDiscount)
        { }

        public LaunchECM(int numberLine, DateTime launchDate, string financialAccount, decimal launchValue, string internalOrder, string uf, DateTime billingCycle,
            string paymentMethod, string accountingEntry, string accountingAccount, StoreType storeType, bool isDiscount, bool haveIntercompany, bool isDeferral = false)
            : base(numberLine, launchDate, financialAccount, launchValue, internalOrder, uf, billingCycle, paymentMethod, accountingEntry, accountingAccount, storeType, isDiscount, haveIntercompany,isDeferral)
        { }
    }
}
