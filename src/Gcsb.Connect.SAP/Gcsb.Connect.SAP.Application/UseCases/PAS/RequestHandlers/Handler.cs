namespace Gcsb.Connect.SAP.Application.UseCases.PAS.RequestHandlers
{
    public abstract class Handler
    {
        protected Handler sucessor;
        public void SetSucessor(Handler sucessor)
        {
            this.sucessor = sucessor;
        }
        public abstract void ProcessRequest(PASChainRequest request);
    }
}
