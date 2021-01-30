using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.CreateDocument.Activities;
using Sandbox.Shared.Messaging.Messages;
using Sandbox.Shared.Messaging.Messages.Documents;
using Sandbox.Shared.Messaging.Messages.Documents.CreateDocument;
using Sandbox.Shared.Messaging.RabbitMq.StateMachine;
using System;

namespace Sandbox.Doc.WriteStack.Application.Processes.CreateDocument
{
    public class CreateDocumentStateMachine : CommonStateMachine<CreateDocumentState>
    {
        public State AddingDocumentToStorage { get; private set; }
        public State FailureWhenAddingDocumentToStorage { get; private set; }
        public State AddingDocumentToDb { get; private set; }
        public State FailureWhenAddingDocumentToDb { get; private set; }
        public State SendingEmailDocumentCreated { get; private set; }
        public State FailureWhenSendingEmailDocumentCreated { get; private set; }
        public State SendingNotificationDocumentCreated { get; private set; }
        public State FailureWhenSendingNotificationDocumentCreated { get; private set; }

        public Event<CreateDocumentCommand> CreateDocumentCommand { get; private set; }
        public Event<DocumentAddedToDbEvent> DocumentAddedToDbEvent { get; private set; }
        public Event<FailureWhenAddingDocumentToDbEvent> FailureWhenAddingDocumentToDbEvent { get; private set; }
        public Event<DocumentAddedToStorageEvent> DocumentAddedToStorageEvent { get; private set; }
        public Event<FailureWhenAddingDocumentToStorageEvent> FailureWhenAddingDocumentToStorageEvent { get; private set; }
        public Event<DocumentCreatedEmailSentEvent> DocumentCreatedEmailSentEvent { get; private set; }
        public Event<FailureWhenSendingEmailDocumentCreatedEvent> FailureWhenSendingEmailDocumentCreatedEvent { get; private set; }
        public Event<DocumentCreatedNotificationSentEvent> DocumentCreatedNotificationSentEvent { get; private set; }
        public Event<FailureWhenSendingNotificationDocumentCreatedEvent> FailureWhenSendingNotificationDocumentCreatedEvent { get; private set; }


        public CreateDocumentStateMachine(ILogger<CreateDocumentState> logger)
            : base(logger,
                new CommonStateMachineEventObserver<CreateDocumentState>(logger),
                new CommonStateMachineStateChangeObserver<CreateDocumentState>(logger))
        {

            Initially(
                When(CreateDocumentCommand)
                    .TransitionTo(AddingDocumentToStorage)
                    .Activity(x => x.OfType<AddDocumentToStorage>())
                    .Publish(context => new DocumentAddedToStorageEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenAddingDocumentToStorage)
                            .Publish(context => new FailureWhenAddingDocumentToStorageEvent(
                               context.CorrelationId.Value,
                               context.Data.User,
                               new Failure<DocumentDto>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(AddingDocumentToStorage,
                When(DocumentAddedToStorageEvent)
                    .TransitionTo(AddingDocumentToDb)
                    .Activity(x => x.OfType<AddDocumentToDb>())
                    .Publish(context => new DocumentAddedToDbEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenAddingDocumentToDb)
                            .Publish(context => new FailureWhenAddingDocumentToDbEvent(
                                context.CorrelationId.Value,
                                context.Data.User,
                                new Failure<DocumentDto>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(AddingDocumentToDb,
                When(DocumentAddedToDbEvent)
                    .TransitionTo(SendingEmailDocumentCreated)
                    .Activity(x => x.OfType<SendEmailDocumentCreated>())
                    .Publish(context => new DocumentCreatedEmailSentEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenSendingEmailDocumentCreated)
                            .Publish(context => new FailureWhenSendingEmailDocumentCreatedEvent(
                                context.CorrelationId.Value,
                                context.Data.User,
                                new Failure<DocumentDto>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(SendingEmailDocumentCreated,
                When(DocumentCreatedEmailSentEvent)
                    .TransitionTo(SendingNotificationDocumentCreated)
                    .Activity(x => x.OfType<SendNotificationDocumentCreated>())
                    .Publish(context => new DocumentCreatedNotificationSentEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenSendingNotificationDocumentCreated)
                            .Publish(context => new FailureWhenSendingNotificationDocumentCreatedEvent(
                                context.CorrelationId.Value,
                                context.Data.User,
                                new Failure<DocumentDto>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(SendingNotificationDocumentCreated,
                When(DocumentCreatedNotificationSentEvent)
                    .Then(context => Logger.LogInformation($"SUCCESS: {context.Data}"))
                    .TransitionTo(Final));

            During(FailureWhenSendingNotificationDocumentCreated,
                When(FailureWhenSendingNotificationDocumentCreatedEvent)
                    .Then(context => Logger.LogError($"{context.Data}"))
                    .TransitionTo(Final));

            During(FailureWhenSendingEmailDocumentCreated,
                When(FailureWhenSendingEmailDocumentCreatedEvent)
                    .Then(context => Logger.LogError($"{context.Data}"))
                    .Activity(x => x.OfType<FailureWhenSendingEmailDocumentCreatedNotification>())
                    .TransitionTo(Final));

            During(FailureWhenAddingDocumentToDb,
                When(FailureWhenAddingDocumentToDbEvent)
                    .Then(context => Logger.LogError($"{context.Data}"))
                    .Activity(x => x.OfType<FailureWhenAddingDocumentToDbCompensation>())
                    .Activity(x => x.OfType<FailureWhenAddingDocumentToDbNotification>())
                    .TransitionTo(Final));

            During(FailureWhenAddingDocumentToStorage,
                When(FailureWhenAddingDocumentToStorageEvent)
                    .Then(context => Logger.LogError($"{context.Data}"))
                    .Activity(x => x.OfType<FailureWhenAddingDocumentToStorageNotification>())
                    .TransitionTo(Final));
        }
    }
}
