using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{
    public class LogUseCase : ILogUseCase
    {
        private readonly ILogReadOnlyRepository logReadOnlyRepository;

        public LogUseCase(ILogReadOnlyRepository logReadOnlyRepository)
        {
            this.logReadOnlyRepository = logReadOnlyRepository;
        }
        public List<LogResult> Execute(LogRequest request)
        {
            try
            { 

                if (request == null)
                    throw new ArgumentNullException("Request is null.");

                List<Log> logs = (List<Log>)(logReadOnlyRepository.GetLogsByFileId(request.FileId)).Select(s => s).ToList();

                return new List<LogResult>(logs.Select(s => new LogResult(s))).ToList();
            }    
            catch 
            {

                throw;
            }
            
        }
    }
}
