using Common.Application.Cqs.Contracts;
using System;

namespace Sandbox.BlobStorage.ReadStack.Application.Queries
{
    public class GetBlobQuery : IQuery<byte[]>
    {
        public Guid Id { get; }

        public GetBlobQuery(Guid id)
        {
            Id = id;
        }
    }
}