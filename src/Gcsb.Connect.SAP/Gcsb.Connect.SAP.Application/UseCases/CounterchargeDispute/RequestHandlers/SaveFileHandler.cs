using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class SaveFileHandler : Handler
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Save file on database");

            request.Files.ForEach(file => fileWriteOnlyRepository.Add(file));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
