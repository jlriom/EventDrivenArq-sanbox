using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Notifications;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes
{
    public class NotificationActivity<TActivity, TInstance, TData> : DocumentActivity<TActivity, TInstance, TData>
        where TActivity : Activity<TInstance, TData>
        where TInstance : DocumentState
        where TData : class
    {
        private readonly INotificationProvider _notificationProvider;

        protected NotificationActivity(
            ILogger<TActivity> logger,
            INotificationProvider notificationProvider
            ) : base(logger)
        {
            _notificationProvider = notificationProvider;
        }

        public Task Execute(BehaviorContext<TInstance, TData> context, Behavior<TInstance, TData> next, Document document)
        {
            var notificationDto = new NotificationBuilder()
                .SetNotificationType(_notificationProvider.GetNotificationType())
                .SetTitle(_notificationProvider.GetTitle(document))
                .SetMessage(_notificationProvider.GetMessage(document))
                .Build()
                .ToDto();

            var sendNotificationCommand = new SendNotificationCommand(context.Instance.CorrelationId, notificationDto);
            context.Send(sendNotificationCommand);
            return next.Execute(context);
        }

        public override Task Execute(BehaviorContext<TInstance, TData> context, Behavior<TInstance, TData> next)
        {
            return next.Execute(context);
        }
    }
}