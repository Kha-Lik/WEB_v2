using BLL.Abstract;
using BLL.Implementation.Mapper;
using BLL.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Implementation
{
    public static class BllServices
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>()
                .AddTransient<ICommodityService, CommodityService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IEmailService, EmailService>();
            services.BindMapper();
            return services;
        }
    }
}