using GreenPipes;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MassTransit.RabbitMqTransport;
using Sandbox.Shared.Messaging.Messages.Notifications;
using Sandbox.Shared.Messaging.RabbitMq;
using System;

namespace Sandbox.Notifier.Application.Processes
{
    public class MessagingConfiguration : MessagingConfigurationBase
    {

        public override void AddConsumersAction(IServiceCollectionBusConfigurator serviceCollectionBusConfigurator)
        {
            serviceCollectionBusConfigurator.AddConsumer<SendNotificationConsumer>();
        }

        public override void MapEndpointsByConvention()
        {
            EndpointConvention.Map<SendNotificationCommand>(new Uri($"queue:{nameof(SendNotificationCommand)}"));
        }

        public override void ConfigureEndPointsAction(
            IRabbitMqBusFactoryConfigurator rabbitMqBusFactoryConfigurator,
            IBusRegistrationContext busRegistrationContext)
        {
            rabbitMqBusFactoryConfigurator.ReceiveEndpoint(
                nameof(SendNotificationCommand),
                e =>
                {
                    e.UseMessageRetry(r => r.Immediate(5));
                    e.UseInMemoryOutbox();
                    e.Consumer<SendNotificationConsumer>(busRegistrationContext);
                });
        }
    }
}
