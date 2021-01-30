using Common.Core;
using MassTransit.Audit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Sandbox.Shared.Messaging.RabbitMq
{
    public class LoggerMessageAuditStore : IMessageAuditStore
    {
        private readonly ILogger<LoggerMessageAuditStore> _logger;
        public LoggerMessageAuditStore(ILogger<LoggerMessageAuditStore> logger)
        {
            _logger = logger;
        }

        public Task StoreMessage<T>(T message, MessageAuditMetadata metadata) where T : class
        {
            _logger.LogInformation($"CorrelationId: {metadata.CorrelationId} => MessageAudit, Message: {message.Serialize()} , Metadata: {metadata.Serialize()}");
            return Task.CompletedTask;
        }
    }
}
