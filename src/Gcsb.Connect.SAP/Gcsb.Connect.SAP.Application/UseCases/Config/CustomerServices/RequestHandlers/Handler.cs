namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices.RequestHandlers
{
    public abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void ProcessRequest(CustomerServicesRequest request);
    }
}
