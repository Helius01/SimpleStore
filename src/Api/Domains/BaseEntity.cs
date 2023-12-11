using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.src.Api.Domains;

public abstract class BaseEntity
{
    [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
}