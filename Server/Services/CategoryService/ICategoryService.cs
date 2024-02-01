using BlazorCommerceWebApp.Shared;

namespace BlazorCommerceWebApp.Services.CategoryService;

public interface ICategoryService
{
    Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
}