using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu;
using System.Net.Mime;
using NhaMayThep.Application.PhongBan;
using NhaMayThep.Application.PhongBan.CreatePhongBan;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PhongBanController : ControllerBase
    {
        private readonly ISender _mediator;
        public PhongBanController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost("Create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(PhongBanDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PhongBanDto>> Create(
            [FromBody] CreatePhongBanCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
    }
}
