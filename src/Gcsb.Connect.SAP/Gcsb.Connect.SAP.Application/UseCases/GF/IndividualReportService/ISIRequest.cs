using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService
{
    public class ISIRequest
    {
        public Guid IdNFFile { get; private set; }

        public ISIRequest(Guid idNFFile)
        {
            this.IdNFFile = idNFFile;
        }
    }
}
