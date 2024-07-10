using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile
{
    public class IndividualReportServiceGenerator : IFileGenerator<ISIObj>
    {
        private IMakeTextFile makeTextFile;

        public IndividualReportServiceGenerator(IMakeTextFile makeTextFile)
        {
            this.makeTextFile = makeTextFile;
        }

        public string Generate(ISIObj model)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach(var item in model.individualReportServices)
            {
                sb.AppendLine(makeTextFile.ProcessRequestWithSpace(item).ToString());
            }

            return sb.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {
            makeTextFile.Execute(str, path + fileName);
        }

        public bool ValidateModel(ISIObj model)
        {
            throw new NotImplementedException();
        }
    }
}
