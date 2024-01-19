using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Application.PhongBan.GetSinglePhongBan;
using NhaMayThep.Application.PhongBan;
using NhaMayThep.Application.QuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu;
using System.Net.Mime;
using NhaMayThep.Application.QuaTrinhNhanSu.GetSingleQuaTrinhNhanSu;
using NhaMayThep.Application.PhongBan.UpdatePhongBan;
using NhaMayThep.Application.QuaTrinhNhanSu.UpdateQuaTrinhNhanSu;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class QuaTrinhNhanVienController : ControllerBase
    {
        private readonly ISender _mediator;
        public QuaTrinhNhanVienController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost("Create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(QuaTrinhNhanSuDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QuaTrinhNhanSuDto>> Create(
            [FromBody] CreateQuaTrinhNhanSuCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);            
            return Ok(result);
        }

        [HttpGet("Get-by-ID/{id}")]
        [ProducesResponseType(typeof(QuaTrinhNhanSuDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QuaTrinhNhanSuDto>> GetByID(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetQuaTrinhNhanSuQuery(id : id), cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(
            [FromRoute] string id,
            [FromBody] UpdateQuaTrinhNhanSuCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command.ID == default)
            {
                command.ID = id;
            }
            if (id != command.ID)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

    }
}
