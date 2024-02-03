using BlazorCommerceWebApp.Shared;

namespace BlazorCommerceWebApp.Client.Services.ProductService;

public interface IProductService
{
    List<Product> Products { get; set; }
    Task GetProducts(string? categoryUrl = null);
    Task<ServiceResponse<Product>> GetProduct(int productId);
    event Action ProductsChanged;  // We invoke this event whenever the product list is changed
}