using GeekShopping.UserAPI.Model;

namespace GeekShopping.UserAPI.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}
