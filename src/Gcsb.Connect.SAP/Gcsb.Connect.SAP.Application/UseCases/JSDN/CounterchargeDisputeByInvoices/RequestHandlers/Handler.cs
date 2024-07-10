namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDisputeByInvoices.RequestHandlers
{
    public abstract class Handler
    {
        protected Handler sucessor;

        public void SetSucessor(Handler sucessor)
        {
            this.sucessor = sucessor;
        }

        public abstract void ProcessRequest(CounterchargeDisputeByInvoicesRequest request);
    }
}
