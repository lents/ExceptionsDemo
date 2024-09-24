using System.Net;
using System.Text.Json;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Pass the context to the next middleware in the pipeline
            await _next(context);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError($"Something went wrong: {ex}");
            // Handle the exception by returning a response
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorDetails = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error. Please contact support.",
            Detailed = exception.Message // Can be removed in production for security reasons
        };

        var errorJson = JsonSerializer.Serialize(errorDetails);

        // Write the error response
        return context.Response.WriteAsync(errorJson);
    }
}
