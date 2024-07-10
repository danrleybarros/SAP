using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Tests.Builders.JSDN.Stores;
using Moq;

namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class StoresMock
    {
        public Mock<IJsdnStoreService> GetStoresMoq()
        {
            var moq = new Mock<IJsdnStoreService>();

            moq.Setup(s => s.GetStores(It.IsAny<string>()))
                .Returns<string>(store => JsdnStoreBuilder.New().WithStoreAcronym(store).WithStoreCnpj("72484999000100").WithAcronym(store).Build());

            return moq;
        }
    }
}
