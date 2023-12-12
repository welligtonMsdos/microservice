using GeekShopping.Web.Data.ValueObjects;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services;

public class UserService : IUserService
{
    private readonly HttpClient _cliente;  
    public const string BASE_PATH = "api/v1/Login/login";

    public UserService(HttpClient cliente)
    {
        _cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
    }   

    public async Task<UserAuthenticatedVO> AuthenticateAsync(UserVO user)
    {
        var response = await _cliente.PostAsJson(BASE_PATH, user);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<UserAuthenticatedVO>();
        else throw new Exception("Something went wrong when calling API");
    }
}
