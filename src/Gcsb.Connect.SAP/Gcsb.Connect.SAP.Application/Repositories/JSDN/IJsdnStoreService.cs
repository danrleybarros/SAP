using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Application.Repositories.JSDN
{
    public interface IJsdnStoreService
    {
        JsdnStore GetStores(string storeAcronym);
    }
}
