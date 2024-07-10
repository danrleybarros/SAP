namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IBillFeedReadCsvRepository
    {
        string ReadCsvFile(string path);
    }
}