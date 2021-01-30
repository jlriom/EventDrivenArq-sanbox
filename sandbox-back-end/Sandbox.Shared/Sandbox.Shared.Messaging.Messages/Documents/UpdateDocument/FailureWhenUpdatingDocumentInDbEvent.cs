using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.UpdateDocument
{
    public class FailureWhenUpdatingDocumentInDbEvent : MessageBase<Failure<DocumentDto>>
    {
        public FailureWhenUpdatingDocumentInDbEvent(Guid correlationId, User user, Failure<DocumentDto> payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
