namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers
{
    public interface IHandler
    {
        void SetSucessor(IHandler sucessor);

        void ProcessRequest(DocFeedRequest request);
    }
}
