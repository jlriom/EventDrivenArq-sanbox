using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sandbox.Shared.Api.ErrorHandling.Errors;
using System.Net;

namespace Sandbox.Shared.Api.ErrorHandling
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
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
                        var error = new ErrorFactory().Create(contextFeature);

                        LogError(loggerFactory, error, context);

                        context.Response.StatusCode = error.Status;
                        await context.Response.WriteAsync(error.ToString());
                    }
                });
            });
        }

        private static void LogError(ILoggerFactory loggerFactory, Error error, HttpContext context)
        {
            var logger = loggerFactory.CreateLogger(typeof(IApplicationBuilder));

            logger.LogError("Error Details:\n" +
                            $"{new ExtendedError(error, context)}" +
                            "\n-------");
        }
    }
}