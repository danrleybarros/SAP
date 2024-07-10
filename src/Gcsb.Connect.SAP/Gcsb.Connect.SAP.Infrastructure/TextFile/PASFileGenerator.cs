using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.FAT;
using Gcsb.Connect.SAP.Domain.PAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile
{
    class PASFileGenerator : IFileGenerator<Domain.PAS.PAS>
    {
        private IMakeTextFile makeFile;

        public PASFileGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(PAS model)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(makeFile.ProcessRequestWithComma(model.Header).ToString());

            foreach (var item in model.Lines)
            {
                sb.AppendLine(makeFile.ProcessRequestWithComma(item).ToString());
            }

            sb.Append(makeFile.ProcessRequestWithComma(model.Footer));
            return sb.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {
            makeFile.Execute(str, path + fileName);
        }

        public bool ValidateModel(PAS model)
        {
            if (model.Lines.Any(s => s.ValidateModel().Count > 0))
                return false;

            return true;
        }
    }
}
