using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.TextFile.GF
{
    public class ItemsFileGenerator : IFileGenerator<ItemsRequest>
    {
        private readonly IMakeTextFile makeFile;

        public ItemsFileGenerator(IMakeTextFile makeFile)
        {
            this.makeFile = makeFile;
        }

        public string Generate(ItemsRequest model)
        {
            var strBuilder = new StringBuilder();
            model.Items.ForEach(f => strBuilder.AppendLine(makeFile.ProcessRequestWithSpace(f).ToString()));
            
            return strBuilder.ToString();
        }

        public void SaveFile(string str, string path, string fileName)
        {
            makeFile.Execute(str, $"{path}{fileName}");
        }

        public bool ValidateModel(ItemsRequest model)
        {
            if (model.File.Logs.Count(c => c.TypeLog == TypeLog.Error) > 0)
                return false;

            return true;
        }
    }
}
