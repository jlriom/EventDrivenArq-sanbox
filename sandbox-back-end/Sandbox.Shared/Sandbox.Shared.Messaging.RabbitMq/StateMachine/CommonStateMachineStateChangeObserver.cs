using Automatonymous;
using GreenPipes.Util;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Sandbox.Shared.Messaging.RabbitMq.StateMachine
{
    public class CommonStateMachineStateChangeObserver<T> : StateObserver<T> where T : CommonState
    {
        private readonly ILogger _logger;
        public CommonStateMachineStateChangeObserver(ILogger logger)
        {
            _logger = logger;
        }
        public Task StateChanged(InstanceContext<T> context, State currentState, State previousState)
        {
            string previous = previousState != null ? previousState.Name : "null";
            string current = currentState.Name;
            _logger.LogInformation($"CorrelationId: {context.Instance.CorrelationId} => State Transition from '{previous}' to '{current}'");
            return TaskUtil.Completed;
        }
    }
}
