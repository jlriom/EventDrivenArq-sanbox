using Common.Core;

namespace Common.Application.Cqs.Contracts
{
    public interface IBus
    {
        User User { get; }

        void Publish(IEvent @event);
    }
}