using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories.Config.CreditGrantedFinancialAccount;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetAll
{
    public class GetAllUseCase : IGetAllUseCase
    {
        private readonly ICreditGrantedFinancialAccountReadOnlyRepository readOnlyRepository;
        private readonly IOutputPort<GetAllOutput> outputPort;

        public GetAllUseCase(ICreditGrantedFinancialAccountReadOnlyRepository readOnlyRepository,
            IOutputPort<GetAllOutput> outputPort)
        {
            this.readOnlyRepository = readOnlyRepository;
            this.outputPort = outputPort;
        }

        public void Execute(GetAllRequest request)
        {
            var accounts = readOnlyRepository.GetAll();
            request.Output = new GetAllOutput(accounts);
            outputPort.Standard(request.Output);
        }
    }
}
