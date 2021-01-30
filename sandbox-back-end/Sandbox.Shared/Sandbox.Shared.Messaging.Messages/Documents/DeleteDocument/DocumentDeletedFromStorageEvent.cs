using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument
{
    public class DocumentDeletedFromStorageEvent : MessageBase<Guid>
    {
        public DocumentDeletedFromStorageEvent(Guid correlationId, User user, Guid payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
