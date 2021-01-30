using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument
{
    public class DocumentUpdatedInDbEvent : MessageBase<DocumentDto>
    {
        public DocumentUpdatedInDbEvent(Guid correlationId, User user, DocumentDto payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
