using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument
{
    public class FailureWhenDeletingDocumentFromStorageEvent : MessageBase<Failure<Guid>>
    {
        public FailureWhenDeletingDocumentFromStorageEvent(Guid correlationId, User user, Failure<Guid> payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
