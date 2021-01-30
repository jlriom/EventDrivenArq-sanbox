using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MassTransit.RabbitMqTransport;

namespace Sandbox.Shared.Messaging.RabbitMq
{
    public class MessagingConfigurationBase : IMessagingConfiguration
    {
        public virtual void AddSagasAction(IServiceCollectionBusConfigurator serviceCollectionBusConfigurator)
        {
        }

        public virtual void AddConsumersAction(IServiceCollectionBusConfigurator serviceCollectionBusConfigurator)
        {
        }

        public virtual void MapEndpointsByConvention()
        {
        }

        public virtual void ConfigureEndPointsAction(IRabbitMqBusFactoryConfigurator rabbitMqBusFactoryConfigurator,
            IBusRegistrationContext busRegistrationContext)
        {
        }
    }
}
