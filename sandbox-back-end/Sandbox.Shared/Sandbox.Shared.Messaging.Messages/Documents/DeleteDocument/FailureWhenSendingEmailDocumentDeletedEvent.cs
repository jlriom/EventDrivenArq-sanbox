using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument
{
    public class FailureWhenSendingEmailDocumentDeletedEvent : MessageBase<Failure<Guid>>
    {
        public FailureWhenSendingEmailDocumentDeletedEvent(Guid correlationId, User user, Failure<Guid> payLoad) : base(correlationId, user, payLoad)
        {
        }
    }

}
