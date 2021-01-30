using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument
{

    public class DocumentDeletedNotificationSentEvent : MessageBase<Guid>
    {
        public DocumentDeletedNotificationSentEvent(Guid correlationId, User user, Guid payload) : base(correlationId, user, payload)
        {
        }
    }
}
