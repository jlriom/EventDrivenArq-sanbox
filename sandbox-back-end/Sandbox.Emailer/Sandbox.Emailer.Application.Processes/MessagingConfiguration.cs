using GreenPipes;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MassTransit.RabbitMqTransport;
using Sandbox.Shared.Messaging.Messages.Emails;
using Sandbox.Shared.Messaging.RabbitMq;
using System;

namespace Sandbox.Emailer.Application.Processes
{
    public class MessagingConfiguration : MessagingConfigurationBase
    {

        public override void AddConsumersAction(IServiceCollectionBusConfigurator serviceCollectionBusConfigurator)
        {

            serviceCollectionBusConfigurator.AddConsumer<SendEmailConsumer>();
        }

        public override void MapEndpointsByConvention()
        {
            EndpointConvention.Map<SendEmailCommand>(new Uri($"queue:{nameof(SendEmailCommand)}"));
        }

        public override void ConfigureEndPointsAction(
            IRabbitMqBusFactoryConfigurator rabbitMqBusFactoryConfigurator,
            IBusRegistrationContext busRegistrationContext)
        {
            rabbitMqBusFactoryConfigurator.ReceiveEndpoint(
                nameof(SendEmailCommand),
                e =>
                {
                    e.UseMessageRetry(r => r.Immediate(5));
                    e.UseInMemoryOutbox();
                    e.Consumer<SendEmailConsumer>(busRegistrationContext);
                });
        }
    }
}
