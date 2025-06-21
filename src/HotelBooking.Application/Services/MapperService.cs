using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace HotelBooking.Application.Services
{
    public class MapperService
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return _mapper.Map<IEnumerable<TDestination>>(source);
        }
        
        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            _mapper.Map(source, destination);
        }

        public IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source)
        {
            return source.ProjectTo<TDestination>(_mapper.ConfigurationProvider);
        }

        
    }
} 