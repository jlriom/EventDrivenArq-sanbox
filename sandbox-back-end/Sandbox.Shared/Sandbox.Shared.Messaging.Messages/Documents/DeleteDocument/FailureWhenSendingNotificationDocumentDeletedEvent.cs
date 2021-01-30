using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument
{
    public class FailureWhenSendingNotificationDocumentDeletedEvent : MessageBase<Failure<Guid>>
    {
        public FailureWhenSendingNotificationDocumentDeletedEvent(Guid correlationId, User user, Failure<Guid> payload) : base(correlationId, user, payload)
        {
        }
    }
}
