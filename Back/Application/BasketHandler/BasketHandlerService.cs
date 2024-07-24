
using Domain;
using Infraestruture.Services;

namespace Application.BasketHandler;
public class BasketHandlerService(
    IProductPersist productPersist,
    IDiscountPersist discountPersist
    ) : IBasketHandlerService
{

    public async Task<Receipt> ProcessBasket( Basket basket)
    {

        if (basket == null || basket.BasketItems == null || basket.BasketItems.Count == 0)
        {
            throw new Exception("Basket is empty.");
        }

        try
        {

            var products = await productPersist.GetAvailableProducts();
            if (products == null || !products.Any())
            {
                throw new Exception("Products not found.");
            }

            var discounts = await discountPersist.GetActiveDiscounts();

            foreach (var item in basket.BasketItems)
            {
                if (products.FirstOrDefault(p => p.Id == item.ProductId) == null)
                {
                    throw new Exception($"Product {item.ProductName} not found.");
                }

                var product = products.FirstOrDefault(p => p.Id == item.ProductId);

                var matchingDiscount = discounts.FirstOrDefault(d => d.ProductId == product.Id);

                if (matchingDiscount != null)
                {
                    if (matchingDiscount.Id != item.DiscountId)
                    {
                        throw new Exception($"Discount {item.DiscountId} not found for product {product.Name}.");
                    }

                }

           }


            var discountCalculator = new DiscountCalculations(
                basket.BasketItems,
                products,
                discounts
                );

            return new Receipt( discountCalculator.GetReceiptItemsWithDiscounts().ToList());
            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}