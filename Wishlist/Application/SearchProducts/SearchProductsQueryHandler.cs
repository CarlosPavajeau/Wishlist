using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wishlist.Infrastructure.Persistence.EntityFramework;

namespace Wishlist.Application.SearchProducts;

public class SearchProductsQueryHandler(WishlistDbContext db)
    : IRequestHandler<SearchProductsQuery, IEnumerable<ProductResponse>>
{
    public async Task<IEnumerable<ProductResponse>> Handle(SearchProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await db.Products.Select(x =>
            new
            {
                x.Id,
                x.Name,
                x.Description,
            }).ToListAsync(cancellationToken);

        return products.Adapt<IEnumerable<ProductResponse>>();
    }
}
