namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers
{
    public abstract class Handler : IHandler
    {
        protected IHandler sucessor;
        public void SetSucessor(IHandler sucessor)
        {
            this.sucessor = sucessor;
        }
        public abstract void ProcessRequest(DocFeedRequest request);
    }
}
