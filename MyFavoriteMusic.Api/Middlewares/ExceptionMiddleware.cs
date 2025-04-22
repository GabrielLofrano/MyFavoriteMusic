using MyFavoriteMusic.Api.Common;
using System.Text.Json;

namespace MyFavoriteMusic.Api.Middlewares
{
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
                var response = ApiResponse<string>.FailureResponse($"An unexpected error occurred.");

                response.Errors.Add(ex.Message);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                
            }

        }
    }
}
