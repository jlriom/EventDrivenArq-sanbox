using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Sandbox.Shared.Api
{
    public static class WebHostEnvironmentExtensions
    {
        public static bool IsAnyDevelopment(this IWebHostEnvironment webHostEnvironment)
        {
            return webHostEnvironment.IsDevelopment() || webHostEnvironment.IsEnvironment(Constants.Environment.NonIntegratedDevelopmentEnvironment);
        }

    }
}
