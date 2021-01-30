using Common.Application.Cqs.Contracts;
using System;

namespace Sandbox.Doc.WriteStack.Application.Commands
{
    public class DeleteDocumentCommand : ICommand
    {
        public DeleteDocumentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}