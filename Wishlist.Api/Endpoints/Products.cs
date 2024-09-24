using MediatR;
using Wishlist.Application.SearchProducts;

namespace Wishlist.Api.Endpoints;

public static class Products
{
    public static WebApplication MapProducts(this WebApplication app)
    {
        app.MapGet("/products", async (IMediator mediatr, CancellationToken cancellationToken) =>
        {
            var products = await mediatr.Send(new SearchProductsQuery(), cancellationToken);

            return Results.Ok(products);
        });

        return app;
    }
}
