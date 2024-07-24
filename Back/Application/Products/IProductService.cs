namespace Application.Products;
public interface IProductService
{
    public Task<IEnumerable<ProductDto>> GetProducts();
}
