using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument
{

    public class DocumentUpdatedNotificationSentEvent : MessageBase<DocumentDto>
    {
        public DocumentUpdatedNotificationSentEvent(Guid correlationId, User user, DocumentDto payload) : base(correlationId, user, payload)
        {
        }
    }
}
