using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers
{
    public class GenerateOutputHandler<T> : Handler<T>, IGenerateOutputHandler<T>
    {
        private readonly IFileGenerator<T> fileGenerator;
        private readonly string path;

        public GenerateOutputHandler(IFileGenerator<T> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }

        public override void ProcessRequest(T request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");

            ((IRequest)request).AddLog($"Trying generate a output file", TypeLog.Processing);
            ((IRequest)request).OutputFile = fileGenerator.Generate(request);

            fileGenerator.SaveFile(((IRequest)request).OutputFile, path, ((IRequest)request).FileName);

            sucessor?.ProcessRequest(request);
        }
    }
}
