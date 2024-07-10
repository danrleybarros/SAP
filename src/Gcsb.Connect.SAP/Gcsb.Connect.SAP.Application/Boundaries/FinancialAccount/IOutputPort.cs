
namespace Gcsb.Connect.SAP.Application.Boundaries.FinancialAccount
{
    public interface IOutputPort
    {
        void Standard(Domain.Config.FinancialAccount financialAccount);

        void Error(string message);

        void NotFound(string message);
    }
}
