using Automatonymous;
using Common.Core;
using GreenPipes;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes
{
    public abstract class DocumentActivity<TActivity, TInstance, TData> : Activity<TInstance, TData>
        where TActivity : Activity<TInstance, TData>
        where TInstance : DocumentState
        where TData : class
    {
        protected readonly ILogger<TActivity> Logger;

        protected DocumentActivity(ILogger<TActivity> logger)
        {
            Logger = logger;
        }

        public void Probe(ProbeContext context)
        {
            context.CreateScope(nameof(TActivity));
        }

        public void Accept(StateMachineVisitor visitor)
        {
            Logger.LogTrace($"Accept");
        }

        public abstract Task Execute(BehaviorContext<TInstance, TData> context, Behavior<TInstance, TData> next);

        public virtual Task Faulted<TException>(BehaviorExceptionContext<TInstance, TData, TException> context, Behavior<TInstance, TData> next) where TException : Exception
        {
            Logger.LogTrace($"Faulted: {context.Serialize()}");
            return next.Faulted(context);
        }
    }
}
