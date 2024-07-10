using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.GF.Nfe;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.ReprocessingReturnNFe
{
    public class ReprocessingReturnNFeRequest
    {
        public Guid BillFeedFileId { get; set; }
        public List<NfeFiles> NfeFiles { get; set; }

        public ReprocessingReturnNFeRequest(Guid billFeedFileId, List<NfeFiles> nfeFiles)
        {
            BillFeedFileId = billFeedFileId;
            NfeFiles = nfeFiles;
        }
    }
}
