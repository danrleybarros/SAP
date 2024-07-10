namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IMapperService
    {
        TDestination Map<TDestination>(object source);
    }
}
