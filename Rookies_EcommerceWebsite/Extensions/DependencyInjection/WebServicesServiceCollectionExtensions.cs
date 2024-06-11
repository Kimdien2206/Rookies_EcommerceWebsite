using Rookies_EcommerceWebsite.Repositories;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.API.Extensions.DependencyInjection
{
    public static class WebServicesServiceCollectionExtensions
    {

        public static IServiceCollection AddRepositoryDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<IRepository<Product>, GenericRepository<Product>>();
            services.AddScoped<IRepository<Category>, GenericRepository<Category>>();
            services.AddScoped<IRepository<Cart>, GenericRepository<Cart>>();
            services.AddScoped<IRepository<Invoice>, GenericRepository<Invoice>>();
            services.AddScoped<IRepository<Rating>, GenericRepository<Rating>>();
            services.AddScoped<IRepository<User>, GenericRepository<User>>();
            services.AddScoped<IRepository<Variant>, GenericRepository<Variant>>();

            return services;
        }
    }
}
