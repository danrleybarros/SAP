namespace Gcsb.Connect.SAP.Application.UseCases.JSDN
{
    public interface IPaymentFeedUseCase<T>
    {
        int Execute(DocFeedRequest request);
    }
}
