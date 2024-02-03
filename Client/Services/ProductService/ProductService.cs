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

    public async Task GetProducts(string? categoryUrl)
    {
        // We want to make our HTTP call in here instead of in the product list component, it's better architecture approach
        
        // The GetFromJsonAsync method will convert our product model and the data to JSON and request it from backend asynchronously, we write the data type and the route (aka request uri) and let the magic happen!
        
        // We added category url to get products method, if it's null we just return the all products, if it's not null we return the specific products that related to category. We do this with ternary condition.
        var result = categoryUrl == null ? await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product") : await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/Category/{categoryUrl}");
        
        if (result is {Data: not null})
            Products = result.Data; 
        
        // We invoke our action event here, when we do this every component that is subscribed to this method will know something has changed
        // If we don't invoke this, nothing changes with the product list on the client
        ProductsChanged.Invoke();

    }

    public async Task<ServiceResponse<Product>> GetProduct(int productId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");

        return result;
    }

    public event Action ProductsChanged;
}