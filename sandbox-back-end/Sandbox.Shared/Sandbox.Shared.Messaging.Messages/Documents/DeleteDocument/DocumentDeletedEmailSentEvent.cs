using Common.Core;
using System;

namespace Sandbox.Shared.Messaging.Messages.Documents.DeleteDocument
{
    public class DocumentDeletedEmailSentEvent : MessageBase<Guid>
    {
        public DocumentDeletedEmailSentEvent(Guid correlationId, User user, Guid payLoad) : base(correlationId, user, payLoad)
        {
        }
    }
}
