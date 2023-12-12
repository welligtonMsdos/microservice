using GeekShopping.Web.Models;

namespace GeekShopping.Web.Data.ValueObjects;

public class UserAuthenticatedVO
{
    public User User { get; set; }
    public string Token { get; set; }
}
