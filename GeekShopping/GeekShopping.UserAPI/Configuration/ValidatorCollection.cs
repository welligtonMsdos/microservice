using FluentValidation;
using FluentValidation.AspNetCore;
using GeekShopping.UserAPI.Repository;
using GeekShopping.UserAPI.Services;
using GeekShopping.UserAPI.Validators;

namespace GeekShopping.UserAPI.Configuration;

public static class ValidatorCollection
{
    public static IServiceCollection AddValidatorCollection(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddValidatorsFromAssemblyContaining<UserViewModelValidator>();

        services.AddValidatorsFromAssemblyContaining<UserViewModelWithIdValidator>();

        services.AddFluentValidationAutoValidation();

        return services;
    }
}
