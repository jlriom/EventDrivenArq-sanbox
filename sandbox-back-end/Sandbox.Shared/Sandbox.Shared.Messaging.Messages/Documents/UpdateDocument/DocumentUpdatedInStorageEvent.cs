using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument
{
    public class DocumentUpdatedInStorageEvent : MessageBase<DocumentDto>
    {
        public DocumentUpdatedInStorageEvent(Guid correlationId, User user, DocumentDto payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
