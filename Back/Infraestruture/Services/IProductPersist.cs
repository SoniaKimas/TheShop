using Domain;


namespace Infraestruture.Services;

public interface IProductPersist
{
    Task<IEnumerable<Product>> GetAvailableProducts();
}


