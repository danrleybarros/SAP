namespace Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers
{
    public abstract class Handler<T> : IHandler<T>
    {
        protected IHandler<T> sucessor;

        public void SetSucessor(IHandler<T> sucessor)
        {
            this.sucessor = sucessor;
        }

        public abstract void ProcessRequest(T request);
    }
}
