using Common.Application.Cqs.Contracts;
using Common.Core;
using MediatR;
using System.Threading;

namespace Common.Application.Cqs.Implementation
{
    public class Bus : IBus
    {
        protected readonly IMediator Mediator;

        public Bus(IMediator mediator)
        {
            Mediator = mediator;
        }

        public User User => new UserFactory().Create(Thread.CurrentPrincipal);

        public void Publish(IEvent @event)
        {
            Mediator.Publish(@event);
        }
    }
}