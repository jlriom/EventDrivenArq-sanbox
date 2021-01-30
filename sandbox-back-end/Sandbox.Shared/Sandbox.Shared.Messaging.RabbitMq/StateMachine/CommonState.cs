using Automatonymous;
using System;

namespace Sandbox.Shared.Messaging.RabbitMq.StateMachine
{
    public class CommonState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State CurrentState { get; set; }
    }
}
