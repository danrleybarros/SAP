using Gcsb.Connect.SAP.Tests.Builders.ARR;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.ARR
{
    public class IdentificationRegisterDomainTest
    {
        #region Tests With Constants

        [Theory]
        [Trait("Action", "None")]
        [InlineData("ID", "ARR55TB29")]
        public void ShouldMatchConstantsIdentificationRegisterDomain(string typeLine, string fileName)
        {
            var model = IdentificationRegisterBuilder.New().Build();

            fileName += $"{DateTime.Now.ToString("yy")}0001.TXT";

            Assert.Equal(model.TypeLine, typeLine);
            Assert.Equal(model.FileName, fileName);
        }

        #endregion

        #region Tests With Null And Empty

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithSequentialFile(string valor)
        {
            var model = IdentificationRegisterBuilder.New().WithSequentialFile(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithGenerationDate(string valor)
        {
            var model = IdentificationRegisterBuilder.New().WithGenerationDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithGenerationHour(string valor)
        {
            var model = IdentificationRegisterBuilder.New().WithGenerationHour(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion

        #region Tests With MaxLenght

        [Theory]
        [Trait("Action", "None")]
        [InlineData("00001")]
        public void MaxLenght4SequentialFile(string valor)
        {
            var model = IdentificationRegisterBuilder.New().WithSequentialFile(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("010120199")]
        public void MaxLenght8GenerationDate(string valor)
        {
            var model = IdentificationRegisterBuilder.New().WithGenerationDate(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("1545000")]
        public void MaxLenght6GenerationHour(string valor)
        {
            var model = IdentificationRegisterBuilder.New().WithGenerationHour(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        #endregion
    }
}
