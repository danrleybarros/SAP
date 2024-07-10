using Gcsb.Connect.SAP.Tests.Builders.JSDN;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.JSDN
{
    public class PaymentFeedDocDomainTests
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreatPaymentFeedDocDomain()
        {
            var model = PaymentFeedDocBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #region Tests With Null And Empty 

        [Fact]
        [Trait("Action", "Create")]
        public void NullOrEmptyShouldCreatIdHeader()
        {
            var model = PaymentFeedDocBuilder.New().WithIdFile(default(Guid)).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithDescription(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithDescription(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithVersionId(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithVersionId(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithEntityId(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithEntityId(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithMerchantId(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithMerchantId(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithUserId(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithUserId(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithTypeOperation(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithTypeOperation(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        
        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithProcessCode(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithProcessCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithOrderId(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithOrderId(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        
        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNCreateWithCardPan(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithCardPan(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        
        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithCardExpirationDate(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithCardExpirationDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        
        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithCurrency(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithCurrency(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        
        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithOriginIPAddress(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithOriginIPAddress(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        
        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithDateTimeSIA(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithDateTimeSIA(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        
        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithDateTimePayment(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithDateTimePayment(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithAuthorizationID(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithAuthorizationID(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithCustomerEmail(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithCustomerEmail(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithMerchantSession(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithMerchantSession(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithDataPrint(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithDataPrint(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithUrlPuce(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithUrlPuce(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithUrlAuthPath(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithUrlAuthPath(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithAcquirerEntity(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithAcquirerEntity(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithPlanType(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithPlanType(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithAcquirerTransactionID(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithAcquirerTransactionID(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithCardIssuer(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithCardIssuer(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithCardType(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithCardType(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithServiceId(int? valor)
        {
            var model = PaymentFeedDocBuilder.New().WithServiceId(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithMerchantCurrency(int? valor)
        {
            var model = PaymentFeedDocBuilder.New().WithMerchantCurrency(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithSIAOperationNumber(int? valor)
        {
            var model = PaymentFeedDocBuilder.New().WithSIAOperationNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithAlternativeCurrency(int? valor)
        {
            var model = PaymentFeedDocBuilder.New().WithAlternativeCurrency(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithBatchId(int? valor)
        {
            var model = PaymentFeedDocBuilder.New().WithBatchID(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithInstallmentsNumber(int? valor)
        {
            var model = PaymentFeedDocBuilder.New().WithInstallmentsNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithGracePeriod(int? valor)
        {
            var model = PaymentFeedDocBuilder.New().WithGracePeriod(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithBankIdentificationNumber(int? valor)
        {
            var model = PaymentFeedDocBuilder.New().WithBankIdentificationNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithCardIssuerCountry(int? valor)
        {
            var model = PaymentFeedDocBuilder.New().WithCardIssuerCountry(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithCardBrand(int? valor)
        {
            var model = PaymentFeedDocBuilder.New().WithCardBrand(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithCardCategory(int? valor)
        {
            var model = PaymentFeedDocBuilder.New().WithCardCategory(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithTransactionAmount(decimal? value)
        {
            var model = PaymentFeedDocBuilder.New().WithTransactionAmount(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithAlternativeAmount(decimal? value)
        {
            var model = PaymentFeedDocBuilder.New().WithAlternativeAmount(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithInterestAmount(decimal? value)
        {
            var model = PaymentFeedDocBuilder.New().WithInterestAmount(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldCreateWithInvoiceNumberJsdn(string valor)
        {
            var model = PaymentFeedDocBuilder.New().WithInvoiceNumberJsdn(valor).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion
    }
}
