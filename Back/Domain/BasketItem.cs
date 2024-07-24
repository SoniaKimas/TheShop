using System.Text.Json.Serialization;

namespace Domain;
public class BasketItem
{
    [JsonPropertyName("productId")]
    public string ProductId { get; set; }

    [JsonPropertyName("productName")]
    public string ProductName { get; set; }

    [JsonPropertyName("productPrice")]
    public decimal ProductPrice { get; set; }

    [JsonPropertyName("discountId")]
    public int? DiscountId { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

}
