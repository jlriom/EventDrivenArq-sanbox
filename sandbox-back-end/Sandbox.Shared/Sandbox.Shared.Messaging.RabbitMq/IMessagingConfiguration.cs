using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MassTransit.RabbitMqTransport;

namespace Sandbox.Shared.Messaging.RabbitMq
{
    public interface IMessagingConfiguration
    {
        void AddSagasAction(IServiceCollectionBusConfigurator serviceCollectionBusConfigurator);
        void AddConsumersAction(IServiceCollectionBusConfigurator serviceCollectionBusConfigurator);

        void MapEndpointsByConvention();

        void ConfigureEndPointsAction(
            IRabbitMqBusFactoryConfigurator rabbitMqBusFactoryConfigurator, IBusRegistrationContext busRegistrationContext);
    }
}
