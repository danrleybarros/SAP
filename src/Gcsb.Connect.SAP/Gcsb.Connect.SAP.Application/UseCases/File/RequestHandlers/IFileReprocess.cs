namespace Gcsb.Connect.SAP.Application.UseCases.File.RequestHandlers
{
    public interface IFileReprocess<T>
    {
        void Reprocess(T file);
    }
}
