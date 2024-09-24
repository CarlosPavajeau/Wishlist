using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wishlist.Infrastructure.Persistence.EntityFramework;

namespace Wishlist.Application.FindProduct;

public class FindProductQueryHandler(WishlistDbContext db) : IRequestHandler<FindProductQuery, FindProductResponse?>
{
    public async Task<FindProductResponse?> Handle(FindProductQuery request, CancellationToken cancellationToken)
    {
        var product = await db.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (product is null)
        {
            return null;
        }

        var categoryName = await db.Categories
            .Where(x => x.Id == product.CategoryId)
            .Select(x => x.Name)
            .FirstOrDefaultAsync(cancellationToken);

        var response = product.Adapt<FindProductResponse>();
        response.Category = categoryName ?? string.Empty;

        return response;
    }
}
