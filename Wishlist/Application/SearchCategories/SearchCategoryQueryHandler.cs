using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wishlist.Infrastructure.Persistence.EntityFramework;

namespace Wishlist.Application.SearchCategories;

public class SearchCategoryQueryHandler(WishlistDbContext db)
    : IRequestHandler<SearchCategoryQuery, IEnumerable<CategoryResponse>>
{
    public async Task<IEnumerable<CategoryResponse>> Handle(SearchCategoryQuery request,
        CancellationToken cancellationToken)
    {
        await db.Database.EnsureCreatedAsync(cancellationToken);

        var categories = await db.Categories
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return categories.Adapt<IEnumerable<CategoryResponse>>();
    }
}
