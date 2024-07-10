using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.FAT.FATaFaturarACM;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile
{
    public class FatACMFileGenerator : IFileGenerator<FATaFaturarACM>
    {
        private IMakeTextFile makeFile;

        public FatACMFileGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(FATaFaturarACM fat)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(makeFile.ProcessRequestWithSpace<IdentificationRecordACM>(fat.IdentificationRecord as IdentificationRecordACM).ToString());
            sb.AppendLine(makeFile.ProcessRequestWithSpace<Domain.FAT.FATBase.Header>(fat.Header).ToString());

            foreach (var item in fat.Launchs)
            {
                sb.AppendLine(makeFile.ProcessRequestWithSpace<LaunchACM>(item as LaunchACM).ToString());
            }

            sb.Append(makeFile.ProcessRequestWithSpace<Domain.FAT.FATBase.Footer>(fat.Footer).ToString());

            return sb.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {            
            makeFile.Execute(str, path + fileName);
        }

        public bool ValidateModel(FATaFaturarACM model)
        => !(model.File.Logs.Count(c => c.TypeLog == TypeLog.Error) > 0);
    }
}
