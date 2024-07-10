using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.FinancialAccount;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public abstract class Handler :  IHandler
    {
        protected IHandler sucessor;

        public void SetSucessor(IHandler sucessor)
        {
            this.sucessor = sucessor;
        }

        public abstract void ProcessRequest(FATRequest request);
    }
}
