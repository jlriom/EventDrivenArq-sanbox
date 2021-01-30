using Common.Application.Cqs.Contracts;
using Sandbox.Doc.ReadStack.Application.Queries.Dtos;
using System;

namespace Sandbox.Doc.ReadStack.Application.Queries
{
    public class DocumentContentQuery : IQuery<DocumentContentDto>
    {
        public Guid Id { get; }

        public DocumentContentQuery(Guid id)
        {
            Id = id;
        }
    }
}