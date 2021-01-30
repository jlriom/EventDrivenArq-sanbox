using System.Net;

namespace Sandbox.Shared.Api.ErrorHandling.Errors
{
    public class AppError : Error
    {
        public AppError(string title, ErrorDetailsCollection errors)
            : base(title, nameof(AppError), (int)HttpStatusCode.BadRequest, errors)
        {
        }
    }
}