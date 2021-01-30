using Automatonymous;
using Common.Core;
using GreenPipes.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Sandbox.Shared.Messaging.RabbitMq.StateMachine
{
    public class CommonStateMachineEventObserver<T> : EventObserver<T> where T : CommonState
    {
        private readonly ILogger _logger;

        public CommonStateMachineEventObserver(ILogger logger)
        {
            _logger = logger;
        }

        public Task PreExecute(EventContext<T> context)
        {
            _logger.LogInformation($"CorrelationId: {context.Instance.CorrelationId} => In State '{context.Instance.CurrentState.Name}', received Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PreExecute<T1>(EventContext<T, T1> context)
        {
            _logger.LogInformation($"CorrelationId: {context.Instance.CorrelationId} => In State '{context.Instance.CurrentState.Name}', received Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PostExecute(EventContext<T> context)
        {
            _logger.LogInformation($"CorrelationId: {context.Instance.CorrelationId} => In State from '{context.Instance.CurrentState.Name}' , after processing Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PostExecute<T1>(EventContext<T, T1> context)
        {
            _logger.LogInformation($"CorrelationId: {context.Instance.CorrelationId} => In State from '{context.Instance.CurrentState.Name}' , after processing Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task ExecuteFault(EventContext<T> context, Exception exception)
        {
            _logger.LogError($"CorrelationId: {context.Instance.CorrelationId} => State '{context.Instance.CurrentState.Name}', Event '{context.Event.Name}', Error: { exception.Serialize()}");
            return TaskUtil.Completed;
        }

        public Task ExecuteFault<T1>(EventContext<T, T1> context, Exception exception)
        {
            _logger.LogError($"CorrelationId: {context.Instance.CorrelationId} => State '{context.Instance.CurrentState.Name}', Event '{context.Event.Name}', Error: { exception.Serialize()}");
            return TaskUtil.Completed;
        }
    }
}
