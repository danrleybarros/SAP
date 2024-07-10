using Gcsb.Connect.SAP.Application.Repositories;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook.RequestHandlers
{
    public class GetFileNameHandler : Handler
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public GetFileNameHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(AxiliaryBookRequest request)
        {
            request.AddProcessingLog("Creating file name - Axiliary Book");

            request.FileName = request.LaunchItems.First().FileName;

            fileWriteOnlyRepository.UpdateFileName(request.File.Id,request.FileName);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
