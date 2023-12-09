using GeekShopping.UserAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.UserAPI.Model;

[Table("user")]
public class User : BaseEntity
{       
    [StringLength(150)]
    public string UserName { get; set; }     
    
    public string Password { get; set; }        
     
    public string Role { get; set; }    
}
