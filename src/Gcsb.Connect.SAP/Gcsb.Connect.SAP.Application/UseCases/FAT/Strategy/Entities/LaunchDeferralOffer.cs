using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Entities
{
    public class LaunchDeferralOffer
    {
        public Guid DeferralId { get; private set; }
        public string InvoiceNumber { get; private set; }
        public string ServiceCode { get; private set; }
        public string OfferCode { get; private set; }
        public double LaunchValue { get; private set; }
        public string InternalOrder { get; private set; }
        public string Uf { get; private set; }
        public string ServiceType { get; private set; }
        public string PaymentMethod { get; private set; }
        public string StoreAcronym { get; private set; }
        public string ProviderCompanyAcronym { get; private set; }
        public List<Domain.FAT.FATBase.AccountingEntry> AccountingEntries { get; set; }
        public LaunchDeferralType LaunchDeferralType { get; set; }

        public LaunchDeferralOffer(DeferralOffer deferralOffer, List<Domain.FAT.FATBase.AccountingEntry> accountingEntries, LaunchDeferralType launchDeferralType)
        {
            DeferralId = deferralOffer.Id;
            InvoiceNumber = deferralOffer.InvoiceNumber;
            ServiceCode = deferralOffer.ServiceCode;
            OfferCode = deferralOffer.OfferCode;
            AccountingEntries = accountingEntries;
            Uf = deferralOffer.BillingStateOrProvince;
            ServiceType = deferralOffer.ServiceType;
            PaymentMethod = deferralOffer.PaymentMethod;
            LaunchValue = GetLaunchValue(launchDeferralType, deferralOffer);
            LaunchDeferralType = launchDeferralType;
            StoreAcronym = deferralOffer.StoreAcronym;
            ProviderCompanyAcronym = deferralOffer.ProviderStoreAcronym;
        }

        private double GetLaunchValue(LaunchDeferralType type, DeferralOffer deferralOffer)
       => type switch
       {
           LaunchDeferralType.IncomeAccountAdjustment => deferralOffer.TotalBalance,
           LaunchDeferralType.LongTermDeferringValue =>  deferralOffer.GetTotalLongBalance() ,           
           LaunchDeferralType.LongTermProvision => deferralOffer.TotalLongBalance,
           LaunchDeferralType.ReversalLongTermProvision => deferralOffer.GetTotalLongBalance(),
           LaunchDeferralType.ShortTermOfferProvision => deferralOffer.TotalShortBalance ,
           LaunchDeferralType.ReversalShortTermProvision => deferralOffer.GetTotalShortBalance(),
           LaunchDeferralType.LongTermDeferringInstallment => deferralOffer.GetInstallmentAmount(),
           LaunchDeferralType.LongTermDeferringInstallmentWithAccumulatedInstallments => (deferralOffer.CurrentInstallment * deferralOffer.GetInstallmentAmount()) + deferralOffer.GetInstallmentAmount(),
           LaunchDeferralType.IncomeRecognition => deferralOffer.GetInstallmentAmount(),
           LaunchDeferralType.IncomeRecognitionProvision => deferralOffer.GetInstallmentAmount(),
           LaunchDeferralType.IncomeRecognitionWithAccumulatedInstallments => (deferralOffer.CurrentInstallment * deferralOffer.GetInstallmentAmount()) + deferralOffer.GetInstallmentAmount(),
           LaunchDeferralType.ReversalShortTermProvisionInstallment => (deferralOffer.CurrentInstallment * deferralOffer.GetInstallmentAmount()),
           LaunchDeferralType.LongTermProvisionInstallment => deferralOffer.GetInstallmentAmount(),
           LaunchDeferralType.ReversalLongTermProvisionInstallment => (deferralOffer.CurrentInstallment * deferralOffer.GetInstallmentAmount()),        
           _ => throw new NotSupportedException()
       };
    }
}
