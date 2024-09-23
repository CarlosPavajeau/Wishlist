namespace Wishlist.Domain;

public record Product(Guid Id, string Name, decimal Price, string Description, Category Category);
