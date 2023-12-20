using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Models;

public class Product
{
    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]   
    public string CategoryName { get; set; }

    [Required]
    public string ImageURL { get; set; }
}
