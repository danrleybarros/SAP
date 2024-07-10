using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.Lei1601.RequestHandlers
{
    public class SequenceHandler : Handler
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public SequenceHandler(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public override void ProcessRequest(Lei1601Request request)
        {
            request.AddProcessingLog("Getting sequence Lei 1601");

            request.Sequence = fileReadOnlyRepository.GetTodaySequentialFile(Messaging.Messages.File.Enum.TypeRegister.LEI1601);

            sucessor?.ProcessRequest(request);
        }
    }
}
