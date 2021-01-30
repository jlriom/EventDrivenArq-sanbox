using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sandbox.Shared.Api.Security
{
    public class ThreadPrincipalMiddleware
    {
        private readonly RequestDelegate _next;

        public ThreadPrincipalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var claims = context.User.Claims.Union(new List<Claim>
                {
                    new Claim("token", context.Request.Headers["Authorization"])
                });
                var identity = new ClaimsIdentity(claims, "Federation");
                var principal = new ClaimsPrincipal(identity);

                System.Threading.Thread.CurrentPrincipal = principal;
            }
            else
            {
                System.Threading.Thread.CurrentPrincipal = context.User;
            }
            await _next(context);
        }
    }
}