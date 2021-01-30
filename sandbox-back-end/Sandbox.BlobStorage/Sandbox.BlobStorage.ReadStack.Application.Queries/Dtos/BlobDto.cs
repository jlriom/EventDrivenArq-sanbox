using System;

namespace Sandbox.BlobStorage.ReadStack.Application.Queries.Dtos
{
    public class BlobDto
    {
        public Guid Id { get; }
        public byte[] Blob { get; }

        public BlobDto(Guid id, byte[] blob)
        {
            Id = id;
            Blob = blob;
        }
    }
}
