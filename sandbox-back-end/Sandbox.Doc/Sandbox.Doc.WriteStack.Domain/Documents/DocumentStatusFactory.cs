using System;

namespace Sandbox.Doc.WriteStack.Domain.Documents
{
    public static class DocumentStatusFactory
    {
        public static DocumentStatus Create(int id)
        {
            var docstatus = (DocumentStatusType)id;

            switch (docstatus)
            {
                case DocumentStatusType.Published:
                    return DocumentStatus.Published;
                case DocumentStatusType.Draft:
                    return DocumentStatus.Draft;
                default:
                    throw new ArgumentOutOfRangeException($"Document Status with value {id} does not exist");
            }
        }
    }
}
