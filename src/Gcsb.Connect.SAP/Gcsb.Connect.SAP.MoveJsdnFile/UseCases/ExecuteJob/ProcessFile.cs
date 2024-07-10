using System;
using System.IO;
using System.Linq;

namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases.ExecuteJob
{
    public class ProcessFile : IProcessFile
    {
        public void DeleteFile(string pathFiles, string fileName)
        {
            Console.WriteLine($"Delete files from path: {pathFiles}, with name: {fileName}");

            var di = new DirectoryInfo(pathFiles);
            var file = di.GetFiles().Where(w => w.Name.Contains(fileName)).FirstOrDefault();

            if (file != null)
            {
                Console.WriteLine($"Delete file: {file.FullName}");
                file.Delete();
            }

        }

        public bool ExistFile(string pathProcess)
            => new DirectoryInfo(pathProcess).GetFiles().Length > 0;
    }
}
