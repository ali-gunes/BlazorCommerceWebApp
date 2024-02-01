using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCommerceWebApp.Shared;

public class Product
{
    // This is the product model, every product has these attributes including category and category id
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public Category? Category { get; set; }
    public int CategoryId { get; set; }  // This will be useful for Entity Framework Data Seed and Migrations
}