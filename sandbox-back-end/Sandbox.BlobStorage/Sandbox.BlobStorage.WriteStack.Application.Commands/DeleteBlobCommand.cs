using Common.Application.Cqs.Contracts;
using System;

namespace Sandbox.BlobStorage.WriteStack.Application.Commands
{

    public class DeleteBlobCommand : ICommand
    {
        public DeleteBlobCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
