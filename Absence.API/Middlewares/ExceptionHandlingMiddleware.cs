using Absence.Domain.Models.Exceptions;
using Absence.API.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Absence.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
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

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            DbUpdateException => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status500InternalServerError
        };

        if (exception is ContextualException contextualException)
        {
            var response = new
            {
                stackTrace = $"{Path.GetFileName(contextualException.ClassName)} at method '{contextualException.MethodName}' at line {contextualException.LineNumber}",
                error = contextualException.InnerException.GetType().Name,
                message = contextualException.InnerException.Message,
                innerMessages = GetInnerMessages(contextualException.InnerException.InnerException)
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        else
        {
            var response = new
            {
                innerMessages = GetInnerMessages(exception)
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

    private static List<string> GetInnerMessages(Exception exception)
    {
        var innerMessages = new List<string>();

        var innerException = exception;

        while (innerException is not null)
        {
            innerMessages.Add(innerException.Message);

            innerException = innerException.InnerException;
        }

        return innerMessages;
    }
}