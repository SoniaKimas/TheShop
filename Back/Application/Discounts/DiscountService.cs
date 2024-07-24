
using Infraestruture.Services;

namespace Application.Discounts;

public class DiscountService ( IDiscountPersist discountPersist, IMapper mapper): IDiscountService
{
    public async Task<IEnumerable<DiscountDto>> GetDiscounts()
    {
        try
        {
            var discounts =  await discountPersist.GetActiveDiscounts();

            if (discounts == null) return null;

            return mapper.Map<IEnumerable<DiscountDto>>(discounts);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}