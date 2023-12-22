namespace GeekShopping.CartAPI.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services, ConfigurationManager configuration)
    {
        //services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
