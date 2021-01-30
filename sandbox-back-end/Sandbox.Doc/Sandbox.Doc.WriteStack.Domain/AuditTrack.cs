using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Doc.WriteStack.Domain
{
    public class AuditTrack : ValueObject<AuditTrack>
    {
        public Guid UserId { get; }
        public DateTime On { get; }


        public AuditTrack(Guid userId, DateTime on)
        {
            UserId = userId;
            On = on;
        }

        protected override bool EqualsCore(AuditTrack other)
        {
            return UserId == other.UserId && On == other.On;
        }

        protected override int GetHashCodeCore()
        {
            return CombineHashCodes(new object[] { On, UserId });
        }

        private static int CombineHashCodes(IEnumerable<object> objs)
        {
            unchecked
            {
                return objs.Aggregate(17, (current, obj) => current * 59 + (obj?.GetHashCode() ?? 0));
            }
        }

    }
}
