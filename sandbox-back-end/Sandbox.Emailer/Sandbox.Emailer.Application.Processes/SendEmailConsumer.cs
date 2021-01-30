using Common.Core;
using MassTransit;
using Microsoft.Extensions.Logging;
using Sandbox.Emailer.Core;
using Sandbox.Shared.Messaging.Messages.Emails;
using System;
using System.Threading.Tasks;

namespace Sandbox.Emailer.Application.Processes
{
    public class SendEmailConsumer : IConsumer<SendEmailCommand>
    {
        private readonly ILogger<SendEmailConsumer> _logger;
        private readonly IEmailSender _emailSender;

        public SendEmailConsumer(ILogger<SendEmailConsumer> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task Consume(ConsumeContext<SendEmailCommand> context)
        {
            try
            {
                await _emailSender.SendEmail(context.Message.PayLoad).ConfigureAwait(false);

                await context.Publish(new EmailSentEvent(context.CorrelationId.Value, context.Message.User,
                    context.Message.PayLoad.Id));
            }
            catch (Exception exception)
            {
                var errorDetails = exception.Serialize();
                _logger.LogError(errorDetails);
                await context.Publish(new EmailSentFailureEvent(context.CorrelationId.Value, context.Message.User,
                    new EmailSendingFailure(context.Message.PayLoad.Id, exception.Message, errorDetails)));
            }
        }
    }
}
