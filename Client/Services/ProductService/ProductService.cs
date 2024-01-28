using System.Net.Http.Json;
using BlazorCommerceWebApp.Shared;

namespace BlazorCommerceWebApp.Client.Services.ProductService;

public class ProductService : IProductService
{
    // Dependency injection for HttpClient
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public List<Product> Products { get; set; } = new List<Product>();

    public async Task GetProducts()
    {
        // We want to make our HTTP call in here instead of in the product list component, it's better architecture approach
        // The GetFromJsonAsync method will convert our product model and the data to JSON and request it from backend asynchronously, we write the data type and the route (aka request uri) and let the magic happen!
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
        
        if (result is {Data: not null})
            Products = result.Data; 

    }

    public async Task<ServiceResponse<Product>> GetProduct(int productId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");

        return result;
    }
}