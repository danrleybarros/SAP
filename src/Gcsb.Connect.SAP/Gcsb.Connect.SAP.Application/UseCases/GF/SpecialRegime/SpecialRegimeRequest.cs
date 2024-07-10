using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime
{
    public class SpecialRegimeRequest
    {
        private const string service = "SpecialRegime";

        public Guid FileIdBillFeed { get; private set; }
        public List<ServiceInvoice> Services { get; set; }
        public List<JsdnStore> Stores { get; set; }
        public List<Domain.GF.SpecialRegime> SpecialRegimes { get; set; }
        public List<Messaging.Messages.File.File> Files { get; set; }
        public Dictionary<StoreType, Guid> RegimeFiles { get; set; }
        public List<Log> Logs { get; private set; }
        public bool OutputSuccessfully { get; set; }
        public string Service { get => service; }

        public SpecialRegimeRequest(Guid fileIdBillFeed)
        {
            FileIdBillFeed = fileIdBillFeed;
            Files = new List<Messaging.Messages.File.File>();
            Logs = new List<Log>();
            RegimeFiles = new Dictionary<StoreType, Guid>();
            Stores = new List<JsdnStore>();
        }
    }
}
