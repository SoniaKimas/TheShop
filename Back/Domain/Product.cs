using Domain.Enums;

namespace Domain;
public class Product
{
    [Key]
    public string Id { get; set; }
    public required string Name { get; set; } 
    public required string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public UnitType UnitType { get; set; }
    
}

