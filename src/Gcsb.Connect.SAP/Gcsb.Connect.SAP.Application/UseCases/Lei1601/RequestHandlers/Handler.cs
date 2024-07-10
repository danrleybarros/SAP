
namespace Gcsb.Connect.SAP.Application.UseCases.Lei1601.RequestHandlers
{
    public abstract class Handler
    {
        protected Handler sucessor;

        public void SetSucessor(Handler sucessor)
        {
            this.sucessor = sucessor;
        }

        public abstract void ProcessRequest(Lei1601Request request);

    }
}
