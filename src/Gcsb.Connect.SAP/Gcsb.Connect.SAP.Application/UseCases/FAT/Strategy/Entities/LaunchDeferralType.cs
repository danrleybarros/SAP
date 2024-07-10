namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Entities
{
    public enum LaunchDeferralType
    {
        IncomeAccountAdjustment,
        IncomeRecognition,
        IncomeRecognitionProvision,
        IncomeRecognitionWithAccumulatedInstallments,
        LongTermDeferringValue,
        LongTermDeferringInstallment,
        LongTermProvision,
        LongTermProvisionInstallment,
        ShortTermOfferProvision,       
        ReversalShortTermProvision,
        ReversalShortTermProvisionInstallment,
        ReversalLongTermProvision,
        ReversalLongTermProvisionInstallment,
        LongTermDeferringInstallmentWithAccumulatedInstallments
    }
}
