using CSharpFunctionalExtensions;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Application.Cqs.Contracts
{
    public interface ICommandDispatcher : IBus
    {
        Task<Result> Dispatch(ICommand command, CancellationToken cancellationToken = default);
    }
}