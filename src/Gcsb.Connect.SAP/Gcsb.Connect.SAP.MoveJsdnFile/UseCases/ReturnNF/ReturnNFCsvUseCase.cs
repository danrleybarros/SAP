using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Gcsb.Connect.SAP.MoveJsdnFile.Infraestructure.Service;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases.ReturnNF
{
    public class ReturnNFCsvUseCase : IDownloadFilesUseCase
    {
        public TypeRegister TypeRegister => TypeRegister.RETURNNF;

        private readonly IDownloadService downloadService;
        private readonly IMassTransitService massTransitService;

        public ReturnNFCsvUseCase(IDownloadService downloadService, IMassTransitService massTransitService)
        {
            this.downloadService = downloadService;
            this.massTransitService = massTransitService;
        }

        public void Execute(Configs configs)
            => MoveReturnNf(configs.Interfaces.FirstOrDefault(c => c.Type == "RETURNNF"));

        private void MoveReturnNf(Interface config)
        {
            Console.WriteLine("Getting NFe files");

            var source = JObject.Parse(config.Source);
            var files = new Dictionary<string, List<string>>();

            if (source != null && source.Count > 0)
            {
                var tbraFiles = downloadService.DownloadFiles(source["tbra"].Value<string>(), config.Dest, ".csv", config.Process, false);
                var cloudCoFiles = downloadService.DownloadFiles(source["cloudco"].Value<string>(), config.Dest, ".csv", config.Process, true);

                tbraFiles.ForEach(tbraFile =>
                {
                    var fileName = Path.GetFileName(tbraFile);
                    var cloudcoFile = cloudCoFiles.Where(w => w.Contains(GetDate(fileName, 8))).FirstOrDefault();

                    if (!string.IsNullOrEmpty(cloudcoFile))
                    {
                        var fileNameCloudCO = Path.GetFileName(cloudcoFile);
                        var files = new List<NfeFiles>
                        {
                            new NfeFiles(fileName, "telerese", GetDate(fileNameCloudCO, 14)),
                            new NfeFiles(Path.GetFileName(cloudcoFile), "cloudco", GetDate(fileNameCloudCO, 14))
                        };

                        massTransitService.SendReturnNFToProcess(new ReturnNFCsv(JsonConvert.SerializeObject(files)));
                    }
                });
            }
        }

        private string GetDate(string fileName, int positions)
            => new Regex("[0-9]{" + positions + "}").Match(fileName).Value;
    }
}
