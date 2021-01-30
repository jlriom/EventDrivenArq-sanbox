using Sandbox.Shared.Messaging.Messages.Emails;
using System.Threading.Tasks;

namespace Sandbox.Emailer.Core
{
    public interface IEmailSender
    {
        Task SendEmail(EmailDto email);
    }
}
