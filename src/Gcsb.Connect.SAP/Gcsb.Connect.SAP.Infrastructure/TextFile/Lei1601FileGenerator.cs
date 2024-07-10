using System.IO;
using System.Linq;
using System.Text;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.LEI1601;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile
{
    public class Lei1601FileGenerator : IFileGenerator<Lei1601>
    {
        private readonly IMakeTextFile makeFile;

        public Lei1601FileGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(Lei1601 model)
        {
            var strBuilder = new StringBuilder();

            foreach (var item in model.Launches)
                strBuilder.AppendLine(makeFile.ProcessRequestWithSpace(item).ToString());

            return strBuilder.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {
            makeFile.Execute(str, Path.Combine(path, fileName));
        }

        public bool ValidateModel(Lei1601 model)
        {
            if (model.File.Logs.Count(c => c.TypeLog == TypeLog.Error) > 0)
                return false;

            return true;
        }
    }
}
