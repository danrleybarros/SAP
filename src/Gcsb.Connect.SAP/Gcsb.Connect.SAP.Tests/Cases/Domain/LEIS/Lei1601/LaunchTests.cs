using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.LEIS.Lei1601
{
    [Trait("Action", "Create")]
    public class LaunchTests
    {
        [Fact]
        public void ShouldCreateLaunchDomainSucess()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().Build();
            model.SetParticipantCode("0003012393");
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithEmpsCod()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithEmpsCod("").Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithFiliCod()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithFiliCod("").Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithCatgCode()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithCatgCode("").Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithCadgCod()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithCadgCod("").Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithCatgCodIt()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithCatgCodIt("").Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithCadgCodIt()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithCadgCodIt("").Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithOipeTotVs()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithOipeTotVs("").Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithOipeTotIss()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithOipeTotIss(-1).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithOipeTotOutros()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithOipeTotOutros("").Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithBancoOrigPgto()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithBancoOrigPgto("").Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithSistemaOrigem()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithSistemaOrigem("").Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Fact]
        public void DontShouldCreateLaunchDomainWithFileId()
        {
            var model = Builders.LEIS.Lei1601.LaunchBuilder.New().WithFileId(Guid.Empty).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
    }
}
