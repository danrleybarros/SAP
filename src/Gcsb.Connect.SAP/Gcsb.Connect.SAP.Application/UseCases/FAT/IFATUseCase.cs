namespace Gcsb.Connect.SAP.Application.UseCases.FAT
{
    public interface IFATUseCase<T>
    {
        int Execute(FATRequest request);
    }
}