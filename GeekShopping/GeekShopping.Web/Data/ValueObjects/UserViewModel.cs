using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Data.ValueObjects;

public class UserViewModel
{
    [Required]
    [StringLength(150)]
    [MinLength(3)]
    public string UserName { get; set; }

    [Required]
    [MinLength(8)]
    public string Password { get; set; }

    [Required]
    public string Role { get; set; }
}
