using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.Lei1601.RequestHandlers
{
    public class DeleteOldFilesHandler : Handler
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public DeleteOldFilesHandler(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public override void ProcessRequest(Lei1601Request request)
        {
            request.AddProcessingLog($"Delete old files");

            var path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");

            request.AddProcessingLog($"Reading enviromment to delete file {path}");

            var filesToDelete = FilesToDelete();

            foreach (string file in filesToDelete)
            {
                var fullpath = path + file;

                if (System.IO.File.Exists(fullpath))
                {
                    request.AddProcessingLog($"Deleting file {file}");

                    System.IO.File.Delete(fullpath);
                }
            }

            sucessor?.ProcessRequest(request);
        }

        private List<string> FilesToDelete()
        {
            var days = Convert.ToInt32(Environment.GetEnvironmentVariable("DAYS_DELETE_OLD_LEI_FILES"));

            var files = fileReadOnlyRepository.GetFiles(f => f.FileName.Contains("GW_SI_1601") &&
                                                (DateTime.UtcNow - f.InclusionDate).Days > days)
                                                .Select(f => f.FileName).ToList();

            return files;
        }
    }
}
