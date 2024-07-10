using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.OrdemInterna;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.OrdemInterna
{
    public class OrdemInternaUseCase : IOrdemInternaUseCase
    {
        private readonly IOutputPort<OrdemInternaOutput> outputPort;

        public OrdemInternaUseCase(IOutputPort<OrdemInternaOutput> outputPort)
        {
            this.outputPort = outputPort;
        }

        public void Execute(OrdemInternaRequest request)
        {
            var uFsComp = new List<UFCompOutput>();

            request.UFs.FindAll(f => !string.IsNullOrEmpty(f)).ForEach(uf =>
            {
                var order = Util.GetUF(uf.ToLower(), request.Store);
                uFsComp.Add(new UFCompOutput(order.Uf, order.State, order.InternalOrder));
            });

            request.OrdemInternaOutput = new OrdemInternaOutput(uFsComp);

            outputPort.Standard(request.OrdemInternaOutput);
        }
    }
}
