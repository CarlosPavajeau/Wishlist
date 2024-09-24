using MediatR;
using Wishlist.Application.FindProduct;
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

        app.MapGet("/products/{id:guid}", async (IMediator mediatr, Guid id, CancellationToken cancellationToken) =>
        {
            var product = await mediatr.Send(new FindProductQuery(id), cancellationToken);

            return product is null ? Results.NotFound() : Results.Ok(product);
        });

        return app;
    }
}
