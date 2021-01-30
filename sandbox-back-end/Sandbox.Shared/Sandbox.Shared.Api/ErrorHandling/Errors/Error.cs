using Common.Core;
using System;

namespace Sandbox.Shared.Api.ErrorHandling.Errors
{
    public class Error
    {
        public Error(string title, string type, int status, ErrorDetailsCollection errors)
        {
            TraceId = Guid.NewGuid();
            Title = title;
            Type = type;
            Status = status;
            Errors = errors;
        }

        public Error(Error error) :
            this(error.Title, error.Type, error.Status, error.Errors)
        {
        }

        public string Type { get; }
        public string Title { get; }
        public int Status { get; }
        public Guid TraceId { get; }

        public ErrorDetailsCollection Errors { get; }

        public override string ToString()
        {
            return this.Serialize();
        }
    }
}