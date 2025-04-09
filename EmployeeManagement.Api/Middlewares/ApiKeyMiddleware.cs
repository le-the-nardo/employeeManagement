namespace EmployeeManagement.Api.Middlewares;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string API_KEY_HEADER = "X-Api-Key";
    private readonly string _apiKey;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _apiKey = configuration["ApiKey"];
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value;

        if (path.StartsWith("/swagger") || path.StartsWith("/favicon"))
        {
            await _next(context);
            return;
        }
        
        if (!context.Request.Headers.TryGetValue(API_KEY_HEADER, out var extractedApiKey) ||
            extractedApiKey != _apiKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized - Invalid API Key");
            return;
        }

        await _next(context);
    }
}
