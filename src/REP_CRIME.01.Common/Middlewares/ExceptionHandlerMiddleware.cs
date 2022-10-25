using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var response = JsonConvert.SerializeObject(
                new
                {
                    exception.Message
                });

            return context.Response.WriteAsync(response);
        }
    }
}