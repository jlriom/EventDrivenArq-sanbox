using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument
{
    public class FailureWhenSendingNotificationDocumentUpdatedEvent : MessageBase<Failure<DocumentDto>>
    {
        public FailureWhenSendingNotificationDocumentUpdatedEvent(Guid correlationId, User user, Failure<DocumentDto> payload) : base(correlationId, user, payload)
        {
        }
    }
}
