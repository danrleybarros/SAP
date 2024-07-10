using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain;
using Gcsb.Connect.SAP.Domain.GF;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile.GF
{
    public class IndividualReportFileGenerator : IFileGenerator<List<IndividualReportNF>>
    {
        private readonly IMakeTextFile makeFile;

        public IndividualReportFileGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(List<IndividualReportNF> model)
        {
            var strBuilder = new StringBuilder();
            var strBuilderTitle = new StringBuilder();
            var individualReport = model.FirstOrDefault();

            individualReport.GetType()
                .GetProperties()
                .ToList().ForEach(f =>
                {
                    var attr = f.GetCustomAttributes(false).FirstOrDefault(w => w.GetType().Name.Equals("GFAttribute"));

                    if (attr != null)
                        strBuilderTitle.Append($"{((GFAttribute)attr).Name};");
                });

            strBuilder.AppendLine(strBuilderTitle.ToString().Substring(0, strBuilderTitle.ToString().Length - 1));

            model.ForEach(f =>
            {
                var str = makeFile.ProcessRequestWithComma(f).ToString();
                strBuilder.AppendLine(str.Substring(0, str.Length - 1));
            });

            return strBuilder.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {
            makeFile.Execute(str, $"{path}{fileName}");
        }

        public bool ValidateModel(List<IndividualReportNF> model)
        {
            if (model.Count == 0)
                return false;

            return true;
        }
    }
}
