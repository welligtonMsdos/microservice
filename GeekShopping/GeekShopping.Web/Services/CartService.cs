using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services;

public class CartService : ICartService
{
    private readonly HttpClient _client;
    public const string BASE_PATH = "api/v1/cart";
    private readonly IHttpContextAccessor _accessor;
    private string token;

    public CartService(HttpClient cliente, IHttpContextAccessor accessor)
    {
        _client = cliente ?? throw new ArgumentNullException(nameof(cliente));
        _accessor = accessor;
        token = _accessor.HttpContext.Request.Cookies["Token"];
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<CartViewModel> FindCartByUserId(string userId)
    {
        var response = await _client.GetAsync($"{BASE_PATH}/find-cart/{userId}");

        return await response.ReadContentAs<CartViewModel>();
    }

    public async Task<CartViewModel> AddItemToCart(CartViewModel model)
    {
        var response = await _client.PostAsJson($"{BASE_PATH}/add-cart", model);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<CartViewModel>();
        else throw new Exception("Something went wrong when calling API");
    }
    public async Task<CartViewModel> UpdateCart(CartViewModel model)
    {
        var response = await _client.PutAsJson($"{BASE_PATH}/update-cart", model);

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<CartViewModel>();
        else throw new Exception("Something went wrong when calling API");
    }
    public async Task<bool> RemoveFromCart(long cartId)
    {
        var response = await _client.DeleteAsync($"{BASE_PATH}/remove-cart/{cartId}");

        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else throw new Exception("Something went wrong when calling API");
    }

    public Task<bool> ApplyCoupon(CartViewModel cart, string couponCode)
    {
        throw new NotImplementedException();
    }
    public Task<bool> RemoveCoupon(string userId)
    {
        throw new NotImplementedException();
    }
    public Task<bool> ClearCart(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader)
    {
        throw new NotImplementedException();
    } 
}
