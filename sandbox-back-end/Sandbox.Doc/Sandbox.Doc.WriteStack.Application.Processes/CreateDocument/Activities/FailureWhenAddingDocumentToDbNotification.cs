﻿using Automatonymous;
using Microsoft.Extensions.Logging;
using Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Shared.Messaging.Messages.Documents.CreateDocument;
using System.Threading.Tasks;

namespace Sandbox.Doc.WriteStack.Application.Processes.CreateDocument.Activities
{
    public class FailureWhenAddingDocumentToDbNotification : NotificationActivity<FailureWhenAddingDocumentToDbNotification, CreateDocumentState, FailureWhenAddingDocumentToDbEvent>
    {
        public FailureWhenAddingDocumentToDbNotification(
            ILogger<FailureWhenAddingDocumentToDbNotification> logger,
            INotificationProviderFactory notificationProviderFactory
            ) : base(logger, notificationProviderFactory.CreateDocumentHasNotBeenCreatedDueToTechnicalErrorNotification())
        {
        }

        public override Task Execute(BehaviorContext<CreateDocumentState, FailureWhenAddingDocumentToDbEvent> context, Behavior<CreateDocumentState, FailureWhenAddingDocumentToDbEvent> next)
        {
            return Execute(context, next, context.Data.PayLoad.Data.ToDocument());
        }
    }
}
