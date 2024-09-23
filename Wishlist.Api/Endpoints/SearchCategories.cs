using MediatR;
using Wishlist.Application.SearchCategories;

namespace Wishlist.Api.Endpoints;

public static class SearchCategories
{
    public static WebApplication MapSearchCategories(this WebApplication app)
    {
        app.MapGet("/categories/search", async (IMediator mediatr, CancellationToken cancellationToken) =>
        {
            var categories = await mediatr.Send(new SearchCategoryQuery(), cancellationToken);

            return Results.Ok(categories);
        });

        return app;
    }
}
