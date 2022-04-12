using AutoMapper;
using System.Collections.Generic;

namespace XOLIT.ShoppingCart.Commond.AutoMapper
{
    public class MapperXOLIT<TSource, TDestination>
    {
        private readonly MapperConfiguration _configurationProvider;

        public MapperXOLIT()
        {
            _configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<TSource, TDestination>();
            });
        }

        public TDestination CreteMapper(TSource source)
        {
            var mapperEntity = new Mapper(_configurationProvider);
            var resultMapper = mapperEntity.Map<TSource, TDestination>(source);
            return resultMapper;
        }

        public List<TDestination> CreteMapper(List<TSource> source)
        {
            var mapperEntity = new Mapper(_configurationProvider);
            var resultMapper = mapperEntity.Map<List<TDestination>>(source);
            return resultMapper;
        }
    }
}