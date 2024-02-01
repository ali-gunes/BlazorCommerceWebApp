using System.Net.Http.Json;
using BlazorCommerceWebApp.Shared;

namespace BlazorCommerceWebApp.Client.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _http;

    public CategoryService(HttpClient http)
    {
        _http = http;
    }

    public List<Category> Categories { get; set; } = new List<Category>();
    
    public async Task GetCategoriesAsync()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");

        if (result is { Data: not null })
            Categories = result.Data;
    }
}