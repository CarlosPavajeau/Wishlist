namespace Wishlist.Domain;

public record WishlistProduct(Guid Id, Product Product, int Quantity, string UserId);
