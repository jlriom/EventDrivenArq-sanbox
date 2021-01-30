using Common.Application.Cqs.Contracts;
using Sandbox.Doc.ReadStack.Application.Queries.Dtos;
using System;

namespace Sandbox.Doc.ReadStack.Application.Queries
{
    public class DocumentPropertiesQuery : IQuery<DocumentPropertiesDto>
    {
        public Guid Id { get; }

        public DocumentPropertiesQuery(Guid id)
        {
            Id = id;
        }
    }
}