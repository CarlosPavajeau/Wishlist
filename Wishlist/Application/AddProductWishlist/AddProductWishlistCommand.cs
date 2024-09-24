using MediatR;

namespace Wishlist.Application.AddProductWishlist;

public record AddProductWishlistCommand(Guid ProductId, int Quantity, string UserId) : IRequest<Guid?>;
