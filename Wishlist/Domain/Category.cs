using System.ComponentModel.DataAnnotations;

namespace Wishlist.Domain;

public class Category(Guid Id, string Name)
{
    public Guid Id { get; init; } = Id;
    [MaxLength(256)] public string Name { get; init; } = Name;
}
