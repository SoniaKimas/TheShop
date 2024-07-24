using Domain;

namespace Infraestruture.Services;
public interface IDiscountPersist
{
    public Task<IEnumerable<Discount>> GetActiveDiscounts();
}
