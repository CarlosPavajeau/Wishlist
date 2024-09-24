using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Application.AddProductWishlist;

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

        return app;
    }
}
