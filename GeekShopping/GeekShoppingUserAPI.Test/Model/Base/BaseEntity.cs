using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShoppingUserAPI.Test.Model.Base;

internal class BaseEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
}
