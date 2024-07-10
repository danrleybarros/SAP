using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile.GF
{
   public class AxiliaryBookGenerator : IFileGenerator<AxiliaryBookRequest>
    {
        private readonly IMakeTextFile makeFile;

        public AxiliaryBookGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(AxiliaryBookRequest axiliaryBookRequest)
        {
            var strBuilder = new StringBuilder();
            axiliaryBookRequest.LaunchItems.ForEach(f => strBuilder.AppendLine(makeFile.ProcessRequestWithSpace(f).ToString()));
           
            return strBuilder.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {
            makeFile.Execute(str, Path.Combine(path,fileName));
        }

        public bool ValidateModel(AxiliaryBookRequest model)
        {
            if (model.File.Logs.Count(c => c.TypeLog == TypeLog.Error) > 0)
                return false;

            return true;
        }
    }
}
