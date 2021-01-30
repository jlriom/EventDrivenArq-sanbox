using Microsoft.Extensions.Configuration;
using Sandbox.Emailer.Core;
using Sandbox.Shared.Messaging.Messages.Emails;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Sandbox.Emailer.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(EmailDto email)
        {
            var smtpClient = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation =
                    _configuration.GetValue<string>(ConfigurationKeys.SmtpPickupDirectoryLocation)
            };

            var message = new MailMessage
            {
                From = new MailAddress(_configuration.GetValue<string>(ConfigurationKeys.SmtpFrom)),
                Subject = email.Subject,
                Body = email.Body
            };

            foreach (var to in email.To)
            {
                message.To.Add(new MailAddress(to));
            }

            foreach (var cc in email.Cc)
            {
                message.CC.Add(new MailAddress(cc));
            }

            await smtpClient.SendMailAsync(message);

        }
    }
}
