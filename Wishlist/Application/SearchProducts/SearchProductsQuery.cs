using MediatR;

namespace Wishlist.Application.SearchProducts;

public record SearchProductsQuery : IRequest<IEnumerable<ProductResponse>>;
