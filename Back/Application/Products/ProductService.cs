using Infraestruture.Services;

namespace Application.Products;
public class ProductService(IProductPersist productPersist, IMapper mapper) : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        try
        {
            var products =  await productPersist.GetAvailableProducts();

            if (products == null) return null;

            return mapper.Map<IEnumerable<ProductDto>>(products);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
      
    }
}
