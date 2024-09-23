using System.ComponentModel.DataAnnotations;

namespace Wishlist.Domain;

public class Product(Guid Id, string Name, decimal Price, string Description, Guid CategoryId)
{
    public Guid Id { get; init; } = Id;
    [MaxLength(128)] public string Name { get; init; } = Name;
    public decimal Price { get; init; } = Price;
    [MaxLength(256)] public string Description { get; init; } = Description;
    public Guid CategoryId { get; init; } = CategoryId;

    public Category? Category { get; set; }
}
