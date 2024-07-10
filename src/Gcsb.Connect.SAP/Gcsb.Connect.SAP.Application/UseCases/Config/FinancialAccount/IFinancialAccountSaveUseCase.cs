namespace Gcsb.Connect.SAP.Application.UseCases.Config
{
    public interface IFinancialAccountSaveUseCase
    {
        int Execute(FinancialAccountResult FinancialAccount, string UserId , string UserName);
      
    }
}
