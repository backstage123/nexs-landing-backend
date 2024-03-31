using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) => _logger = logger;
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("-----Inside Middleware-----");

                _logger.LogError(ex, ex.Message);
                System.Diagnostics.Debug.WriteLine(ex);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server Error",
                    Title = "Internal Server Error",
                    Detail = $"A server error has occurred. Please try again. Contact the support team if the error persists. ex: {ex}"
                };

                string json = JsonSerializer.Serialize(problem);

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);             
            }
        }
    }
}
