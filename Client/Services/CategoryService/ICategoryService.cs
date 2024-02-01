using BlazorCommerceWebApp.Shared;

namespace BlazorCommerceWebApp.Client.Services.CategoryService;

public interface ICategoryService
{
    List<Category> Categories { get; set; }
    Task GetCategoriesAsync();
}