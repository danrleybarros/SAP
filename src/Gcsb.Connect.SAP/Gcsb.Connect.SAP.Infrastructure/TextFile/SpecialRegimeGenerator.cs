using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain;
using Gcsb.Connect.SAP.Domain.GF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile
{
    public class SpecialRegimeGenerator : IFileGenerator<List<SpecialRegime>>
    {
        private readonly IMakeTextFile makeFile;

        public SpecialRegimeGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(List<SpecialRegime> model)
        {
            var sb = new StringBuilder();
            var strBuilderTitle = new StringBuilder();
            var specialRegime = model.FirstOrDefault();

            specialRegime.GetType().GetProperties()
                .ToList().ForEach(f =>
                {
                    var attr = f.GetCustomAttributes(false).FirstOrDefault(w => w.GetType().Name.Equals("GFAttribute"));
                    if (attr != null)
                        strBuilderTitle.Append($"{((GFAttribute)attr).Name};");
                });

            sb.AppendLine(strBuilderTitle.ToString().Substring(0, strBuilderTitle.ToString().Length - 1));

            model.ForEach(f =>
            {
                var str = makeFile.ProcessRequestWithComma(f).ToString();
                sb.AppendLine(str.Substring(0, str.Length - 1));
            });

            return sb.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {
            makeFile.Execute(str, path + fileName);
        }

        public bool ValidateModel(List<SpecialRegime> model)
        {
            throw new NotImplementedException();
        }
    }
}
