namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.RequestHandlers
{
    public abstract class Handler
    {
        protected Handler sucessor;

        public void SetSucessor(Handler sucessor)
        {
            this.sucessor = sucessor;
        }

        public abstract void ProcessRequest(AllCustomersRequest request);
    }
}
