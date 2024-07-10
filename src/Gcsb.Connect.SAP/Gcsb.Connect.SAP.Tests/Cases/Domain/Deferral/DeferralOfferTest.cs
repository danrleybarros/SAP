using FluentAssertions;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Tests.Builders.Deferral;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.Deferral
{
    public class DeferralOfferTest
    {
        [Fact]
        [Trait("Categoria", "Diferimento")]
        public void ShouldCreateShortTermDeferralOffer()
        {
            var sampleOffer = DeferralOfferBuilder.New()
                                                  .WithTotalBalance(1200000)
                                                  .WithNumberOfInstallments(12)
                                                  .Build();
            
            var offer = new DeferralOffer(sampleOffer.Id, 
                sampleOffer.CycleDate,
                sampleOffer.ServiceCode,
                sampleOffer.OfferCode,
                sampleOffer.CustomerCode,
                sampleOffer.OrderNumber,
                sampleOffer.ProviderStoreAcronym,               
                sampleOffer.InvoiceNumber,
                sampleOffer.StoreAcronym,
                sampleOffer.BillingStateOrProvince,
                sampleOffer.PaymentMethod,
                sampleOffer.ServiceType,
                sampleOffer.TotalBalance,
                sampleOffer.NumberOfInstallments,
                sampleOffer.DeferralCreationDate,
                sampleOffer.PurchaseDate,
                sampleOffer.LastUpdatedDate,
                sampleOffer.HasDiscount,
                sampleOffer.IsProvisioned,
                sampleOffer.DeferralStatus,
                sampleOffer.ContractPeriod);

            offer.InstallmentAmount.Should().Be(100000);
            offer.TotalShortBalance.Should().Be(1200000);
            offer.TotalLongBalance.Should().Be(0);
            
        }

        [Fact]
        [Trait("Categoria", "Diferimento")]
        public void ShouldCreateShortTermDeferralOfferWithRoundedInstallmentValue()
        {
            var sampleOffer = DeferralOfferBuilder.New()
                                                  .WithTotalBalance(1300000)
                                                  .WithNumberOfInstallments(12)
                                                  .Build();

            var offer = new DeferralOffer(sampleOffer.Id,
                sampleOffer.CycleDate,
                sampleOffer.ServiceCode,
                sampleOffer.OfferCode,
                sampleOffer.CustomerCode,
                sampleOffer.OrderNumber,
                sampleOffer.ProviderStoreAcronym,              
                sampleOffer.InvoiceNumber,
                sampleOffer.StoreAcronym,
                sampleOffer.BillingStateOrProvince,
                sampleOffer.PaymentMethod,
                sampleOffer.ServiceType,
                sampleOffer.TotalBalance,
                sampleOffer.NumberOfInstallments,
                sampleOffer.DeferralCreationDate,
                sampleOffer.PurchaseDate,
                sampleOffer.LastUpdatedDate,
                sampleOffer.HasDiscount,
                sampleOffer.IsProvisioned,
                sampleOffer.DeferralStatus,
                sampleOffer.ContractPeriod);

            offer.InstallmentAmount.Should().Be(108333.33);
            //TODO TEST
            //offer.TotalBalance.Should().Be(1299999.96);
            //offer.TotalShortBalance.Should().Be(1299999.96);
            offer.TotalLongBalance.Should().Be(0);

        }

        [Fact]
        [Trait("Categoria", "Diferimento")]
        public void ShouldCreateLongTermDeferralOfferWithNotIntegerValueOnBalance()
        {
            var sampleOffer = DeferralOfferBuilder.New()
                                                  .WithTotalBalance(23155)
                                                  .WithNumberOfInstallments(24)
                                                  .Build();

            var offer = new DeferralOffer(sampleOffer.Id,
                sampleOffer.CycleDate,
                sampleOffer.ServiceCode,
                sampleOffer.OfferCode,
                sampleOffer.CustomerCode,
                sampleOffer.OrderNumber,
                sampleOffer.ProviderStoreAcronym,               
                sampleOffer.InvoiceNumber,
                sampleOffer.StoreAcronym,
                sampleOffer.BillingStateOrProvince,
                sampleOffer.PaymentMethod,
                sampleOffer.ServiceType,
                sampleOffer.TotalBalance,
                sampleOffer.NumberOfInstallments,
                sampleOffer.DeferralCreationDate,
                sampleOffer.PurchaseDate,
                sampleOffer.LastUpdatedDate,
                sampleOffer.HasDiscount,
                sampleOffer.IsProvisioned,
                sampleOffer.DeferralStatus,
                sampleOffer.ContractPeriod);

            offer.InstallmentAmount.Should().Be(964.79);
            offer.TotalShortBalance.Should().Be(11577.48);

        }

        [Fact]
        [Trait("Categoria", "Diferimento")]
        public void ShouldCreateLongTermDeferralOfferWithNotIntegerValueOnBalanceAndNot24Installments()
        {
            var sampleOffer = DeferralOfferBuilder.New()
                                                  .WithTotalBalance(23155)
                                                  .WithNumberOfInstallments(15)
                                                  .Build();

            var offer = new DeferralOffer(sampleOffer.Id,
                sampleOffer.CycleDate,
                sampleOffer.ServiceCode,
                sampleOffer.OfferCode,
                sampleOffer.CustomerCode,
                sampleOffer.OrderNumber,
                sampleOffer.ProviderStoreAcronym,               
                sampleOffer.InvoiceNumber,
                sampleOffer.StoreAcronym,
                sampleOffer.BillingStateOrProvince,
                sampleOffer.PaymentMethod,
                sampleOffer.ServiceType,
                sampleOffer.TotalBalance,
                sampleOffer.NumberOfInstallments,
                sampleOffer.DeferralCreationDate,
                sampleOffer.PurchaseDate,
                sampleOffer.LastUpdatedDate,
                sampleOffer.HasDiscount,
                sampleOffer.IsProvisioned,
                sampleOffer.DeferralStatus,
                sampleOffer.ContractPeriod);

            offer.TotalShortBalance.Should().Be(offer.InstallmentAmount * 12);
            offer.TotalShortBalance.Should().BeGreaterThan(offer.TotalLongBalance);
            offer.TotalLongBalance.Should().Be(offer.InstallmentAmount * 3);

        }

    }
}
