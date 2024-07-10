using Gcsb.Connect.SAP.Tests.Builders.GF;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Domain.GF
{
    public class IndividualReportServiceTests
    {
        #region Create Test

        [Fact]
        [Trait("Action", "Create")]
        public void ShouldCreate()
        {
            var model = IndividualReportServiceBuilder.New().Build();
            Assert.True(Util.ValidateModel(model).Count == 0);
        }

        #endregion

        #region Tests With Constants

        [Theory]
        [Trait("Action", "None")]
        [InlineData("1.03", "Processamento,armaz. ou hosped. de dados, textos, imagens, videos, paginas eletronicas, apps e sist. de info., entre outros formatos e congeneres", "S", "P", "Vivo Plataforma Digital", "1.03")]
        public void ShouldMatchConstantsItemsDomain(string serviceCode, string serviceName, string serviceType, string revenueTypeIndicator, string digitalPlatform, string cslcCodLst)
        {
            var model = IndividualReportServiceBuilder.New().Build();

            Assert.Equal(serviceCode, model.ServiceCode);
            Assert.Equal(serviceName, model.ServiceName);
            Assert.Equal(serviceType, model.ServiceType);
            Assert.Equal(revenueTypeIndicator, model.RevenueTypeIndicator);
            Assert.Equal(digitalPlatform, model.DigitalPlatform);
            Assert.Equal(cslcCodLst, model.CslcCodLst);
        }

        #endregion
    }
}
