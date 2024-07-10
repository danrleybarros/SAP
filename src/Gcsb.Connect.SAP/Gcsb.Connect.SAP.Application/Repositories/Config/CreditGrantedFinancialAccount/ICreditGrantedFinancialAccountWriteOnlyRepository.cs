namespace Gcsb.Connect.SAP.Application.Repositories.Config.CreditGrantedFinancialAccount
{
    public interface ICreditGrantedFinancialAccountWriteOnlyRepository
    {
        int Add(Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount creditGrantedFinancialAccount);
        int Update(Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount creditGrantedFinancialAccount);
    }
}
