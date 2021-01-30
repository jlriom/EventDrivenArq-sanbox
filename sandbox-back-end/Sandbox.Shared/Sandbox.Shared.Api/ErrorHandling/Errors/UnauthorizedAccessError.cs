using System.Net;

namespace Sandbox.Shared.Api.ErrorHandling.Errors
{
    public class UnauthorizedAccessError : Error
    {
        public UnauthorizedAccessError(string title)
            : base(title, nameof(UnauthorizedAccessError), (int)HttpStatusCode.Unauthorized,
                new ErrorDetailsCollection())
        {
        }
    }
}