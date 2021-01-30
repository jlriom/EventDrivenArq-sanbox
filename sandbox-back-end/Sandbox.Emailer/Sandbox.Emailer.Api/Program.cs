using Microsoft.AspNetCore.Hosting;
using Sandbox.Shared.Api;

namespace Sandbox.EMailer.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            new Main().Start(
                webBuilder => { webBuilder.UseStartup<Startup>(); },
                args,
                typeof(Program).Assembly.GetName().Name);
        }
    }
}