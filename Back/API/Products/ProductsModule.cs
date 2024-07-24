namespace API.Products;
public class ProductsModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", HandleGetProducts)
           .WithName("GetProducts")
           .WithOpenApi(); ;
    }

    private async Task HandleGetProducts(HttpContext context)
    {
        var productService = context.RequestServices.GetRequiredService<IProductService>();

        try
        {
            var products = await productService.GetProducts();

            if (products == null || !products.Any())
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Products not found.");
                return;
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(products);
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync($"An error occurred: {ex.Message}");
        }
    }
}