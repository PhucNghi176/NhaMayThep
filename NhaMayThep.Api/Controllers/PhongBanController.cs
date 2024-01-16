using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu;
using System.Net.Mime;
using NhaMayThep.Application.PhongBan;
using NhaMayThep.Application.PhongBan.CreatePhongBan;
using NhaMayThep.Application.PhongBan.GetSinglePhongBan;
using NhaMayThep.Application.PhongBan.UpdatePhongBan;
using NhaMayThep.Application.PhongBan.DeletePhongBan;
using Microsoft.AspNetCore.Authorization;


namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
            var userId = User.Claims.FirstOrDefault(x => x.Type == "nameid")!.Value;
            command.nguoiTaoID = userId;
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("Get-by-ID/{id}")]
        [ProducesResponseType(typeof(PhongBanDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PhongBanDto>> GetByID(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetPhongBanQuery(id : id), cancellationToken);
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdatePhongBanCommand command,
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
            var userId = User.Claims.FirstOrDefault(x => x.Type == "nameid")!.Value;
            command.NguoiCapNhatID = userId;
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
        [HttpDelete("Delete{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "nameid")!.Value;            
            await _mediator.Send(new DeletePhongBanCommand(id: id, nguoiXoaID: userId), cancellationToken);
            return Ok();
        }
    }
}
