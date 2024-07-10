using System;
using System.Collections.Generic;
using System.Text;
using Gcsb.Connect.SAP.Domain.Upload;
using Gcsb.Connect.SAP.Domain.Upload.Enum;

namespace Gcsb.Connect.SAP.Application.UseCases.Files
{
    public class UploadStatusOutput
    {
        public List<Domain.Upload.Upload> statusTypes { get; set; }
        public bool HasExecuted { get; private set; }

        public UploadStatusOutput(List<Domain.Upload.Upload> statusTypes, bool hasExecuted)
        {
            this.statusTypes = statusTypes;
            HasExecuted = hasExecuted;
        }

    }
}
