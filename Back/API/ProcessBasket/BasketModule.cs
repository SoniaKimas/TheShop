using Application.BasketHandler;
using Domain;

namespace API.ProcessBasket;

public class BasketModule : CarterModule
{ 
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", HandleProcessBasket)
           .WithName("PostBasket")
           .WithOpenApi(); ;
    }

    private async Task HandleProcessBasket(HttpContext context)
    {
        var basketHandlerService = context.RequestServices.GetRequiredService<IBasketHandlerService>();
        var basket = await context.Request.ReadFromJsonAsync<Basket>();

        try
        {

            var receipt = await basketHandlerService.ProcessBasket(basket);
            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(receipt);
        }
        catch (ArgumentException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new { error = ex.Message });
        }
        catch (Exception ex )
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(
                new { error = "An internal server error occurred. Please try again later."+ex }
                );
        }
    }
}