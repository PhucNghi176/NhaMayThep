using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.EmailSender;

namespace NhaMayThep.Api.Controllers.EmailSender
{
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private IMediator _mediator;
        public EmailSenderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("email-sender")]
        public async Task<ActionResult<JsonResponse<string>>> SendMail(string userEmail, string userPassword, string mail ,string subject, string body
            , CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new EmailSenderCommand(userEmail, userPassword, mail, subject, body), cancellationToken);
            return Ok(result);
        }
    }
}
