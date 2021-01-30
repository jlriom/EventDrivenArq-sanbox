using Common.Core;
using System.Collections.Generic;

namespace Sandbox.Shared.Api.ErrorHandling.Errors
{
    public class ErrorDetailsCollection
    {
        public ErrorDetailsCollection()
        {
            Errors = new List<string>();
        }

        public ErrorDetailsCollection(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; }

        public override string ToString()
        {
            return this.Serialize();
        }
    }
}