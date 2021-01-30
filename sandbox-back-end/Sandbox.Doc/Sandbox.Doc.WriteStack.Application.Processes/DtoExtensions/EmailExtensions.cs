using Sandbox.Doc.WriteStack.Domain.Emails;
using Sandbox.Shared.Messaging.Messages.Emails;

namespace Sandbox.Doc.WriteStack.Application.Processes.DtoExtensions
{
    public static class EmailExtensions
    {
        public static Email ToDocument(this EmailDto emailDto)
        {
            return new Email
            {
                To = emailDto.To,
                Cc = emailDto.Cc,
                Subject = emailDto.Subject,
                Body = emailDto.Body,
                Id = emailDto.Id
            };
        }

        public static EmailDto ToDto(this Email email)
        {
            return new EmailDto
            {
                To = email.To,
                Cc = email.Cc,
                Subject = email.Subject,
                Body = email.Body,
                Id = email.Id
            };
        }

    }
}
