using System.Net;

namespace Sandbox.Shared.Api.ErrorHandling.Errors
{
    public class NotFoundError : Error
    {
        public NotFoundError(string title)
            : base(title, nameof(NotFoundError), (int)HttpStatusCode.NotFound, new ErrorDetailsCollection())
        {
        }

        public NotFoundError(string title, ErrorDetailsCollection errors)
            : base(title, nameof(NotFoundError), (int)HttpStatusCode.NotFound, errors)
        {
        }
    }
}