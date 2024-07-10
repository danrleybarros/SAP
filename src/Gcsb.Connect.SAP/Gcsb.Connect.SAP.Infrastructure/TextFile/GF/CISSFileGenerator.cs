using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.GF.CISS;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile.GF
{
    public class CISSFileGenerator : IFileGenerator<CISSRequest>
    {
        private readonly IMakeTextFile makeFile;

        public CISSFileGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(CISSRequest ciss)
        {      
            var strBuilder = new StringBuilder();
            ciss.LaunchItems.ForEach(f => strBuilder.AppendLine(makeFile.ProcessRequestWithSpace(f).ToString()));

            return strBuilder.ToString();      
        }

        public void SaveFile(string str, string path, string fileName)
        {
            makeFile.Execute(str, System.IO.Path.Combine(path, fileName));
        }

        public bool ValidateModel(CISSRequest model)
        => !(model.File.Logs.Count(c => c.TypeLog == TypeLog.Error) > 0);
    }
}
