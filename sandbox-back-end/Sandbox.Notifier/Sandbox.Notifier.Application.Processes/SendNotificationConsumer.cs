using MassTransit;
using Sandbox.Shared.Messaging.Messages.Notifications;
using System.Threading.Tasks;

namespace Sandbox.Notifier.Application.Processes
{
    public class SendNotificationConsumer : IConsumer<SendNotificationCommand>
    {
        public async Task Consume(ConsumeContext<SendNotificationCommand> context)
        {
            await Task.CompletedTask;
        }
    }
}
