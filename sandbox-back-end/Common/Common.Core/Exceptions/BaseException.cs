using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Exceptions
{
    [Serializable]
    public abstract class BaseException : ApplicationException
    {
        protected BaseException(string type, int status)
        {
            Type = type;
            Status = status;
        }

        protected BaseException(string type, int status, string message) : base(message)
        {
            Type = type;
            Status = status;
            Title = message;
        }

        protected BaseException(string type, int status, string message, Exception innerException) : base(message,
            innerException)
        {
            Type = type;
            Status = status;
            Title = message;
            Detail = innerException?.Message;
            Instance = innerException?.ToString();
        }

        protected BaseException(string type, int status, string message, Exception innerException,
            IEnumerable<string> errors)
            : this(type, status, message, innerException)
        {
            Errors = errors;
        }

        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string Type { get; set; }
        public string Title { get; }
        public int Status { get; set; }
        public string Detail { get; }
        public string Instance { get; }

        public IEnumerable<string> Errors { get; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("Type", Type);
            info.AddValue("Title", Title);
            info.AddValue("Status", Status);
            info.AddValue("Detail", Detail);
            info.AddValue("Instance", Instance);

            base.GetObjectData(info, context);
        }
    }
}