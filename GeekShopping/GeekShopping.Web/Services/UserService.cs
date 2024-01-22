using GeekShopping.Web.Data.ValueObjects;
using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services;

public class UserService : IUserService
{
    private readonly HttpClient _client;
    private readonly IHttpContextAccessor _accessor;
    private const string BASE_PATH_LOGIN = "api/v1/Login/login";
    private const string BASE_PATH = "api/v1/User";
    private string token;

    public UserService(HttpClient cliente, IHttpContextAccessor accessor)
    {
        _client = cliente ?? throw new ArgumentNullException(nameof(cliente));
        _accessor = accessor;
        token = _accessor.HttpContext.Request.Cookies["Token"];
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }   

    public async Task<UserAuthenticatedVO> AuthenticateAsync(UserVO user)
    { 
        var response = await _client.PostAsJson(BASE_PATH_LOGIN, user);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<UserAuthenticatedVO>();
        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<IEnumerable<UserResult>> FindAll()
    {
        var response = await _client.GetAsync(BASE_PATH);

        return await response.ReadContentAs<List<UserResult>>();
    }

    public async Task<UserViewModelWithId> FindById(long id)
    {
        var response = await _client.GetAsync($"{BASE_PATH}/{id}");

        return await response.ReadContentAs<UserViewModelWithId>();
    }

    public async Task<User> FindByNameAndPassword(UserVO vo)
    {
        var response = await _client.PostAsJson(BASE_PATH, vo);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<User>();
        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<UserResult> Create(UserViewModel vo)
    {
        var response = await _client.PostAsJson(BASE_PATH, vo);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<UserResult>();
        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<UserResult> Update(UserViewModelWithId vo)
    {
        var response = await _client.PutAsJson(BASE_PATH, vo);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<UserResult>();
        else throw new Exception("Something went wrong when calling API");
    }

    public async Task<bool> Delete(long id)
    {
        var response = await _client.DeleteAsync($"{BASE_PATH}/{id}");

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else throw new Exception("Something went wrong when calling API");
    }
}
