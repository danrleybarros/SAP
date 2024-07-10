using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.AJU;
using System.IO;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile
{
    public class AJUFileGenerator : IFileGenerator<AJU>
    {
        private readonly IMakeTextFile makeFile;

        public AJUFileGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(AJU model)
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine(makeFile.ProcessRequestWithSpace(model.IdentificationRegister).ToString());
            strBuilder.AppendLine(makeFile.ProcessRequestWithSpace(model.Header).ToString());

            foreach (var item in model.Launches)
                strBuilder.AppendLine(makeFile.ProcessRequestWithSpace(item).ToString());

            strBuilder.Append(makeFile.ProcessRequestWithSpace(model.Footer).ToString());

            return strBuilder.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {
            makeFile.Execute(str, Path.Combine(path, fileName));
        }

        public bool ValidateModel(AJU model)
        {
            if (model.File.Logs.Count(c => c.TypeLog == TypeLog.Error) > 0)
                return false;

            return true;
        }
    }
}
