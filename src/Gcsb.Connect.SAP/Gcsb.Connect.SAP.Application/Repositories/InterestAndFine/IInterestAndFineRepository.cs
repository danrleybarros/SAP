namespace Gcsb.Connect.SAP.Application.Repositories.InterestAndFine
{
    public interface IInterestAndFineRepository
    {
        bool SendBillFeedProcessed(string FileName, string cycle);
    }
}
