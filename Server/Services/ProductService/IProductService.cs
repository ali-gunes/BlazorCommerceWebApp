using BlazorCommerceWebApp.Shared;

namespace BlazorCommerceWebApp.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
    }
}