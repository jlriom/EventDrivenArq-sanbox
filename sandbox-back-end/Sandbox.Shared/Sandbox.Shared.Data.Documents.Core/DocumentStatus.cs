using System.Collections.Generic;

namespace Sandbox.Shared.Data.Documents.Core
{
    public partial class DocumentStatus
    {
        public DocumentStatus()
        {
            Document = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Document> Document { get; set; }
    }
}
