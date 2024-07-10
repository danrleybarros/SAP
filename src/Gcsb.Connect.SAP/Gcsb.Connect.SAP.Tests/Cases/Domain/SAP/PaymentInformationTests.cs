using Xunit;
using System;
using Gcsb.Connect.SAP.Tests.Builders;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain
{
    public class PaymentInformationTests
    {
        #region Test Should Create

        [Fact]
        [Trait("Action", "Create")]
        public void PaymenteInformationShouldCreate()
        {
            var model = PaymentInformationBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Tests With Invalid Formats
        [Theory]
        [Trait("Action", "None")]
        [InlineData("123456*****1234")]
        public void PaymenteInformationWrongCardNumber(string value)
        {
            var model = PaymentInformationBuilder.New().WithCardNumber(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region Tests With Null And Empty
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithOrderNumberNullOrEmpty(string value)
        {
            var model = PaymentInformationBuilder.New().WithOrderNumber(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateWithCardNumberNullOrEmpty(string value)
        {
            var model = PaymentInformationBuilder.New().WithCardNumber(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateWitNSUNullOrEmpty(string value)
        {
            var model = PaymentInformationBuilder.New().WithNSU(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateWitCardFlagNullOrEmpty(string value)
        {
            var model = PaymentInformationBuilder.New().WithNSU(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldCreateWitAdmGlobalPaymentNullOrEmpty(string value)
        {
            var model = PaymentInformationBuilder.New().WithAdmGlobalPayment(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWitAuthorizationCodeNullOrEmpty(string value)
        {
            var model = PaymentInformationBuilder.New().WithAuthorizationCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region Tests With MaxLenght
        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolor sit amet, con")]
        public void MaxLenght30OrderNumber(string valor)
        {
            var model = PaymentInformationBuilder.New().WithOrderNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolor")]
        public void MaxLenght16CardNumber(string valor)
        {
            var model = PaymentInformationBuilder.New().WithCardNumber(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum d")]
        public void MaxLenght12NSU(string valor)
        {
            var model = PaymentInformationBuilder.New().WithNSU(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolo")]
        public void MaxLenght15CardFlag(string valor)
        {
            var model = PaymentInformationBuilder.New().WithCardFlag(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lor")]
        public void MaxLenght2AdmGlobalPayment(string valor)
        {
            var model = PaymentInformationBuilder.New().WithAdmGlobalPayment(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum d")]
        public void MaxLenght12AuthorizationCode(string valor)
        {
            var model = PaymentInformationBuilder.New().WithAuthorizationCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem")]
        public void MaxLenght4Division(string valor)
        {
            var model = PaymentInformationBuilder.New().WithDivision(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region Format DateTime SAP Test
        [Fact]
        public void FormatDateTimeOrderDateSAP()
        {
            var datetime = new DateTime(2019, 12, 25);
            var model = PaymentInformationBuilder.New().WithOrderDate(datetime).Build();
            Assert.Equal("25122019", model.OrderDateSAP());
        }
        #endregion

        #region Tests With Constants
        [Theory]
        [Trait("Action", "None")]
        [InlineData("D2")]
        public void ShouldMatchConstantsPaymentInformationDomain(string orderCab)
        {
            var model = PaymentInformationBuilder.New().Build();
            Assert.True(model.OrderCab == orderCab);
        }
        #endregion   
    }
}