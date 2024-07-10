namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed
{
    public interface IPaymentFeedDataTransactionUseCase
    {
        void Execute(PaymentFeedRequest request);
    }
}
