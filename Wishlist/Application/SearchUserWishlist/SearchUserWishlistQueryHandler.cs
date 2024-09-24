using MediatR;
using Microsoft.EntityFrameworkCore;
using Wishlist.Infrastructure.Persistence.EntityFramework;

namespace Wishlist.Application.SearchUserWishlist;

public class SearchUserWishlistQueryHandler(WishlistDbContext db)
    : IRequestHandler<SearchUserWishlistQuery, IEnumerable<WishlistResponse>>
{
    public async Task<IEnumerable<WishlistResponse>> Handle(SearchUserWishlistQuery request,
        CancellationToken cancellationToken)
    {
        var wishlists = await db.Wishlists
            .Include(x => x.Product)
            .Where(w => w.UserId == request.UserId)
            .ToListAsync(cancellationToken);

        return wishlists.Select(w => new WishlistResponse(w.Id, w.Product?.Name ?? string.Empty, w.Quantity));
    }
}
