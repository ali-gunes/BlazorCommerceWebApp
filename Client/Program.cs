using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorCommerceWebApp.Client;
using BlazorCommerceWebApp.Client.Services.ProductService;

namespace BlazorCommerceWebApp.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        
        // Let's say we created another product service for testing purposes and we want to use ProductService2 for that, instead of changing the code in the controller, we can just change the below lines ProductService, that way whenever we use dependency injection, IProductService implements our mock ProductService for test. This is a really useful and handy trick.
        builder.Services.AddScoped<IProductService, ProductService>();

        await builder.Build().RunAsync();
    }
}

