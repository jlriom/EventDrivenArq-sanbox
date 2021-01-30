using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Sandbox.Shared.Api.ErrorHandling.Errors
{
    public class ExtendedError : Error
    {
        public ExtendedError(Error error, HttpContext context)
            : base(error)
        {
            UserName = context.User.Identity.IsAuthenticated ? context.User.Identity.Name : string.Empty;
            Url = context.Request.Path.ToString();
        }

        public string UserName { get; }
        public string Url { get; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}