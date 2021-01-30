using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument
{
    public class DocumentUpdatedEmailSentEvent : MessageBase<DocumentDto>
    {
        public DocumentUpdatedEmailSentEvent(Guid correlationId, User user, DocumentDto payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
