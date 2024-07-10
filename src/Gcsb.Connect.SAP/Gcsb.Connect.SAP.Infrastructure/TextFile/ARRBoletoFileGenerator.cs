using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;
using System;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile
{
    public class ARRBoletoFileGenerator : IFileGenerator<ARRBoleto>
    {
        private IMakeTextFile makeFile;

        public ARRBoletoFileGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public bool ValidateModel(ARRBoleto model)
        {
            if (model.File.Logs.Count(c => c.TypeLog == TypeLog.Error) > 0)
                return false;

            return true;
        }

        public string Generate(ARRBoleto model)
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
