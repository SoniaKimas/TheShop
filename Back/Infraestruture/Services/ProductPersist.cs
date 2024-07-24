using Domain;
using Infraestruture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestruture.Services;

public class ProductPersist(MarketContext context) : GeneralPersist(context), IProductPersist
{
    public async  Task<IEnumerable<Product>> GetAvailableProducts()
    {
        IQueryable<Product> query = context.Products.Where(p => p.IsAvailable);
 
        return await query.ToListAsync();
    }
}