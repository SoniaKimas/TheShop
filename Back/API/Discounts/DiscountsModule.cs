
using Application.Discounts;

namespace API.Discounts;
public class DiscountModule : CarterModule
{
   public override void AddRoutes(IEndpointRouteBuilder app)
   {
        app.MapGet("/discounts", HandleGetDiscounts)
           .WithName("GetDiscounts")
           .WithOpenApi();
    }

   private async Task HandleGetDiscounts(HttpContext context)
   {
       var discountService = context.RequestServices.GetRequiredService<IDiscountService>();

       try
       {
           var discounts = await discountService.GetDiscounts();

           if (discounts == null || !discounts.Any())
           {
               context.Response.StatusCode = StatusCodes.Status404NotFound;
               await context.Response.WriteAsync("Discounts not found.");
               return;
           }

           context.Response.StatusCode = StatusCodes.Status200OK;
           await context.Response.WriteAsJsonAsync(discounts);
       }
       catch (Exception ex)
       {
           context.Response.StatusCode = StatusCodes.Status500InternalServerError;
           await context.Response.WriteAsync($"An error occurred: {ex.Message}");
       }
   }
}