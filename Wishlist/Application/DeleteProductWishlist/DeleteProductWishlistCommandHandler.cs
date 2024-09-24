using MediatR;
using Microsoft.EntityFrameworkCore;
using Wishlist.Infrastructure.Persistence.EntityFramework;

namespace Wishlist.Application.DeleteProductWishlist;

public class DeleteProductWishlistCommandHandler(WishlistDbContext db)
    : IRequestHandler<DeleteProductWishlistCommand, bool>
{
    public async Task<bool> Handle(DeleteProductWishlistCommand request, CancellationToken cancellationToken)
    {
        var wishlistProduct = await db.Wishlists.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (wishlistProduct is null)
        {
            return false;
        }

        db.Wishlists.Remove(wishlistProduct);
        await db.SaveChangesAsync(cancellationToken);

        return true;
    }
}
