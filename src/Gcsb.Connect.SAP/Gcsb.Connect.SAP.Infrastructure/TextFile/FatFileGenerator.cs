using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.FAT.FATFaturado;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile
{
    public class FatFileGenerator : IFileGenerator<FATFaturado>
    {
        private IMakeTextFile makeFile;

        public FatFileGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(FATFaturado fat)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(makeFile.ProcessRequestWithSpace<IdentificationRecordFaturado>(fat.IdentificationRecord as IdentificationRecordFaturado).ToString());
            sb.AppendLine(makeFile.ProcessRequestWithSpace<Domain.FAT.FATBase.Header>(fat.Header).ToString());

            foreach (var item in fat.Launchs)
            {
                sb.AppendLine(makeFile.ProcessRequestWithSpace<LaunchFaturado>(item as LaunchFaturado).ToString());
            }

            sb.Append(makeFile.ProcessRequestWithSpace<Domain.FAT.FATBase.Footer>(fat.Footer).ToString());

            return sb.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {            
            makeFile.Execute(str, path + fileName);
        }

        public bool ValidateModel(Domain.FAT.FATFaturado.FATFaturado model)
        => !(model.File?.Logs?.Count(c => c.TypeLog == TypeLog.Error) > 0);
    }
}
