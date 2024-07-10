namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices
{
    public abstract class Handler<T>
    {
        protected Handler<T> sucessor;

        public Handler<T> SetSucessor(Handler<T> sucessor) =>
            this.sucessor = sucessor;

        public abstract void ProcessRequest(T request);

        public Handler<T> GetSucessor() => sucessor;
    }
}