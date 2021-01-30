using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.CreateDocument
{
    public class DocumentCreatedEmailSentEvent : MessageBase<DocumentDto>
    {
        public DocumentCreatedEmailSentEvent(Guid correlationId, User user, DocumentDto payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
