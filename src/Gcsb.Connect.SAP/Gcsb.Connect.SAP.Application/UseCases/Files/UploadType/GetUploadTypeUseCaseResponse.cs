using Gcsb.Connect.SAP.Domain.UploadTypeDto;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.UploadType
{
    public class GetUploadTypeUseCaseResponse
    {
        public List<UploadTypeDto> UploadTypes { get; set; }
        public bool HasExecuted { get; private set; }

        public GetUploadTypeUseCaseResponse(List<UploadTypeDto> uploadTypes, bool hasExecuted)
        {
            this.UploadTypes = uploadTypes;
            this.HasExecuted = hasExecuted;
        }
    }
} 
