using DAL.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DalServices
    {
        public static IServiceCollection AddDalServices(this IServiceCollection serviceCollection,
            string connectionString)
        {
            serviceCollection.AddDbContext<TurnoverDbContext>(builder =>
                builder.UseSqlServer(connectionString));
            serviceCollection.AddScoped(typeof(IRepository<>), 
                    typeof(Repository<>))
                .AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddIdentity<User, IdentityRole>(opt =>
                {
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredLength = 4;
                    opt.Password.RequireDigit = false;
                    opt.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<TurnoverDbContext>()
                .AddDefaultTokenProviders();
            return serviceCollection;
        }
    }
}