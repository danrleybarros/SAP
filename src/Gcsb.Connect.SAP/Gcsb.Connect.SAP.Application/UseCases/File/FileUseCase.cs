using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{
    public class FileUseCase : IFileUseCase
    {
        private IFileReadOnlyRepository fileReadOnlyRepository;

        public FileUseCase(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public virtual List<FileResult> Execute(FileRequest request, string linkLog, string linkReprocess)
        {
            return new FileFactory(fileReadOnlyRepository).Execute(request, linkLog, linkReprocess);
            //test
        }
    }
}
