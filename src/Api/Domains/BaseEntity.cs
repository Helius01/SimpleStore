using System.ComponentModel.DataAnnotations;

namespace SimpleShop.src.Api.Domains;

#pragma warning disable CS1591 
public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}