using CigarBase.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace CigarBase.Infrastructure.Exceptions;

internal sealed class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            await HandleExceptionAsync(exception, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        var (statusCode, error) = exception switch
        {
            CustomException => (StatusCodes.Status400BadRequest, new Error(exception.GetType().Name, exception.Message)),
            _ => (StatusCodes.Status500InternalServerError, new Error("error", "Please try again later."))
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(error);
    }

    private record Error(string Code, string Reason);
}