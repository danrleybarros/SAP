using Gcsb.Connect.Pkg.DynamicSearch.Application.Repositories;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.DynamicSearch
{
    public interface IDynamicRepository<T> : IEntityRepository<T> where T : class
    {
        string Table { get; }
        string Schema { get; }
        void ConfigDatabase(string schema, string table);
    }
}
