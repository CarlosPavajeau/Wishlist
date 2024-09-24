using MediatR;

namespace Wishlist.Application.FindProduct;

public record FindProductQuery(Guid Id) : IRequest<FindProductResponse?>;
