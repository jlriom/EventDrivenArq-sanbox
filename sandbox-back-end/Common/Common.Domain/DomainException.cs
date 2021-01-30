using Common.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Domain
{
    [Serializable]
    public class DomainException : BaseException
    {
        private const int StatusValue = 400;

        public DomainException() : base(nameof(DomainException), StatusValue)
        {
        }

        public DomainException(string message) : base(nameof(DomainException), StatusValue, message)
        {
        }

        public DomainException(string message, Exception innerException) : base(nameof(DomainException), StatusValue,
            message, innerException)
        {
        }

        public DomainException(string message, IEnumerable<string> errors)
            : base(nameof(DomainException), StatusValue, message, null, errors)
        {
        }

        public DomainException(string message, IEnumerable<BrokenRule> brokenRules)
            : this(message, brokenRules.Select(br => br.Description))
        {
        }


        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}