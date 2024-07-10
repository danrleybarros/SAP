using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.Files.ReprocessingReturnNFe
{
    public class ReprocessingReturnNFeRequest
    {
        public Guid BillFeedFileId { get; set; }
        public List<NFeFile> Files { get; set; }
    }

    public class NFeFile
    {
        public StoreType Store { get; set; }
        public string FileName { get; set; }
    }
}
