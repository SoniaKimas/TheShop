namespace Application.Discounts;
public class DiscountDto
{
    
    public int Id { get; set; }
    public required string Type { get; set; }
    public required string ProductId { get; set; }
    public string SourceProductId { get; set; }
    public int SourceRequiredQuantity { get; set; }
    public decimal Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
   
}
