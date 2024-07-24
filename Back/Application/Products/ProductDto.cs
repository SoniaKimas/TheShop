namespace Application.Products;
public class ProductDto
{
    public string Id { get; set; }
    public required string Name { get; set; } 
    public required string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public string UnitType { get; set; }
}
