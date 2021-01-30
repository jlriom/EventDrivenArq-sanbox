using Common.Domain;
using System;

namespace Sandbox.Doc.WriteStack.Domain.Documents
{
    public class Document : Entity<Guid>
    {
        public string Name { get; set; }
        public string DocumentName { get; set; }
        public AuditTrack Created { get; set; }
        public AuditTrack Updated { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }

        public Document(Guid id) : base(id)
        {
        }

        protected override void EnsureValidState()
        {
        }
    }
}
