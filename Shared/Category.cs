namespace BlazorCommerceWebApp.Shared;

public class Category
{
    // This is our category model
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;  // To specialize the category words
}