using Automatonymous;
using Microsoft.Extensions.Logging;

namespace Sandbox.Shared.Messaging.RabbitMq.StateMachine
{
    public class CommonStateMachine<T> : MassTransitStateMachine<T> where T : CommonState
    {
        protected readonly ILogger<T> Logger;

        public CommonStateMachine(
            ILogger<T> logger,
            CommonStateMachineEventObserver<T> eventObserver,
            CommonStateMachineStateChangeObserver<T> stateObserver)
        {
            Logger = logger;
            this.ConnectStateObserver(stateObserver);
            this.ConnectEventObserver(eventObserver);

            SetCompletedWhenFinalized();
        }

    }

}
