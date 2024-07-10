using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{
    public class FileRequestHandler : IFileRequestHandler
    {
        private IFileReadOnlyRepository fileReadOnlyRepository;
        private TypeReprocessing Reprocessing;

        public FileRequestHandler(IFileReadOnlyRepository fileReadOnlyRepository, TypeReprocessing reprocessing)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
            this.Reprocessing = reprocessing;
        }

        public List<FileResult> Execute(FileRequest request, string linkLog, string linkReprocess)
        {
            List<Connect.Messaging.Messages.File.File> file = new List<Connect.Messaging.Messages.File.File>(fileReadOnlyRepository.GetFiles(request));
            List<FileResult> fileresult = new List<FileResult>(file.Select(s => new FileResult(s, linkLog, linkReprocess))).ToList();

            //aplicar a regra de reprocessamento para o BILLFEED
            switch (Reprocessing)
            {
                case TypeReprocessing.ALL : fileresult.ForEach(p => p.EnableReprocessing = true); break;
                case TypeReprocessing.WaitingAndError: fileresult.ForEach(p => p.EnableReprocessing = (p.Status.Equals(Status.Waiting) || p.Status.Equals(Status.Error)) ? true : false); break;
                case TypeReprocessing.AnySucess: fileresult.ForEach(p => p.EnableReprocessing = (p.Status.Equals(Status.Success)) ? true : false); break;
                case TypeReprocessing.AnyError: fileresult.ForEach(p => p.EnableReprocessing = (p.Status.Equals(Status.Error)) ? true : false); break;
                case TypeReprocessing.AnyWaiting: fileresult.ForEach(p => p.EnableReprocessing = (p.Status.Equals(Status.Waiting)) ? true : false); break;
                default: fileresult.ForEach(p => p.EnableReprocessing = false); break;
            }

            return fileresult;
        }
    }
}
