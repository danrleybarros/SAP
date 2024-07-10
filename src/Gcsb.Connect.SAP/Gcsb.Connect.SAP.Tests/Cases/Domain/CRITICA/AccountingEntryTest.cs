using Gcsb.Connect.SAP.Tests.Builders.Critica;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.CRITICA
{
    public class AccountingEntryTest
    {
        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateIdentificationRegisterDomain()
        {
            var model = AccountingEntryBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithFinancialAccount(string valor)
        {
            var model = AccountingEntryBuilder.New().WithFinancialAccount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithAccountingEntryType(string valor)
        {
            var model = AccountingEntryBuilder.New().WithAccountingEntryType(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithAccountingAccount(string valor)
        {
            var model = AccountingEntryBuilder.New().WithAccountingAccount(valor).Build();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
    }
}
