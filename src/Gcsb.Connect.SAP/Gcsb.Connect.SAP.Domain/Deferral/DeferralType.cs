namespace Gcsb.Connect.SAP.Domain.Deferral
{
    public enum DeferralType
    {
        NewDeferral,
        ShortTermRecurringDeferralNFEmittedActivatedService,
        ShortTermRecurringDeferralNFEmittedWithServiceActivation,
        ShortTermInitialDeferralNFEmittedActivatedService,
        ShortTermInitialDeferralNFEmittedNotActivatedService,
        ShortTermInitialDeferralNFEmittedActivatedServiceWithDiscount,     
        LongTermRecurringDeferralNFEmittedActivatedServiceWithShortBalanceRemaining,
        LongTermRecurringDeferralNFEmittedActivatedServiceWithLongBalanceRemaining,
        LongTermInitialDeferralNFEmittedActivatedService,
        LongTermInitialDeferralNFEmittedNotActivatedService,
        LongTermRecurringDeferralNFEmittedWithServiceActivation,
        ShortTermNFEmittedDeferralProvisionWithRevenueRecognition,
        ShortTermNFEmittedDeferralProvisionWithoutRevenueRecognition,
        ShortTermRecurringDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays,
        ShortTermInitialDeferralProvisionNotNFEmittedLessThan30PurchaseDays,
        ShortTermInitialDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays,        
        LongTermInitialDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays,
        LongTermInitialDeferralProvisionNotNFEmittedLessThan30PurchaseDays,
        LongTermNFEmittedDeferralProvisionWithoutRevenueRecognition,
        LongTermNFEmittedDeferralProvisionWithRevenueRecognition,
        LongTermRecurringDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays

    }


}



