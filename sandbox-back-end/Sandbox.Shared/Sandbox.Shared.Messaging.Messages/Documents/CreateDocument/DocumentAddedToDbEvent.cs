using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.CreateDocument
{
    public class DocumentAddedToDbEvent : MessageBase<DocumentDto>
    {
        public DocumentAddedToDbEvent(Guid correlationId, User user, DocumentDto payload) : base(correlationId, user, payload)
        {
        }
    }
}
