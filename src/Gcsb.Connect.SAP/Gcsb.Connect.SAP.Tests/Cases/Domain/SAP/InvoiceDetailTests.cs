using Gcsb.Connect.SAP.Tests.Builders;
using System;
using Xunit;


namespace Gcsb.Connect.SAP.Tests.Cases.Domain
{
    public class InvoiceDetailTests
    {
        #region Valid instance
        [Fact]
        [Trait("Action", "Create")]
        public void InvoiceDetailShouldCreate()
        {
            var model = InvoiceDetailBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Tests With Invalid Formats

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999)]
        public void InvoiceDetailWrongAmount(int value)
        {
            var model = InvoiceDetailBuilder.New().WithAmount(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999.999)]
        [InlineData(999999.9)]
        [InlineData(.00)]
        [InlineData(100000000000000000.01)]
        public void InvoiceDetailWrongVendorPrice(decimal value)
        {
            var model = InvoiceDetailBuilder.New().WithVendorPrice(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999.999)]
        [InlineData(999999.9)]
        [InlineData(.00)]
        [InlineData(100000000000000000.01)]
        public void InvoiceDetailWrongPISTax(decimal value)
        {
            var model = InvoiceDetailBuilder.New().WithPISTax(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999.999)]
        [InlineData(999999.9)]
        [InlineData(.00)]
        [InlineData(100000000000000000.01)]
        public void InvoiceDetailWrongCOFINSTax(decimal value)
        {
            var model = InvoiceDetailBuilder.New().WithCOFINSTax(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999.999)]
        [InlineData(999999.9)]
        [InlineData(.00)]
        [InlineData(100000000000000000.01)]
        public void InvoiceDetailWrongISSTax(decimal value)
        {
            var model = InvoiceDetailBuilder.New().WithCOFINSTax(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999.999)]
        [InlineData(999999.9)]
        [InlineData(.00)]
        [InlineData(100000000000000000.01)]
        public void InvoiceDetailWrongICMSTax(decimal value)
        {
            var model = InvoiceDetailBuilder.New().WithICMSTax(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999.999)]
        [InlineData(999999.9)]
        [InlineData(.00)]
        [InlineData(100000000000000000.01)]
        public void InvoiceDetailWrongChargeback(decimal value)
        {
            var model = InvoiceDetailBuilder.New().WithChargeback(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999999)]
        public void InvoiceDetailWrongOrigin(int value)
        {
            var model = InvoiceDetailBuilder.New().WithOrigin(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region Tests With Null And Empty
        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithMaterialCodeNullOrEmpty(string value)
        {
            var model = InvoiceDetailBuilder.New().WithMaterialCode(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]        
        [InlineData(null)]
        public void ShouldNotCreateWithAmountNullOrEmpty(int value)
        {
            var model = InvoiceDetailBuilder.New().WithAmount(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(null)]
        public void ShouldNotCreateWithVendorPriceNullOrEmpty(decimal value)
        {
            var model = InvoiceDetailBuilder.New().WithVendorPrice(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void ShouldCreateWithPISTaxNull(decimal? value)
        {
            var model = InvoiceDetailBuilder.New().WithPISTax(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void ShouldCreateWithCOFINSTaxNull(decimal? value)
        {
            var model = InvoiceDetailBuilder.New().WithCOFINSTax(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void ShouldCreateWithISSTaxNull(decimal? value)
        {
            var model = InvoiceDetailBuilder.New().WithISSTax(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(null)]
        public void ShouldNotCreateWithICMSTaxNullOrEmpty(decimal value)
        {
            var model = InvoiceDetailBuilder.New().WithICMSTax(value).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void ShouldCreateWithChargebackNull(decimal? value)
        {
            var model = InvoiceDetailBuilder.New().WithISSTax(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void ShouldCreateWithActivationDateNull(DateTime? value)
        {
            var model = InvoiceDetailBuilder.New().WithActivationDate(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void ShouldCreateWithDateOfInactivationNull(DateTime? value)
        {
            var model = InvoiceDetailBuilder.New().WithDateOfInactivation(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "Create")]
        [InlineData(null)]
        public void ShouldCreateWithOriginNull(int? value)
        {
            var model = InvoiceDetailBuilder.New().WithOrigin(value).Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }
        #endregion

        #region Tests With MaxLenght
        [Theory]
        [Trait("Action", "None")]
        [InlineData("Lorem ipsum dolor s")]
        public void MaxLenght18MaterialCode(string valor)
        {
            var model = InvoiceDetailBuilder.New().WithMaterialCode(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999)]
        public void MaxLenght5Amount(int valor)
        {
            var model = InvoiceDetailBuilder.New().WithAmount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData(999999999)]
        public void MaxLenght8Origin(int valor)
        {
            var model = InvoiceDetailBuilder.New().WithAmount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
        #endregion

        #region Format DateTime SAP Tests
        [Fact]
        public void FormatDateTimeActivationDateSAP()
        {
            var datetime = new DateTime(2019, 12, 25);
            var model = InvoiceDetailBuilder.New().WithActivationDate(datetime).Build();
            Assert.Equal("25122019", model.ActivationDateSAP());
        }

        [Fact]
        public void FormatDateTimeDateOfInactivationSAP()
        {
            var datetime = new DateTime(2019, 12, 25);
            var model = InvoiceDetailBuilder.New().WithDateOfInactivation(datetime).Build();
            Assert.Equal("25122019", model.DateOfInactivationSAP());
        }

        #endregion

        #region Tests With Constants
        [Theory]
        [Trait("Action", "None")]
        [InlineData("D3")]
        public void ShouldMatchConstantsInvoiceDetailDomain(string orderItem)
        {
            var model = InvoiceDetailBuilder.New().Build();
            Assert.True(model.OrderItem == orderItem);
        }
        #endregion
    }
}
