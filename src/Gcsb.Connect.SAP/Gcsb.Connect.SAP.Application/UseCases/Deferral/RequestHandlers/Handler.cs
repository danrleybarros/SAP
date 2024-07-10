namespace Gcsb.Connect.SAP.Application.UseCases.Deferral.RequestHandlers
{
    public abstract class Handler
    {
        protected Handler sucessor;

        public Handler SetSucessor(Handler sucessor)
          => this.sucessor = sucessor;

        public abstract void ProcessRequest(DeferralRequest request);
    }
}
