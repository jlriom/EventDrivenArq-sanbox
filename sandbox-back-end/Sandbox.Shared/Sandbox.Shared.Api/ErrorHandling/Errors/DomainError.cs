using System.Net;

namespace Sandbox.Shared.Api.ErrorHandling.Errors
{
    public class DomainError : Error
    {
        public DomainError(string title, ErrorDetailsCollection errors)
            : base(title, nameof(DomainError), (int)HttpStatusCode.Forbidden, errors)
        {
        }
    }
}