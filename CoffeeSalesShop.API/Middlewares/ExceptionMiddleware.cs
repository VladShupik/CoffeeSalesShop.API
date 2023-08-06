using System.Net;
using Newtonsoft.Json;

namespace CoffeeSalesShop.API.Middlewares;

/// <summary>
/// Exception handler middleware
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var response = new
        {
            ErrorMessage = exception.Message
        };

        string jsonResponse = JsonConvert.SerializeObject(response);

        await context.Response.WriteAsync(jsonResponse);
    }
}