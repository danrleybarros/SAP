using FluentAssertions;
using Gcsb.Connect.SAP.Tests.Builders;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain
{
    public class BillFeedDocDomainTests
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateBillFeedDocDomain()
        {
            var model = BillFeedDocBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateMarketplace(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMarketplace(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateResellerName(string valor)
        {
            var model = BillFeedDocBuilder.New().WithResellerName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateResellerContactName(string valor)
        {
            var model = BillFeedDocBuilder.New().WithResellerContactName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateResellerEmailAddress(string valor)
        {
            var model = BillFeedDocBuilder.New().WithResellerEmailAddress(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateResellerPhoneNumber(string valor)
        {
            var model = BillFeedDocBuilder.New().WithResellerPhoneNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateOrderId(string valor)
        {
            var model = BillFeedDocBuilder.New().WithOrderId(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Fact]
        [Trait("Action", "None")]
        public void NullOrEmptyShouldCreateSubscriptionId()
        {
            var model = BillFeedDocBuilder.New().WithSubscriptionId(default(Guid)).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateActivity(string valor)
        {
            var model = BillFeedDocBuilder.New().WithActivity(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateServiceType(string valor)
        {
            var model = BillFeedDocBuilder.New().WithServiceType(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateOrderCreateionDate(DateTime? valor)
        {
            var model = BillFeedDocBuilder.New().WithOrderCreationDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreatePurchaseDate(DateTime? valor)
        {
            var model = BillFeedDocBuilder.New().WithPurchaseDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateActivationDate(DateTime? valor)
        {
            var model = BillFeedDocBuilder.New().WithActivationDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateSubscriptionType(string valor)
        {
            var model = BillFeedDocBuilder.New().WithSubscriptionType(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTermStartDate(DateTime? valor)
        {
            var model = BillFeedDocBuilder.New().WithTermStartDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTermEndDate(DateTime? valor)
        {
            var model = BillFeedDocBuilder.New().WithTermEndDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTermDuration(string valor)
        {
            var model = BillFeedDocBuilder.New().WithTermDuration(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateNextRenewalDate(DateTime? valor)
        {
            var model = BillFeedDocBuilder.New().WithNextRenewalDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateServiceCancellationDate(string valor)
        {
            var model = BillFeedDocBuilder.New().WithServiceCancellationDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillFrom(DateTime? valor)
        {
            var model = BillFeedDocBuilder.New().WithBillFrom(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillTo(DateTime? valor)
        {
            var model = BillFeedDocBuilder.New().WithBillTo(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateCompanyAcronym(string valor)
        {
            var model = BillFeedDocBuilder.New().WithCompanyAcronym(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateAccountCreateionDate(DateTime? valor)
        {
            var model = BillFeedDocBuilder.New().WithAccountCreationDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateFirstName(string valor)
        {
            var model = BillFeedDocBuilder.New().WithFirstName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateLastName(string valor)
        {
            var model = BillFeedDocBuilder.New().WithLastName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateCustomerEmailAddress(string valor)
        {
            var model = BillFeedDocBuilder.New().WithCustomerEmailAddress(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateCustomerPhoneNumber(string valor)
        {
            var model = BillFeedDocBuilder.New().WithCustomerPhoneNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillingStreet(string valor)
        {
            var model = BillFeedDocBuilder.New().WithBillingStreet(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillingNumber(string valor)
        {
            var model = BillFeedDocBuilder.New().WithBillingNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillingComplement(string valor)
        {
            var model = BillFeedDocBuilder.New().WithBillingComplement(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillingNeighbourhood(string valor)
        {
            var model = BillFeedDocBuilder.New().WithBillingNeighbourhood(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillingCity(string valor)
        {
            var model = BillFeedDocBuilder.New().WithBillingCity(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillingStateOrProvince(string valor)
        {
            var model = BillFeedDocBuilder.New().WithBillingStateOrProvince(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillingZIPcode(string valor)
        {
            var model = BillFeedDocBuilder.New().WithBillingZIPcode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillingCountry(string valor)
        {
            var model = BillFeedDocBuilder.New().WithBillingCountry(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillingCountryCode(string valor)
        {
            var model = BillFeedDocBuilder.New().WithBillingCountryCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillingPhoneNumber(string valor)
        {
            var model = BillFeedDocBuilder.New().WithBillingPhoneNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMailingStreet(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMailingStreet(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMailingNumber(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMailingNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMailingComplement(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMailingComplement(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMailingNeighbourhood(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMailingNeighbourhood(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMailingCity(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMailingCity(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMailingStateOrProvince(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMailingStateOrProvince(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMailingZIPcode(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMailingZIPcode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMailingCountry(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMailingCountry(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMailingCountryCode(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMailingCountryCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMailingPhoneNumber(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMailingPhoneNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateCustomerCNPJ(string valor)
        {
            var model = BillFeedDocBuilder.New().WithCustomerCNPJ(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateCustomerStateRegistration(string valor)
        {
            var model = BillFeedDocBuilder.New().WithCustomerStateRegistration(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateServiceCode(string valor)
        {
            var model = BillFeedDocBuilder.New().WithServiceCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateDueDate(DateTime? valor)
        {
            var model = BillFeedDocBuilder.New().WithDueDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateStoreCode(string valor)
        {
            var model = BillFeedDocBuilder.New().WithStoreCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMarketplaceCity(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMarketplaceCity(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateMarketplaceState(string valor)
        {
            var model = BillFeedDocBuilder.New().WithMarketplaceState(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateUserAccountStatus(string valor)
        {
            var model = BillFeedDocBuilder.New().WithUserAccountStatus(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreatePremeditateddefaulter(string valor)
        {
            var model = BillFeedDocBuilder.New().WithPremeditateddefaulter(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateServiceName(string valor)
        {
            var model = BillFeedDocBuilder.New().WithServiceName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateOfferName(string valor)
        {
            var model = BillFeedDocBuilder.New().WithOfferName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateOfferCode(string valor)
        {
            var model = BillFeedDocBuilder.New().WithOfferCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateSalesReferenceCode(string valor)
        {
            var model = BillFeedDocBuilder.New().WithSalesReferenceCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateUnitOfMeasure(string valor)
        {
            var model = BillFeedDocBuilder.New().WithUnitOfMeasure(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateQty(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithQty(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateProRateScale(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithProRateScale(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateRetailUnitPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithRetailUnitPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateProRatedRetailPriceUnitPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithProRatedRetailPriceUnitPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateGrossRetailPrice(decimal? valor)
        {
            var model = BillFeedDocBuilder.New().WithGrossRetailPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateRetailPriceDiscount(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithRetailPriceDiscount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateProRatedRetailUnitDiscountedPriceAmount(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithProRatedRetailUnitDiscountedPriceAmount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTotalRetailPriceDiscountAmount(decimal? valor)
        {
            var model = BillFeedDocBuilder.New().WithTotalRetailPriceDiscountAmount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTotalRetailPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithTotalRetailPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTaxOnTotalRetailPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithTaxOnTotalRetailPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateGrandTotalRetailPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithGrandTotalRetailPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreatePromotionCode(string valor)
        {
            var model = BillFeedDocBuilder.New().WithPromotionCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreatePromotionDuration(string valor)
        {
            var model = BillFeedDocBuilder.New().WithPromotionDuration(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWholesaleUnitPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithWholesaleUnitPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateProRatedWholesaleUnitPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithProRatedWholesaleUnitPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateCustomerTransactionCurrency(string valor)
        {
            var model = BillFeedDocBuilder.New().WithCustomerTransactionCurrency(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateVendorCurrency(string valor)
        {
            var model = BillFeedDocBuilder.New().WithVendorCurrency(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateGrossWholesalePrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithGrossWholesalePrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWholesalePriceDiscount(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithWholesalePriceDiscount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateProRatedWholesaleUnitDiscountedPriceAmount(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithProRatedWholesaleUnitDiscountedPriceAmount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTotalWholesalePriceDiscountAmount(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithTotalWholesalePriceDiscountAmount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTotalWholesalePrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithTotalWholesalePrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTaxOnTotalWholesalePrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithTaxOnTotalWholesalePrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateGrandTotalWholesalePrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithGrandTotalWholesalePrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateVendorName(string valor)
        {
            var model = BillFeedDocBuilder.New().WithVendorName(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateVendorUnitPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithVendorUnitPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateProRatedVendorUnitPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithProRatedVendorUnitPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTotalVendorPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithTotalVendorPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTaxOnTotalVendorPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithTaxOnTotalVendorPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateGrandTotalVendorPrice(double? valor)
        {
            var model = BillFeedDocBuilder.New().WithGrandTotalVendorPrice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateBillingCycle(string valor)
        {
            var model = BillFeedDocBuilder.New().WithBillingCycle(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateProrateType(string valor)
        {
            var model = BillFeedDocBuilder.New().WithProrateType(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateProrateOnCancellation(string valor)
        {
            var model = BillFeedDocBuilder.New().WithProrateOnCancellation(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateUsageAttributes(string valor)
        {
            var model = BillFeedDocBuilder.New().WithUsageAttributes(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreatePaymentMethod(string valor)
        {
            var model = BillFeedDocBuilder.New().WithPaymentMethod(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreatePaymentStatus(string valor)
        {
            var model = BillFeedDocBuilder.New().WithPaymentStatus(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateRefundType(string valor)
        {
            var model = BillFeedDocBuilder.New().WithRefundType(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateRefundAmount(string valor)
        {
            var model = BillFeedDocBuilder.New().WithRefundAmount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateInvoiceNumber(string valor)
        {
            var model = BillFeedDocBuilder.New().WithInvoiceNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateResourceId(string valor)
        {
            var model = BillFeedDocBuilder.New().WithResourceId(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateChargeType(string valor)
        {
            var model = BillFeedDocBuilder.New().WithChargeType(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateIndividualInvoice(string valor)
        {
            var model = BillFeedDocBuilder.New().WithIndividualInvoice(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTaxRateISS(decimal? valor)
        {
            var model = BillFeedDocBuilder.New().WithTaxRateISS(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTotalTaxISS(decimal? valor)
        {
            var model = BillFeedDocBuilder.New().WithTotalTaxISS(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTaxRateCOFINS(decimal? valor)
        {
            var model = BillFeedDocBuilder.New().WithTaxRateCOFINS(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTotalTaxCOFINS(decimal? valor)
        {
            var model = BillFeedDocBuilder.New().WithTotalTaxCOFINS(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTaxRatePIS(decimal? valor)
        {
            var model = BillFeedDocBuilder.New().WithTaxRatePIS(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateTotalTaxPIS(decimal? valor)
        {
            var model = BillFeedDocBuilder.New().WithTotalTaxPIS(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [InlineData("telerese", "TBRA")]
        [InlineData("cloudco", "TLF2")]
        public void ShouldGetCompanyCodeAccordingStore(string storeAcronym, string companyCode)
        {
            var model = BillFeedDocBuilder.New().WithStoreAcronym(storeAcronym).Build();

            model.CompanyCode.Should().Be(companyCode);
        }


        [Theory]
        [Trait("Action", "None")]
        [InlineData("36.282.030/5764-86", "Cloud Marketlace", "77434", "1.03", "002/2018", "Descrição acima: Processamento, armazenamento ou hospedagem de dados")]
        public void ShouldConstrainsTests(string cnpjmarketplace, string companynamemarketplace, string municipalTaxpayerRegistration, string cityServiceCode, string specialprocedurenumber, string cityhallservicedescription)
        {
            var model = BillFeedDocBuilder.New().Build();
            Assert.True(model.CnpjMarketPlace == cnpjmarketplace);
            Assert.True(model.CompanyNameMarketPlace == companynamemarketplace);
            Assert.True(model.MunicipalTaxpayerRegistration == municipalTaxpayerRegistration);
            Assert.True(model.CityServiceCode == cityServiceCode);
            Assert.True(model.SpecialProcedureNumber == specialprocedurenumber);
            Assert.True(model.CityHallServiceDescription == cityhallservicedescription);
        }
    }
}
