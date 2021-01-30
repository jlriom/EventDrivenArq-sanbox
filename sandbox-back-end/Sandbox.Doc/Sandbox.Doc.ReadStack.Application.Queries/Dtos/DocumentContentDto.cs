using System;

namespace Sandbox.Doc.ReadStack.Application.Queries.Dtos
{
    public class DocumentContentDto
    {
        public Guid Id { get; }
        public byte[] Blob { get; }

        public DocumentContentDto(Guid id, byte[] blob)
        {
            Id = id;
            Blob = blob;
        }
    }
}