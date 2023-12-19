using GeekShopping.UserAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.UserAPI.Model;

[Table("user")]
public class User : BaseEntity
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
