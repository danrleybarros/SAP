namespace Gcsb.Connect.SAP.Application.UseCases.Config.InvoiceDetails.RequestHandlers
{
    public abstract class Handler
    {
        protected Handler sucessor;

        public Handler SetSucessor(Handler sucessor) =>
            this.sucessor = sucessor;

        public abstract void ProcessRequest(InvoiceDetailsRequest request);
    }
}
