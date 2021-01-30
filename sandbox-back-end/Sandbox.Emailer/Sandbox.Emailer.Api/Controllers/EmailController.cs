using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sandbox.Shared.Api.Controllers;
using Sandbox.Shared.Api.ErrorHandling.Errors;
using Sandbox.Shared.Messaging.Messages.Emails;
using System.Threading.Tasks;

namespace Sandbox.EMailer.Api.Controllers
{
    public class EmailController : ApiBaseController<EmailController>
    {
        public EmailController(
            ILogger<EmailController> logger) : base(logger)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(
            EmailDto email,
            [FromServices] IBus bus)
        {
            await bus.Send(new SendEmailCommand(NewId.NextGuid(), email)).ConfigureAwait(false);
            return Accepted();
        }
    }
}