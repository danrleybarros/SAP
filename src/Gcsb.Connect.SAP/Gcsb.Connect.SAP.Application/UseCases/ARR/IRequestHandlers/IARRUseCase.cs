namespace Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers
{
    public interface IARRUseCase<T>
    {
        int Execute(IARRRequest<T> request);
    }
}