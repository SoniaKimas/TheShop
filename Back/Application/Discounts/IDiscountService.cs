namespace Application.Discounts;

public interface IDiscountService
{
    public Task<IEnumerable<DiscountDto>> GetDiscounts();
    
}
