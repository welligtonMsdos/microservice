using GeekShopping.Web.Data.ValueObjects;
using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices;

public interface IUserService
{
    Task<UserAuthenticatedVO>  AuthenticateAsync(UserVO user);
}
