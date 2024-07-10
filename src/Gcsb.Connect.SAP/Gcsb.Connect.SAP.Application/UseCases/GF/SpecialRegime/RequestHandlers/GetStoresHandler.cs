using Gcsb.Connect.SAP.Application.Repositories.JSDN;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime.RequestHandlers
{
    public class GetStoresHandler : Handler
    {
        private readonly IJsdnStoreService jsdnStoreService;
        private readonly string[] stores = new string[] { "telerese", "cloudco", "IOTCo" };

        public GetStoresHandler(IJsdnStoreService jsdnStoreService)
        {
            this.jsdnStoreService = jsdnStoreService;
        }

        public override void ProcessRequest(SpecialRegimeRequest request)
        {
            request.Stores.Add(jsdnStoreService.GetStores(stores[0]));
            request.Stores.Add(jsdnStoreService.GetStores(stores[1]));
            request.Stores.Add(jsdnStoreService.GetStores(stores[2]));


            sucessor?.ProcessRequest(request);
        }
    }
}
