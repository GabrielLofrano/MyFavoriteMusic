﻿namespace MyFavoriteMusic.Api.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
