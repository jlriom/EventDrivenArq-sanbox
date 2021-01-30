using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.UpdateDocument.Activities;
using Sandbox.Shared.Messaging.Messages;
using Sandbox.Shared.Messaging.Messages.Documents;
using Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument;
using Sandbox.Shared.Messaging.RabbitMq.StateMachine;
using System;

namespace Sandbox.Doc.WriteStack.Application.Processes.UpdateDocument
{
    public class UpdateDocumentStateMachine : CommonStateMachine<UpdateDocumentState>
    {
        public State UpdatingDocumentInStorage { get; private set; }
        public State FailureWhenUpdatingDocumentInStorage { get; private set; }
        public State UpdatingDocumentInDb { get; private set; }
        public State FailureWhenUpdatingDocumentInDb { get; private set; }
        public State SendingEmailDocumentUpdated { get; private set; }
        public State FailureWhenSendingEmailDocumentUpdated { get; private set; }
        public State SendingNotificationDocumentUpdated { get; private set; }
        public State FailureWhenSendingNotificationDocumentUpdated { get; private set; }

        public Event<UpdateDocumentCommand> UpdateDocumentCommand { get; private set; }
        public Event<DocumentUpdatedEmailSentEvent> DocumentUpdatedEmailSentEvent { get; private set; }
        public Event<DocumentUpdatedInDbEvent> DocumentUpdatedInDbEvent { get; private set; }
        public Event<DocumentUpdatedInStorageEvent> DocumentUpdatedInStorageEvent { get; private set; }
        public Event<DocumentUpdatedNotificationSentEvent> DocumentUpdatedNotificationSentEvent { get; private set; }
        public Event<FailureWhenSendingEmailDocumentUpdatedEvent> FailureWhenSendingEmailDocumentUpdatedEvent { get; private set; }
        public Event<FailureWhenSendingNotificationDocumentUpdatedEvent> FailureWhenSendingNotificationDocumentUpdatedEvent { get; private set; }
        public Event<FailureWhenUpdatingDocumentInDbEvent> FailureWhenUpdatingDocumentInDbEvent { get; private set; }
        public Event<FailureWhenUpdatingDocumentInStorageEvent> FailureWhenUpdatingDocumentInStorageEvent { get; private set; }


        public UpdateDocumentStateMachine(ILogger<UpdateDocumentState> logger) :
            base(logger,
                new CommonStateMachineEventObserver<UpdateDocumentState>(logger),
                new CommonStateMachineStateChangeObserver<UpdateDocumentState>(logger))
        {

            Initially(
                When(UpdateDocumentCommand)
                    .TransitionTo(UpdatingDocumentInStorage)
                    .Activity(x => x.OfType<UpdateDocumentInStorage>())
                    .Publish(context => new DocumentUpdatedInStorageEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenUpdatingDocumentInStorage)
                            .Publish(context => new FailureWhenUpdatingDocumentInStorageEvent(
                                context.CorrelationId.Value,
                                context.Data.User,
                                new Failure<DocumentDto>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(UpdatingDocumentInStorage,
                When(DocumentUpdatedInStorageEvent)
                    .TransitionTo(UpdatingDocumentInDb)
                    .Activity(x => x.OfType<UpdateDocumentInDb>())
                    .Publish(context => new DocumentUpdatedInDbEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenUpdatingDocumentInDb)
                            .Publish(context => new FailureWhenUpdatingDocumentInDbEvent(
                                context.CorrelationId.Value,
                                context.Data.User,
                                new Failure<DocumentDto>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(UpdatingDocumentInDb,
                When(DocumentUpdatedInDbEvent)
                    .TransitionTo(SendingEmailDocumentUpdated)
                    .Activity(x => x.OfType<SendEmailDocumentUpdated>())
                    .Publish(context => new DocumentUpdatedEmailSentEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenSendingEmailDocumentUpdated)
                            .Publish(context => new FailureWhenSendingEmailDocumentUpdatedEvent(
                                context.CorrelationId.Value,
                                context.Data.User,
                                new Failure<DocumentDto>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(SendingEmailDocumentUpdated,
                When(DocumentUpdatedEmailSentEvent)
                    .TransitionTo(SendingNotificationDocumentUpdated)
                    .Activity(x => x.OfType<SendNotificationDocumentUpdated>())
                    .Publish(context => new DocumentUpdatedNotificationSentEvent(context.CorrelationId.Value, context.Data.User, context.Data.PayLoad))
                    .Catch<Exception>(x =>
                        x.TransitionTo(FailureWhenSendingNotificationDocumentUpdated)
                            .Publish(context => new FailureWhenSendingNotificationDocumentUpdatedEvent(
                                context.CorrelationId.Value,
                                context.Data.User,
                                new Failure<DocumentDto>(context.Data.PayLoad, context.Exception.Message, context.Exception.ToString())))));

            During(SendingNotificationDocumentUpdated,
                When(DocumentUpdatedNotificationSentEvent)
                    .Then(context => Logger.LogInformation($"SUCCESS: {context.Data}"))
                    .TransitionTo(Final));

            During(FailureWhenSendingNotificationDocumentUpdated,
                When(FailureWhenSendingNotificationDocumentUpdatedEvent)
                    .Then( context => Logger.LogError($"{context.Data}")  )
                    .TransitionTo(Final));

            During(FailureWhenSendingEmailDocumentUpdated,
                When(FailureWhenSendingEmailDocumentUpdatedEvent)
                    .Activity(x => x.OfType<FailureWhenSendingEmailDocumentUpdatedNotification>())
                    .TransitionTo(Final));

            During(FailureWhenUpdatingDocumentInDb,
                When(FailureWhenUpdatingDocumentInDbEvent)
                    .Then(context => Logger.LogError($"{context.Data}"))
                    .Activity(x => x.OfType<FailureWhenUpdatingDocumentInDbNotification>())
                    .TransitionTo(Final));

            During(FailureWhenUpdatingDocumentInStorage,
                When(FailureWhenUpdatingDocumentInStorageEvent)
                    .Then(context => Logger.LogError($"{context.Data}"))
                    .Activity(x => x.OfType<FailureWhenUpdatingDocumentInStorageNotification>())
                    .TransitionTo(Final));
        }
    }
}
