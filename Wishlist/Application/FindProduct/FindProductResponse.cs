namespace Wishlist.Application.FindProduct;

public record FindProductResponse(Guid Id, string Name, string Description, decimal Price)
{
    public string Category { get; set; } = string.Empty;
}
