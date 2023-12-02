using GeekShopping.ProductAPI.Repository;

namespace GeekShopping.ProductAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
