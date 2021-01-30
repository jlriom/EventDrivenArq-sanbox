using Common.Core;
using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System.Threading.Tasks;

namespace Sandbox.Shared.Api.Logging
{
    public class EnrichLogFromContextMiddleware
    {
        private readonly RequestDelegate _next;

        public EnrichLogFromContextMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public Task Invoke(HttpContext context)
        {

            var userId = new UserFactory().Create(System.Threading.Thread.CurrentPrincipal).Id;

            LogContext.PushProperty("UserId", userId);

            LogContext.PushProperty("Host", context.Request.Host.Value);

            LogContext.PushProperty("TraceIdentifier", context.TraceIdentifier);

            return _next(context);
        }
    }
}
