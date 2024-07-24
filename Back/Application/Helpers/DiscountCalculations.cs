using Domain;
using Domain.Enums;

namespace Application.BasketHandler;

public  class DiscountCalculations
{
    private readonly IEnumerable<Product> products;
    private readonly IEnumerable<Discount> discounts;
    private List<ReceiptItem> receiptItems = new();
    private List<BasketItem> distinctItemsList = new();
    public DiscountCalculations(
        IEnumerable<BasketItem> basketItems,
        IEnumerable<Product> products,
        IEnumerable<Discount> discounts
        )
    {
        this.products = products;
        this.discounts = discounts;
        InitializeListDistinct( basketItems);
    }


    public IEnumerable<ReceiptItem> GetReceiptItemsWithDiscounts() {

        foreach (var item in distinctItemsList)
        {
            if (!item.DiscountId.HasValue)
            {
                receiptItems.Add(
                    new ReceiptItem(
                        item.ProductName,
                        products.FirstOrDefault(p => p.Id == item.ProductId).Price,
                        item.Quantity,
                        null
                        )
                    );
            }
            else{ 
                var discount = discounts.FirstOrDefault(d => d.Id == item.DiscountId);
                if(discount.Type == DiscountType.Direct)
                {
                    receiptItems.Add(
                        new ReceiptItem(
                            item.ProductName,
                            products.FirstOrDefault(p => p.Id == item.ProductId).Price,
                            item.Quantity,
                            discount.Percentage
                            )
                        );
                }
                else
                {
                    var sourceProductQty = distinctItemsList.FirstOrDefault(x => x.ProductId == discount.SourceProductId)?.Quantity ?? 0;
                    var productQty = item.Quantity;

                    if (sourceProductQty >= discount.SourceRequiredQuantity)
                    {
                        var supportedQty = sourceProductQty / discount.SourceRequiredQuantity;
                        productQty = productQty - supportedQty;

                        receiptItems.Add(
                            new ReceiptItem(
                                item.ProductName,
                                products.FirstOrDefault(p => p.Id == item.ProductId).Price,
                                supportedQty,
                                discount.Percentage
                                )
                            );
                         
                    }

                    if (productQty > 0)
                    {
                        receiptItems.Add(
                            new ReceiptItem(
                                item.ProductName,
                                products.FirstOrDefault(p => p.Id == item.ProductId).Price,
                                productQty,
                                null
                                )
                            );
                    }

                }
        
            }

        }

        return receiptItems;
    }

    private void InitializeListDistinct(IEnumerable<BasketItem> basketItems)
    {
        foreach (var item in basketItems)
        {
            var existingItem = distinctItemsList.FirstOrDefault(x => x.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                distinctItemsList.Add(item);
            }
        }
    }
}
