using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.CreateDocument
{
    public class DocumentAddedToStorageEvent : MessageBase<DocumentDto>
    {
        public DocumentAddedToStorageEvent(Guid correlationId, User user, DocumentDto payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
