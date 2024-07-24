using Application.BasketHandler;
using Domain.Enums;
using Domain;

namespace Tests;
public class DiscountCalculationsTests
{
    private List<Product> products;
    private List<Discount> discounts;

    public DiscountCalculationsTests()
    {
        // Initialize mock products
        products = new List<Product>
            {
                new Product
                {
                    Id = "soup",
                    Name = "Soup",
                    ImageUrl = "soup.jpg",
                    Price = 0.65m,
                    IsAvailable = true,
                    UnitType = UnitType.Default
                },
                new Product
                {
                    Id = "bread",
                    Name = "Bread",
                    ImageUrl = "bread.jpg",
                    Price = 0.80m,
                    IsAvailable = true,
                    UnitType = UnitType.Default
                },
                new Product
                {
                    Id = "milk",
                    Name = "Milk",
                    ImageUrl = "milk.jpg",
                    Price = 1.30m,
                    IsAvailable = true,
                    UnitType = UnitType.Default
                },
                new Product
                {
                    Id = "apple",
                    Name = "Apples Bag",
                    ImageUrl = "apples.jpg",
                    Price = 1.00m,
                    IsAvailable = true,
                    UnitType = UnitType.Bag
                }
            };

        // Initialize mock discounts
        discounts = new List<Discount>
            {
                new Discount
                {
                    Id = 1,
                    Type = DiscountType.Direct,
                    ProductId = "apple",
                    SourceProductId = null,
                    Percentage = 10m,
                    SourceRequiredQuantity = 1,
                    StartDate = DateTime.Now.AddDays(-1),
                    EndDate = DateTime.Now.AddDays(1),
                    IsActive = true
                },
                new Discount
                {
                    Id = 2,
                    Type = DiscountType.Conditional,
                    ProductId = "bread",
                    SourceProductId = "soup",
                    Percentage = 50m,
                    SourceRequiredQuantity = 2,
                    StartDate = new DateTime(2021, 1, 1),
                    EndDate = new DateTime(2021, 12, 31),
                    IsActive = true
                }
            };
    }

    private IEnumerable<BasketItem> GetBasketItems()
    {
        return new List<BasketItem>
            {
                new BasketItem { ProductId = "soup", ProductName = "Soup", ProductPrice = 0.65m, DiscountId = null, Quantity = 6 },
                new BasketItem { ProductId = "milk", ProductName = "Milk", ProductPrice = 1.30m, DiscountId = null, Quantity = 4 },
                new BasketItem { ProductId = "apple", ProductName = "Apples Bag", ProductPrice = 1.00m, DiscountId = 1, Quantity = 2 },
                new BasketItem { ProductId = "bread", ProductName = "Bread", ProductPrice = 0.80m, DiscountId = 2, Quantity = 6 }
            };
    }


    [Fact]
    public void GetReceiptItemsWithConditionalDiscount_ShouldApplyDiscountCorrectly()
    {
        var basketItems = GetBasketItems();
        var discountCalculations = new DiscountCalculations(basketItems, products, discounts);

        var receiptItems = discountCalculations.GetReceiptItemsWithDiscounts().ToList();

        Assert.Equal(5, receiptItems.Count);

        var breadReceiptWithDiscount = receiptItems.FirstOrDefault(r => r.ProductName == "Bread");
        Assert.NotNull(breadReceiptWithDiscount);
        Assert.Equal(0.80m, breadReceiptWithDiscount.ProductPrice);
        Assert.Equal(3, breadReceiptWithDiscount.Quantity);

        var breadReceiptWithoutDiscount = receiptItems.FirstOrDefault(r => r.ProductName == "Bread");
        Assert.NotNull(breadReceiptWithoutDiscount);
        Assert.Equal(0.80m, breadReceiptWithoutDiscount.ProductPrice);
        Assert.Equal(3, breadReceiptWithoutDiscount.Quantity);
    }

    [Fact]
    public void GetReceiptItemsWithoutDiscount_ShouldCalculateTotalWithoutDiscount()
    {
        // Arrange
        var basketItems = new List<BasketItem>
            {
                new BasketItem { ProductId = "milk", ProductName = "Milk", ProductPrice = 1.30m, DiscountId = null, Quantity = 4 }
            };
        var discountCalculations = new DiscountCalculations(basketItems, products, discounts);

        var receiptItems = discountCalculations.GetReceiptItemsWithDiscounts().ToList();

        Assert.Single(receiptItems);
        var milkReceipt = receiptItems[0];
        Assert.Equal("Milk", milkReceipt.ProductName);
        Assert.Equal(1.30m, milkReceipt.ProductPrice);
        Assert.Equal(4, milkReceipt.Quantity);
    }
}
