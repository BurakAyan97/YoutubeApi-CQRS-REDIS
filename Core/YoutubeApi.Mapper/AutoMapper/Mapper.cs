using AutoMapper;
using AutoMapper.Internal;

namespace YoutubeApi.Mapper.AutoMapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        public static List<TypePair> typePairs = new();
        private IMapper mapperContainer;
        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return mapperContainer.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return mapperContainer.Map<IList<TSource>, IList<TDestination>>(sources);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            Config<TDestination, object>(5, ignore);

            return mapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination>(IList<object> sources, string? ignore = null)
        {
            Config<TDestination, IList<object>>(5, ignore);

            return mapperContainer.Map<IList<TDestination>>(sources);
        }

        //depth iç içe geçen dtoları mapleme sayısıdır. Örneğin BrandDto->ProductDto->CategoryDto (içinde dto propertysi olan classlar. Default olarak 5'dir automapperda)
        protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination));

            if (typePairs.Exists(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType) && ignore is null)
                return;

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var pair in typePairs)
                {
                    if (ignore is not null)
                        cfg.CreateMap(pair.SourceType, pair.DestinationType).MaxDepth(depth).ForMember(ignore, x => x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(pair.SourceType, pair.DestinationType).MaxDepth(depth).ReverseMap();
                }
            });

            mapperContainer = config.CreateMapper();
        }
    }
}
