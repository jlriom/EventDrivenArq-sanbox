using System;

namespace Sandbox.Shared.Data.Blob.Core
{
    public class Document
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; }
    }
}
