using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument
{
    public class FailureWhenSendingEmailDocumentUpdatedEvent : MessageBase<Failure<DocumentDto>>
    {
        public FailureWhenSendingEmailDocumentUpdatedEvent(Guid correlationId, User user, Failure<DocumentDto> payLoad) : base(correlationId, user, payLoad)
        {
        }
    }

}
