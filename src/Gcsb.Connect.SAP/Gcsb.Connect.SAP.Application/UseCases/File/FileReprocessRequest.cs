using System;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{ 
    public class FileReprocessRequest
    {
        public Guid FileId { get; private set; }


        public FileReprocessRequest(Guid fileId)
        {
            this.FileId = fileId;
        }       
    }
}
