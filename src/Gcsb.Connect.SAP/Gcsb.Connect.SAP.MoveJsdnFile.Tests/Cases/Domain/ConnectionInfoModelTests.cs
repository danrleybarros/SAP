using Gcsb.Connect.SAP.Tests.Builders;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain
{
    public class ConnectionInfoModelTests
    {
        public const string SshKeyRelativePath = "SFTPMock\\mykeys\\ssh_host_rsa_key.key";

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreateConnectionInfo()
        {
            var model = ConnectionInformationBuilder.New().Builder();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateConnectionInfoWithNullOrEmptyHost(string value)
        {
            var model = ConnectionInformationBuilder.New().WithHost(value).Builder();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateConnectionInfoWithNullOrEmptyUser(string value)
        {
            var model = ConnectionInformationBuilder.New().WithUser(value).Builder();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateConnectionInfoWithNullOrEmptyPassword(string value)
        {
            var model = ConnectionInformationBuilder.New().WithPassword(value).Builder();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }

        [Theory]
        [Trait("Action", "None")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateConnectionInfoWithNullOrEmptySshKeyFile(string value)
        {
            var model = ConnectionInformationBuilder.New().WithSSHKeyFile(value).Builder();
            Assert.True(Util.ValidateModel(model).Count > 0);
        }
    }
}
