using IlustraApp.Infrastructure.Data;
using IlustraApp.Infrastructure.Repository;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IlustraApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IlustraContext>(option => option.UseSqlServer(configuration.GetConnectionString("IlustraEntities")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IColorRepository, ColorRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IDimensionRepository, DimensionRepository>();

            return services;
        }

    }
}
