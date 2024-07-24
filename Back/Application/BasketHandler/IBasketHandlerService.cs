using Domain;

namespace Application.BasketHandler;
public interface IBasketHandlerService
{
    public Task<Receipt> ProcessBasket(Basket basket);
}
