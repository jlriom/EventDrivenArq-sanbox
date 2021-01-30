using System;

namespace Sandbox.BlobStorage.Api.Dtos
{
    public class CreateBlobRequestDto
    {
        public Guid Id { get; set; }
        public byte[] Blob { get; set; }
    }
}
