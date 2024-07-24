using Domain.Enums;

namespace Domain;
public class Discount
{
    [Key]
    public int Id { get; set; }
    public required DiscountType Type { get; set; }
    public required string ProductId { get; set; }
    public string SourceProductId { get; set; }
    public int SourceRequiredQuantity { get; set; }
    public decimal Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }

}
