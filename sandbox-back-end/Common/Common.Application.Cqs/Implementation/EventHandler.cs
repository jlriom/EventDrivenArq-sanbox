using Common.Application.Cqs.Contracts;
using Common.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Application.Cqs.Implementation
{
    public abstract class EventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
    {
        protected readonly IBus Bus;
        protected readonly ILogger<IEvent> Logger;

        protected EventHandler(IBus bus, ILogger<IEvent> logger)
        {
            Bus = bus;
            Logger = logger;
        }

        public Task Handle(TEvent notification, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Handler Input: {notification.Serialize()}");
            return HandleEx(notification, cancellationToken);
        }

        protected abstract Task HandleEx(TEvent notification, CancellationToken cancellationToken = default);
    }
}