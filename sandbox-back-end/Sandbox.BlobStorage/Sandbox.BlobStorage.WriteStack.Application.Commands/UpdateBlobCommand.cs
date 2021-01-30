using Common.Application.Cqs.Contracts;
using System;

namespace Sandbox.BlobStorage.WriteStack.Application.Commands
{

    public class UpdateBlobCommand : ICommand
    {
        public UpdateBlobCommand(Guid id, byte[] blob)
        {
            Id = id;
            Blob = blob;
        }

        public Guid Id { get; }
        public byte[] Blob { get; }
    }
}
