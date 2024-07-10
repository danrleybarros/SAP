using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.Upload.Handlers;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Upload
{
    public class UploadUseCase : IUploadUseCase
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly RegisterUploadHandler registerUploadHandler;        

        public UploadUseCase(
            ILogWriteOnlyRepository logWriteOnlyRepository, 
            RegisterUploadHandler registerUploadHandler, 
            CleanDataHandler cleanDataHandler, 
            UploadFileHandler uploadFileHandler,
            ReturnNFHandler returnNFHandler,
            InsertQueueHandler insertQueueHandler)
        {
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.registerUploadHandler = registerUploadHandler;
            registerUploadHandler.SetSucessor(cleanDataHandler);
            cleanDataHandler.SetSucessor(uploadFileHandler);
            uploadFileHandler.SetSucessor(returnNFHandler);
            returnNFHandler.SetSucessor(insertQueueHandler);
        }
        public async Task Execute(UploadUseCaseRequest request)
        {
            try
            {                
                registerUploadHandler.ProcessRequest(request);
            }
            catch (Exception e)
            {
                request.AddExceptionLog(e.Message, e.StackTrace);            
            }           
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }

        public object Execute(string tenantID)
        {
            throw new NotImplementedException();
        }
    }
}
