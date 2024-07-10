using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using File = Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers
{
    public class GenerateFileHandler : Handler<ARRCreditCard>, IGenerateFileHandler<ARRCreditCard>
    {
        private readonly IFileGenerator<ARRCreditCard> fileGenerator;
        private readonly string path;

        public GenerateFileHandler(IFileGenerator<ARRCreditCard> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCard> request)
        {
            request.AddProcessingLog("Generatin ARR");

            request.ARRDomain = new List<ARRCreditCard>();
            request.Files = new List<File::File>();

            request.Lines.ToList().ForEach(f =>
            {
                var sequenceFile = request.SequenceFileStore.Where(store => store.Key == f.Key).FirstOrDefault();
                var identification = new IdentificationRegisterCreditCard(sequenceFile.Value.sequenceFile, f.Key);
                var file = new File::File(identification.FileName, sequenceFile.Value.typeRegister)
                {
                    IdParent = request.IDPaymentFeed
                };
                var arr = new ARRCreditCard(identification, new Header(f.Key), f.Value, file);

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