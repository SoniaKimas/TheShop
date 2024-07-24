using System.Diagnostics.Contracts;

namespace Domain;

public class ReceiptItem
{
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal PriceAfterDiscount { get; set; }
    public decimal ItemTotalPrice { get; set; }
    public int Quantity { get; set; }
    public decimal? Discount { get; set; }
    public ReceiptItem(string productName, decimal productPrice, int quantity, decimal? discount)
    {
        ProductName = productName;
        ProductPrice = productPrice;
        Quantity = quantity;
        Discount = discount;
        PriceAfterDiscount = Math.Round(productPrice * (1 - discount * 0.01m) ?? productPrice, 2, MidpointRounding.AwayFromZero);
        ItemTotalPrice = PriceAfterDiscount * quantity;
    }

}