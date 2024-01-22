using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices;

public interface ICartService
{
    Task<CartViewModel> FindCartByUserId(string userId);
    Task<CartViewModel> AddItemToCart(CartViewModel model);
    Task<CartViewModel> UpdateCart(CartViewModel model);
    Task<bool> RemoveFromCart(long cartId);
    Task<bool> ApplyCoupon(CartViewModel cart, string couponCode);
    Task<bool> RemoveCoupon(string userId);
    Task<bool> ClearCart(string userId);
    Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader);
}
