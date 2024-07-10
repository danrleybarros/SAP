using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile
{
    public class ARRIntercompanyFileGenerator : IFileGenerator<ARRCreditCardInter>
    {
        private IMakeTextFile makeFile;

        public ARRIntercompanyFileGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public bool ValidateModel(ARRCreditCardInter model)
        {
            if (model.File.Logs.Count(c => c.TypeLog == TypeLog.Error) > 0)
                return false;

            return true;
        }

        public string Generate(ARRCreditCardInter model)
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine(makeFile.ProcessRequestWithSpace(model.IdentificationRegister).ToString());
            strBuilder.AppendLine(makeFile.ProcessRequestWithSpace(model.Header).ToString());

            foreach (var item in model.LaunchItems)
                strBuilder.AppendLine(makeFile.ProcessRequestWithSpace(item).ToString());

            strBuilder.Append(makeFile.ProcessRequestWithSpace(model.Footer).ToString());

            return strBuilder.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {
            makeFile.Execute(str, path + fileName);
        }
    }
}
