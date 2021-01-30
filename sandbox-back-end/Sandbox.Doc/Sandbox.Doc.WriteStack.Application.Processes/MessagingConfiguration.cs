using GreenPipes;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MassTransit.RabbitMqTransport;
using Sandbox.Doc.WriteStack.Application.Processes.CreateDocument;
using Sandbox.Doc.WriteStack.Application.Processes.DeleteDocument;
using Sandbox.Doc.WriteStack.Application.Processes.UpdateDocument;
using Sandbox.Shared.Messaging.Messages.Documents.CreateDocument;
using Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument;
using Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument;
using Sandbox.Shared.Messaging.Messages.Emails;
using Sandbox.Shared.Messaging.Messages.Notifications;
using Sandbox.Shared.Messaging.RabbitMq;
using System;

namespace Sandbox.Doc.WriteStack.Application.Processes
{
    public class MessagingConfiguration : MessagingConfigurationBase
    {
        public override void MapEndpointsByConvention()
        {
            EndpointConvention.Map<CreateDocumentCommand>(new Uri($"queue:{nameof(CreateDocumentCommand)}"));
            EndpointConvention.Map<UpdateDocumentCommand>(new Uri($"queue:{nameof(UpdateDocumentCommand)}"));
            EndpointConvention.Map<DeleteDocumentCommand>(new Uri($"queue:{nameof(DeleteDocumentCommand)}"));
            EndpointConvention.Map<SendEmailCommand>(new Uri($"queue:{nameof(SendEmailCommand)}"));
            EndpointConvention.Map<SendNotificationCommand>(new Uri($"queue:{nameof(SendNotificationCommand)}"));
        }

        public override void AddSagasAction(IServiceCollectionBusConfigurator serviceCollectionBusConfigurator)
        {
            serviceCollectionBusConfigurator.AddSagaStateMachine<CreateDocumentStateMachine, CreateDocumentState>()
                .InMemoryRepository();
            serviceCollectionBusConfigurator.AddSagaStateMachine<UpdateDocumentStateMachine, UpdateDocumentState>()
                .InMemoryRepository();
            serviceCollectionBusConfigurator.AddSagaStateMachine<DeleteDocumentStateMachine, DeleteDocumentState>()
                .InMemoryRepository();
        }

        public override void ConfigureEndPointsAction(
            IRabbitMqBusFactoryConfigurator rabbitMqBusFactoryConfigurator, IBusRegistrationContext busRegistrationContext)
        {
            rabbitMqBusFactoryConfigurator.ReceiveEndpoint(nameof(CreateDocumentCommand), e =>
            {
                e.UseMessageRetry(r => r.Immediate(5));
                e.UseInMemoryOutbox();
                e.ConfigureSaga<CreateDocumentState>(busRegistrationContext);
            });

            rabbitMqBusFactoryConfigurator.ReceiveEndpoint(nameof(UpdateDocumentCommand), e =>
            {
                e.UseMessageRetry(r => r.Immediate(5));
                e.UseInMemoryOutbox();
                e.ConfigureSaga<UpdateDocumentState>(busRegistrationContext);
            });

            rabbitMqBusFactoryConfigurator.ReceiveEndpoint(nameof(DeleteDocumentCommand), e =>
            {
                e.UseMessageRetry(r => r.Immediate(5));
                e.UseInMemoryOutbox();
                e.ConfigureSaga<DeleteDocumentState>(busRegistrationContext);
            });
        }
    }
}
