using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Sandbox.Shared.Api.Security
{
    public class RateLimiterMiddleware
    {
        private const int Limit = 5;
        private const int Seconds = 30;
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _requestStore;

        public RateLimiterMiddleware(RequestDelegate next, IMemoryCache
            requestStore)
        {
            _next = next;
            _requestStore = requestStore;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestKey = $"{context.Request.Method}-{context.Request.Path}";
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(Seconds)
            };
            if (_requestStore.TryGetValue(requestKey, out int hitCount))
            {
                if (hitCount < Limit)
                {
                    await ProcessRequest(context, requestKey, hitCount,
                        cacheEntryOptions);
                }
                else
                {
                    context.Response.Headers["X-Retry-After"] =
                        cacheEntryOptions.AbsoluteExpiration?.ToString();
                    await context.Response.WriteAsync("Quota exceeded");
                }
            }
            else
            {
                await ProcessRequest(context, requestKey, hitCount,
                    cacheEntryOptions);
            }
        }

        private async Task ProcessRequest(HttpContext context, string
            requestKey, int hitCount, MemoryCacheEntryOptions cacheEntryOptions)
        {
            hitCount++;
            _requestStore.Set(requestKey, hitCount, cacheEntryOptions);
            context.Response.Headers["X-Rate-Limit"] = Limit.ToString();
            context.Response.Headers["X-Rate-Limit-Remaining"] = (Limit - hitCount).ToString();
            await _next(context);
        }
    }
}