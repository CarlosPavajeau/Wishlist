using MediatR;

namespace Wishlist.Application.SearchUserWishlist;

public record SearchUserWishlistQuery(string UserId) : IRequest<IEnumerable<WishlistResponse>>;
