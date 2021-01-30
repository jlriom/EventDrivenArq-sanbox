using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.CreateDocument
{

    public class DocumentCreatedNotificationSentEvent : MessageBase<DocumentDto>
    {
        public DocumentCreatedNotificationSentEvent(Guid correlationId, User user, DocumentDto payload) : base(correlationId, user, payload)
        {
        }
    }
}
