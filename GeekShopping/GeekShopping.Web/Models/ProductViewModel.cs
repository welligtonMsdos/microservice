using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Models;

public class ProductViewModel
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

    [Range(1,100)]
    public int Count { get; set; } = 1;

    public string SubstringName()
    {
        if (Name.Length < 24) return Name;

        return $"{Name.Substring(0, 21)} ...";
    }

    public string SubstringDescription()
    {
        if (Description.Length < 355) return Description;

        return $"{Description.Substring(0, 352)} ...";
    }
}
