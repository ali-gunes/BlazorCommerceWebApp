using BlazorCommerceWebApp.Data;
using BlazorCommerceWebApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCommerceWebApp.Services.ProductService;

public class ProductService : IProductService
{
    // Dependency injection for DataContext
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products.ToListAsync(),
            Success = true
        };

        return response;
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
        var response = new ServiceResponse<Product>();
        // Get the specific product from context with FindAsync, it looks for primary key, in this case its ID
        var product = await _context.Products.FindAsync(productId);

        if (product == null)
        {
            response.Success = false;
            response.Message = "No product with the given ID have been found.";
        }
        else
        {
            response.Success = true;
            response.Data = product;
        }

        return response;
    }

    public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
    {
        // Create a new service response, get the products from DB Context and use where statement to match products with the same category url with this method's parameter. Turn everything to list and return the list.
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products
                .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower())).ToListAsync(),
            Success = true
        };

        return response;
    }
}