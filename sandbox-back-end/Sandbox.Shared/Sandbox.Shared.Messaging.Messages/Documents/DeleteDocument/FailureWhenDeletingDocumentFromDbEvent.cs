using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument
{
    public class FailureWhenDeletingDocumentFromDbEvent : MessageBase<Failure<Guid>>
    {
        public FailureWhenDeletingDocumentFromDbEvent(Guid correlationId, User user, Failure<Guid> payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
