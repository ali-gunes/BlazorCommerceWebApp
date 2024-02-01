using BlazorCommerceWebApp.Data;
using BlazorCommerceWebApp.Services.CategoryService;
using BlazorCommerceWebApp.Services.ProductService;
using BlazorCommerceWebApp.Shared;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace BlazorCommerceWebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        // Add swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Let's say we created another product service for testing purposes and we want to use ProductService2 for that, instead of changing the code in the controller, we can just change the below lines ProductService, that way whenever we use dependency injection, IProductService implements our mock ProductService for test. This is a really useful and handy trick.
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        
        var app = builder.Build();

        app.UseSwaggerUI();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseSwagger();
        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();


        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.Run();
    }
}

