using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sandbox.Shared.Api.Controllers;
using Sandbox.Shared.Api.ErrorHandling.Errors;
using Sandbox.Shared.Messaging.Messages.Notifications;
using System.Threading.Tasks;

namespace Sandbox.Notifier.Api.Controllers
{
    public class NotifierController : ApiBaseController<NotifierController>
    {
        public NotifierController(
            ILogger<NotifierController> logger) : base(logger)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(AppError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedAccessError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(
            NotificationDto notification,
            [FromServices] IBus bus)
        {
            await bus.Send(new SendNotificationCommand(NewId.NextGuid(), notification)).ConfigureAwait(false);
            return Accepted();
        }
    }
}