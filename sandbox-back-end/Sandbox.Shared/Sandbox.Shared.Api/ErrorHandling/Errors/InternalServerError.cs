using System.Net;

namespace Sandbox.Shared.Api.ErrorHandling.Errors
{
    public class InternalServerError : Error
    {
        public InternalServerError(string title)
            : base(title, nameof(InternalServerError), (int)HttpStatusCode.InternalServerError,
                new ErrorDetailsCollection())
        {
        }
    }
}