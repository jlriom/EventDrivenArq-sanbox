namespace Sandbox.Doc.WriteStack.Domain.Documents
{
    public class DocumentStatus
    {
        public static DocumentStatus Draft { get; } = new DocumentStatus(DocumentStatusType.Draft, "Draft");

        public static DocumentStatus Published { get; } = new DocumentStatus(DocumentStatusType.Published, "Published");

        public DocumentStatus(DocumentStatusType id, string name)
        {
            Id = id;
            Name = name;
        }

        public DocumentStatusType Id { get; }
        public string Name { get; }

    }
}
