using Common.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Application.Exceptions
{
    [Serializable]
    public class AppException : BaseException
    {
        private const int StatusValue = 400;

        public AppException() : base(nameof(AppException), StatusValue)
        {
        }

        public AppException(string message) : base(nameof(AppException), StatusValue, message)
        {
        }

        public AppException(string message, Exception innerException) : base(nameof(AppException), StatusValue, message,
            innerException)
        {
        }

        public AppException(string message, IEnumerable<string> errors)
            : base(nameof(AppException), StatusValue, message, null, errors)
        {
        }

        protected AppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}