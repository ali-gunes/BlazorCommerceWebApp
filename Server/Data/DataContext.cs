using BlazorCommerceWebApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCommerceWebApp.Data;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
        
    
    
}