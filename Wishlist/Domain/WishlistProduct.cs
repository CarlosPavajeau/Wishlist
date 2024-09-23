using System.ComponentModel.DataAnnotations;

namespace Wishlist.Domain;

public class WishlistProduct(Guid Id, Guid ProductId, int Quantity, string UserId)
{
    public Guid Id { get; init; } = Id;
    public int Quantity { get; init; } = Quantity;
    [MaxLength(128)] public string UserId { get; init; } = UserId;
    public Guid ProductId { get; init; } = ProductId;

    public Product? Product { get; set; }
}
