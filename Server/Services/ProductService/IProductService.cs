using BlazorCommerceWebApp.Shared;

namespace BlazorCommerceWebApp.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
    }
}