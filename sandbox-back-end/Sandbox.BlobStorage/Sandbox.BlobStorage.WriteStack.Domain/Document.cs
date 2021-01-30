using System;

namespace Sandbox.BlobStorage.WriteStack.Domain
{
    public class Blob
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; }
    }
}
