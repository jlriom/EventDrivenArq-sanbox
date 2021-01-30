using Common.Application.Cqs.Contracts;

namespace Sandbox.Doc.WriteStack.Application.Commands
{
    public class DocumentCommandBase : ICommand
    {
        public string Name { get; }
        public int DocumentStatusId { get; }

        public DocumentCommandBase(
            string name,
            int documentStatusId)
        {
            Name = name;
            DocumentStatusId = documentStatusId;
        }
    }
}
