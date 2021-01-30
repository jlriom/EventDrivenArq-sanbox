using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.CreateDocument
{
    public class FailureWhenSendingEmailDocumentCreatedEvent : MessageBase<Failure<DocumentDto>>
    {
        public FailureWhenSendingEmailDocumentCreatedEvent(Guid correlationId, User user, Failure<DocumentDto> payLoad) : base(correlationId, user, payLoad)
        {
        }
    }

}
