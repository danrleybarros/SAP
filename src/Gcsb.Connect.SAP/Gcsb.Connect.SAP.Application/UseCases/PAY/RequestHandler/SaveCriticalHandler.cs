using Gcsb.Connect.SAP.Application.Repositories.Pay.Critical;

namespace Gcsb.Connect.SAP.Application.UseCases.PAY.RequestHandler
{
    public class SaveCriticalHandler : Handler
    {
        private readonly ICriticaWriteRepository criticaWriteRepository;

        public SaveCriticalHandler(ICriticaWriteRepository criticaWriteRepository)
        {
            this.criticaWriteRepository = criticaWriteRepository;
        }

        public override void ProcessRequest(CriticalRequest request)
        {
            request.AddLog("Saving data on database");

            criticaWriteRepository.Add(request.Criticals);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
