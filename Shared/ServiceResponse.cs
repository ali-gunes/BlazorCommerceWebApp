namespace BlazorCommerceWebApp.Shared;

public class ServiceResponse<T>
{
    // Implement a Service Response with Generics
    public T? Data { get; set; }
    public bool? Success { get; set; }
    public string? Message { get; set; }
}