using GeekShopping.CartAPI.Repository;

namespace GeekShopping.CartAPI.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<ICartRepository, CartRepository>();
        //services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
