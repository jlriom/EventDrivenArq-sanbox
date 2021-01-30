using System;

namespace Sandbox.Doc.ReadStack.Application.Queries.Dtos
{
    public class DocumentPropertiesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DocumentStatusId { get; set; }
        public string DocumentName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}