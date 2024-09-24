using MediatR;
using Wishlist.Domain;
using Wishlist.Infrastructure.Persistence.EntityFramework;

namespace Wishlist.Application.AddProductWishlist;

public class AddProductWishlistCommandHandler(WishlistDbContext dbContext)
    : IRequestHandler<AddProductWishlistCommand, Guid?>
{
    public async Task<Guid?> Handle(AddProductWishlistCommand request, CancellationToken cancellationToken)
    {
        if (request.Quantity == 0)
        {
            return null;
        }

        var wishlistProduct = new WishlistProduct(Guid.NewGuid(), request.ProductId, request.Quantity, request.UserId);

        await dbContext.Wishlists.AddAsync(wishlistProduct, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return wishlistProduct.Id;
    }
}
