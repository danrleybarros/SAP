using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Infrastructure.Mapper
{
    public class MapperService : IMapperService
    {
        private readonly IMapper mapper;

        public MapperService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
            => mapper.Map<TDestination>(source);

    }
}
