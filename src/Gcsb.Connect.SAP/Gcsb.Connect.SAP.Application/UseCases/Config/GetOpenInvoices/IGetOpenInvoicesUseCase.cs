namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices
{
    public interface IGetOpenInvoicesUseCase
    {
        void Execute(GetOpenInvoicesRequest request);
        IGetOpenInvoicesUseCase AddPayFilterHandler();
    }
}
