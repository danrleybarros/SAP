using System;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{
    public class LogRequest
    {
        public Guid FileId { get; private set; }


        public LogRequest(Guid fileId)
        {
            this.FileId = fileId;
        }
    }
}