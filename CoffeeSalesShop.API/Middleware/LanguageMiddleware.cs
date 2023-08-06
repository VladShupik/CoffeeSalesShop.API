namespace CoffeeSalesShop.API.Middleware;

/// <summary>
/// Language handler middleware
/// </summary>
public class LanguageMiddleware
{
    private readonly RequestDelegate _next;

    public LanguageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var userCulture = GetUserPreferredCulture(context);

        if (!string.IsNullOrEmpty(userCulture))
        {
            context.Request.Headers["Accept-Language"] = userCulture;
        }

        await _next(context);
    }

    private static string GetUserPreferredCulture(HttpContext context)
    {
        return "uk-UA"; //TODO When UI Will be created => context.Request.Headers["User-Culture"];
    }
}
