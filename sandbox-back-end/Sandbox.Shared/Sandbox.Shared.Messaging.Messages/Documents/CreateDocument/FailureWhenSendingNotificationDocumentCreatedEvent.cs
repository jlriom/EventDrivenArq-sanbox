using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.CreateDocument
{
    public class FailureWhenSendingNotificationDocumentCreatedEvent : MessageBase<Failure<DocumentDto>>
    {
        public FailureWhenSendingNotificationDocumentCreatedEvent(Guid correlationId, User user, Failure<DocumentDto> payload) : base(correlationId, user, payload)
        {
        }
    }
}
