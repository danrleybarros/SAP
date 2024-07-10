using System;
using Gcsb.Connect.SAP.Application.UseCases.File.RequestHandlers;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{

    public class FileReprocessUseCase : IFileReprocessUseCase
    {
        private readonly IFileHandler fileHandler;

        public FileReprocessUseCase(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
        }

        public int Execute(FileReprocessRequest request)
        {       
            try
            {
                if (request == null)
                    throw new ArgumentNullException("request");

                fileHandler.FileReprocessRequest(request);

                return 1;

            }
            catch (Exception ex)
            {            
                throw ex;
            }

        }
    }
}
