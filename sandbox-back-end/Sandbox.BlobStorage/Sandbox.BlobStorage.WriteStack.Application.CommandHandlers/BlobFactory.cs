using Sandbox.BlobStorage.WriteStack.Application.Commands;
using Sandbox.BlobStorage.WriteStack.Domain;

namespace Sandbox.BlobStorage.WriteStack.Application.CommandHandlers
{
    public static class BlobFactory
    {
        public static Blob CreateFromCommand(CreateBlobCommand command)
        {
            return new Blob
            {
                Id = command.Id,
                Content = command.Blob
            };
        }

        public static Blob CreateFromCommand(UpdateBlobCommand command)
        {
            return new Blob
            {
                Id = command.Id,
                Content = command.Blob
            };
        }

        public static Blob CreateFromCommand(DeleteBlobCommand command)
        {
            return new Blob
            {
                Id = command.Id,
                Content = null
            };
        }

    }
}
