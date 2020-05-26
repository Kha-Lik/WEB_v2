using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Mapper
{
    public static class MapperServiceExtension
    {
        public static IServiceCollection BindMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(c => c.AddProfile(new MapperProfile()));

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}