using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using System;
using System.Collections.Generic;
using File = Gcsb.Connect.Messaging.Messages.File;
using System.Linq;
using Gcsb.Connect.SAP.Domain.ARR;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.BoletoIntercompany
{
    public class GenerateFileHandler : Handler<ARRBoletoInter>, IGenerateFileHandler<ARRBoletoInter>
    {
        private readonly IFileGenerator<ARRBoletoInter> fileGenerator;
        private readonly string path;

        public GenerateFileHandler(IFileGenerator<ARRBoletoInter> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }

        public override void ProcessRequest(IARRRequest<ARRBoletoInter> request)
        {
            request.AddProcessingLog("Generatin ARR Boleto Intercompany");

            request.ARRDomain = new List<ARRBoletoInter>();
            request.Files = new List<File::File>();

            request.Lines.ToList().ForEach(f =>
            {
                var sequenceFile = request.SequenceFileStore.Where(store => store.Key == f.Key).FirstOrDefault();
                var identification = new IdentificationRegisterBoleto(sequenceFile.Value.sequenceFile, f.Key);
                var file = new File::File(identification.FileName, sequenceFile.Value.typeRegister)
                {
                    IdParent = request.IDPaymentFeed
                };
                var arr = new ARRBoletoInter(identification, new Header(f.Key), f.Value, file);

                request.ARRDomain.Add(arr);

                if (fileGenerator.ValidateModel(arr))
                {
                    var strOutput = fileGenerator.Generate(arr);

                    file.Status = Status.Success;

                    request.AddProcessingLog($"Saving ARR - {f.Key}");
                    fileGenerator.SaveFile(strOutput, path, identification.FileName);
                }
                else
                    file.Status = Status.Error;

                request.Files.Add(file);
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
