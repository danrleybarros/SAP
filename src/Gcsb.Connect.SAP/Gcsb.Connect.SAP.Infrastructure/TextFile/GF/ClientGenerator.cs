using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers;
using System;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile.GF
{
    public class ClientGenerator : IFileGenerator<ClientObj>
    {
        private readonly IMakeTextFile makeFile;
        public ClientGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(ClientObj model)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in model.Clients)
            {
                sb.AppendLine(makeFile.ProcessRequestWithSpace<Domain.GF.Client>(item).ToString());
            }

            return sb.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {
            makeFile.Execute(str, path + fileName);
        }

        public bool ValidateModel(ClientObj model)
        {
            throw new NotImplementedException();
        }
    }
}
