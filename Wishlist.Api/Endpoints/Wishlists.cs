using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Application.AddProductWishlist;
using Wishlist.Application.DeleteProductWishlist;

namespace Wishlist.Api.Endpoints;

public static class Wishlists
{
    public static WebApplication MapWishlists(this WebApplication app)
    {
        app.MapPost("/wishlists",
            async (
                [FromServices] IMediator mediator,
                [FromServices] ILogger<LoggerHelper> logger,
                [FromBody] AddProductWishlistCommand command
            ) =>
            {
                try
                {
                    var result = await mediator.Send(command);

                    return result != null ? Results.Created("/wishlists", result) : Results.BadRequest();
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Error adding product to wishlist");
                    return Results.BadRequest(e.Message);
                }
            });

        app.MapDelete("/wishlists/{id:guid}",
            async (
                [FromServices] IMediator mediator,
                [FromServices] ILogger<LoggerHelper> logger,
                Guid id
            ) =>
            {
                try
                {
                    var result = await mediator.Send(new DeleteProductWishlistCommand(id));

                    return result ? Results.NoContent() : Results.NotFound();
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Error deleting product from wishlist");
                    return Results.BadRequest(e.Message);
                }
            });

        return app;
    }
}
