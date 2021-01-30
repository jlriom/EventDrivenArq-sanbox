using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DeleteDocument.Activities;
using Sandbox.Shared.Messaging.Messages;
using Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument;
using Sandbox.Shared.Messaging.RabbitMq.StateMachine;
using System;

namespace Sandbox.Doc.WriteStack.Application.Processes.DeleteDocument
{
    public class DeleteDocumentStateMachine : CommonStateMachine<DeleteDocumentState>

    {
        public State DeletingDocumentFromStorage { get; private set; }
        public State FailureWhenDeletingDocumentFromStorage { get; private set; }
        public State DeletingDocumentFromDb { get; private set; }
        public State FailureWhenDeletingDocumentFromDb { get; private set; }
        public State SendingEmailDocumentDeleted { get; private set; }
        public State FailureWhenSendingEmailDocumentDeleted { get; private set; }
        public State SendingNotificationDocumentDeleted { get; private set; }
        public State FailureWhenSendingNotificationDocumentDeleted { get; private set; }

        public Event<DeleteDocumentCommand> DeleteDocumentCommand { get; private set; }
        public Event<DocumentDeletedEmailSentEvent> DocumentDeletedEmailSentEvent { get; private set; }
        public Event<DocumentDeletedFromDbEvent> DocumentDeletedFromDbEvent { get; private set; }
        public Event<DocumentDeletedFromStorageEvent> DocumentDeletedFromStorageEvent { get; private set; }
        public Event<DocumentDeletedNotificationSentEvent> DocumentDeletedNotificationSentEvent { get; private set; }
        public Event<FailureWhenDeletingDocumentFromDbEvent> FailureWhenDeletingDocumentFromDbEvent { get; private set; }
        public Event<FailureWhenDeletingDocumentFromStorageEvent> FailureWhenDeletingDocumentFromStorageEvent { get; private set; }
        public Event<FailureWhenSendingEmailDocumentDeletedEvent> FailureWhenSendingEmailDocumentDeletedEvent { get; private set; }
        public Event<FailureWhenSendingNotificationDocumentDeletedEvent> FailureWhenSendingNotificationDocumentDeletedEvent { get; private set; }


        public DeleteDocumentStateMachine(ILogger<DeleteDocumentState> logger) :
            base(logger,
                new CommonStateMachineEventObserver<DeleteDocumentState>(logger),
                new CommonStateMachineStateChangeObserver<DeleteDocumentState>(logger))
        {

            Initially(
                When(DeleteDocumentCommand)
                    .TransitionTo(DeletingDocumentFromStorage)
                    .Activity(x => x.OfType<DeleteDocumentFromStorage>())
                    .Publish(context => new DocumentDeletedFromStorageEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenDeletingDocumentFromStorage)
                            .Publish(context => new FailureWhenDeletingDocumentFromStorageEvent(
                                context.CorrelationId.Value,
                                context.Data.User,
                                new Failure<Guid>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(DeletingDocumentFromStorage,
                When(DocumentDeletedFromStorageEvent)
                    .TransitionTo(DeletingDocumentFromDb)
                    .Activity(x => x.OfType<DeleteDocumentFromDb>())
                    .Publish(context => new DocumentDeletedFromDbEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenDeletingDocumentFromDb)
                            .Publish(context => new FailureWhenDeletingDocumentFromDbEvent(
                                context.CorrelationId.Value,
                                context.Data.User,
                                new Failure<Guid>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(DeletingDocumentFromDb,
                When(DocumentDeletedFromDbEvent)
                    .TransitionTo(SendingEmailDocumentDeleted)
                    .Activity(x => x.OfType<SendEmailDocumentDeleted>())
                    .Publish(context => new DocumentDeletedEmailSentEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenSendingEmailDocumentDeleted)
                            .Publish(context => new FailureWhenSendingEmailDocumentDeletedEvent(
                                context.CorrelationId.Value,
                                context.Data.User,
                                new Failure<Guid>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(SendingEmailDocumentDeleted,
                When(DocumentDeletedEmailSentEvent)
                    .TransitionTo(SendingNotificationDocumentDeleted)
                    .Activity(x => x.OfType<SendNotificationDocumentDeleted>())
                    .Publish(context => new DocumentDeletedNotificationSentEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenSendingNotificationDocumentDeleted)
                            .Publish(context => new FailureWhenSendingNotificationDocumentDeletedEvent(
                                context.CorrelationId.Value,
                                context.Data.User,
                                new Failure<Guid>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(SendingNotificationDocumentDeleted,
                When(DocumentDeletedNotificationSentEvent)
                    .Then(context => Logger.LogInformation($"SUCCESS: {context.Data}"))
                    .TransitionTo(Final));

            During(FailureWhenSendingNotificationDocumentDeleted,
                When(FailureWhenSendingNotificationDocumentDeletedEvent)
                    .Then(context => Logger.LogError($"{context.Data}"))
                    .TransitionTo(Final));

            During(FailureWhenSendingEmailDocumentDeleted,
                When(FailureWhenSendingEmailDocumentDeletedEvent)
                    .Then(context => Logger.LogError($"{context.Data}"))
                    .Activity(x => x.OfType<FailureWhenSendingEmailDocumentDeletedNotification>())
                    .TransitionTo(Final));

            During(FailureWhenDeletingDocumentFromDb,
                When(FailureWhenDeletingDocumentFromDbEvent)
                    .Then(context => Logger.LogError($"{context.Data}"))
                    .Activity(x => x.OfType<FailureWhenDeletingDocumentFromDbNotification>())
                    .TransitionTo(Final));

            During(FailureWhenDeletingDocumentFromStorage,
                When(FailureWhenDeletingDocumentFromStorageEvent)
                    .Then(context => Logger.LogError($"{context.Data}"))
                    .Activity(x => x.OfType<FailureWhenDeletingDocumentFromStorageNotification>())
                    .TransitionTo(Final));
        }
    }
}
