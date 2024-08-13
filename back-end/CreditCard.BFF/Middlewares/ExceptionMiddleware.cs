using System.Net;
using System.Text.Json;
using CreditCard.Proposals.BFF.CrossCutting.CQRS;
using CreditCard.Proposals.BFF.DTOs.Responses.Common;

namespace CreditCard.Proposals.BFF.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {

        var result = JsonSerializer.Serialize(new BaseResponse<View>("Server error.", HttpStatusCode.InternalServerError));
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
        return context.Response.WriteAsync(result);
    }
}