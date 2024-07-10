namespace Gcsb.Connect.SAP.Application.Boundaries
{
    public interface IOutputPort<T>
    {
        void Standard(T output);
        void Error(string message);
        void NotFound(string v);
    }
}
