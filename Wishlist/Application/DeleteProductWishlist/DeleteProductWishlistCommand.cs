using MediatR;

namespace Wishlist.Application.DeleteProductWishlist;

public record DeleteProductWishlistCommand(Guid Id) : IRequest<bool>;
