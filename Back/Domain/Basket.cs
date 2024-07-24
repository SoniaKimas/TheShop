using System.Text.Json.Serialization;

namespace Domain;
public class Basket
{
   [JsonPropertyName("basketItems")]
    public List<BasketItem> BasketItems { get; set; }

    [JsonPropertyName("userId")]
    public string UserId { get; set; }
}
