using System.Linq;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport.RequestHandlers
{
    public class GetStoresHandler : Handler
    {
        private readonly IJsdnStoreService jsdnStoreService;
        private readonly string[] stores = new string[] { "telerese", "cloudco", "IOTCo" };

        public GetStoresHandler(IJsdnStoreService jsdnStoreService)
        {
            this.jsdnStoreService = jsdnStoreService;
        }

        public override void ProcessRequest(IndividualReportRequestNF request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Getting stores"));

            stores.ToList().ForEach(store =>
            {
                var jsdnStore = jsdnStoreService.GetStores(store);

                if(jsdnStore != null)
                    request.Stores.Add(jsdnStore);
            });          
         
            sucessor?.ProcessRequest(request);
        }
    }
}
