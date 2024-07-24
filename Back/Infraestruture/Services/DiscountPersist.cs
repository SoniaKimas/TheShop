using Domain;
using Infraestruture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestruture.Services;

public class DiscountPersist(MarketContext context)  : GeneralPersist(context), IDiscountPersist
{
    public async Task<IEnumerable<Discount>> GetActiveDiscounts()
    {
        IQueryable<Discount> query = context.Discounts.Where(d => d.IsActive);
 
        return await query.ToListAsync();
    }
}