using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using XOLIT.ShoppingCart.Commond;
using XOLIT.ShoppingCart.Domain.Dto;

namespace XOLIT.ShoppingCart.API.Middleware
{
    /// <summary>
    /// manejador de excepciones transversal
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new DetalleErrorDto()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = Mensajes.ErrorExcepcion
                        }.ToString());
                    }
                });
            });
        }
    }
}
