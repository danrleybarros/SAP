using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.FAT.FATaFaturarECM;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile
{
    public class FatECMFileGenerator : IFileGenerator<FATaFaturarECM>
    {
        private IMakeTextFile makeFile;

        public FatECMFileGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(FATaFaturarECM fat)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(makeFile.ProcessRequestWithSpace<IdentificationRecordECM>(fat.IdentificationRecord as IdentificationRecordECM).ToString());
            sb.AppendLine(makeFile.ProcessRequestWithSpace<Domain.FAT.FATBase.Header>(fat.Header).ToString());

            foreach (var item in fat.Launchs)
            {
                sb.AppendLine(makeFile.ProcessRequestWithSpace<LaunchECM>(item as LaunchECM).ToString());
            }

            sb.Append(makeFile.ProcessRequestWithSpace<Domain.FAT.FATBase.Footer>(fat.Footer).ToString());

            return sb.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {            
            makeFile.Execute(str, path + fileName);
        }

        public bool ValidateModel(FATaFaturarECM model)
        => !(model.File.Logs.Count(c => c.TypeLog == TypeLog.Error) > 0);
    }
}
