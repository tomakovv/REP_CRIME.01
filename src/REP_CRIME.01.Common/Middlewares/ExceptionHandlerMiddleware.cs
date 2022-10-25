using Microsoft.AspNetCore.Http;
using REP_CRIME._01.Common.Exceptions;
using System.Net;

namespace REP_CRIME._01.Common.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try { await next.Invoke(context); }
            catch (ResourceNotFoundException resourceNotFoundException)
            {
                await HandleExceptionAsync(context, resourceNotFoundException, HttpStatusCode.NotFound).ConfigureAwait(false);
            }
            catch (ArgumentException argumentException)
            {
                await HandleExceptionAsync(context, argumentException, HttpStatusCode.BadRequest).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception, HttpStatusCode.InternalServerError).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(exception.Message);
        }
    }
}