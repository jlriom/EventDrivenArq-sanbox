using System.Threading;
using System.Threading.Tasks;

namespace Common.Application.Cqs.Contracts
{
    public interface IEventHandler
    {
        Task Handle(IEvent @event, CancellationToken cancellationToken = default);
    }
}