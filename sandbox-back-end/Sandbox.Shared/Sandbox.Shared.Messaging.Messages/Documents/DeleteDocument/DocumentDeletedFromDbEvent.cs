using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument
{
    public class DocumentDeletedFromDbEvent : MessageBase<Guid>
    {
        public DocumentDeletedFromDbEvent(Guid correlationId, User user, Guid payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
