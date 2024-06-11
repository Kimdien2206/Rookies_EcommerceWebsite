using Refit;
using Rookies_EcommerceWebsite.Customer.Clients;

namespace Rookies_EcommerceWebsite.Customer.Extensions.RefitInjection
{
    public static class RefitClientServiceCollectionExtensions
    {
        public static IServiceCollection AddRefitClientsGroup(
             this IServiceCollection services)
        {
            services.AddRefitClient<IProductsClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7144/api"));
            services.AddRefitClient<ICartsClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7144/api"));
            services.AddRefitClient<ICategoriesClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7144/api"));
            services.AddRefitClient<IInvoicesClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7144/api"));
            services.AddRefitClient<IRatingsClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7144/api"));
            services.AddRefitClient<IUsersClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7144/api"));


            return services;
        }
    }
}
