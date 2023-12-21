using GeekShoppingUserAPI.Test.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace GeekShoppingUserAPI.Test.Model;

internal class User : BaseEntity
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
