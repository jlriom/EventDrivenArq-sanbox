using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Sandbox.Idp.Areas.Identity.IdentityHostingStartup))]
namespace Sandbox.Idp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}