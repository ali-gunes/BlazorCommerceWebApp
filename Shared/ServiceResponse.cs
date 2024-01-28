namespace BlazorCommerceWebApp.Shared;

public class ServiceResponse<T>
{
    // Implement a Service Response with Generics aka a response that can be used for every request, it includes data, success status and message
    public T? Data { get; set; }
    public bool? Success { get; set; }
    public string? Message { get; set; }
}