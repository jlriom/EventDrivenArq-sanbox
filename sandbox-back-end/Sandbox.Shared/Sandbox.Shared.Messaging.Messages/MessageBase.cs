using Common.Core;
using MassTransit;
using System;

namespace Sandbox.Shared.Messaging.Messages
{
    public abstract class MessageBase<T>
        : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }
        public User User { get; set; }
        public T PayLoad { get; set; }


        protected MessageBase(Guid correlationId, User user, T payLoad)
        {
            CorrelationId = correlationId;
            User = user;
            PayLoad = payLoad;
        }

        protected MessageBase(Guid correlationId, T payLoad) : this(
            correlationId,
            new UserFactory().Create(System.Threading.Thread.CurrentPrincipal),
            payLoad)
        {
        }

        protected MessageBase(T payLoad) : this(
            NewId.NextGuid(),
            new UserFactory().Create(System.Threading.Thread.CurrentPrincipal),
            payLoad)
        {
        }
    }
}
