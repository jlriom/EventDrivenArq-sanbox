using Common.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Application.Exceptions
{
    [Serializable]
    public class NotFoundException : BaseException
    {
        private const int StatusValue = 404;

        public NotFoundException() : base(nameof(NotFoundException), StatusValue)
        {
        }

        public NotFoundException(string message) : base(nameof(NotFoundException), StatusValue, message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(nameof(NotFoundException),
            StatusValue, message, innerException)
        {
        }

        public NotFoundException(string message, IEnumerable<string> errors)
            : base(nameof(NotFoundException), StatusValue, message, null, errors)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}