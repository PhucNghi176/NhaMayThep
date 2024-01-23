using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.LuongCongNhat;
using NhaMayThep.Application.LuongCongNhat.Create;
using NhaMayThep.Application.LuongCongNhat.Delete;
using NhaMayThep.Application.LuongCongNhat.GetAll;
using NhaMayThep.Application.LuongCongNhat.Update;
using NhaMayThep.Application.ThongTinDangVien;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LuongCongNhatController : ControllerBase
    {
        private readonly ISender _mediator;

        public LuongCongNhatController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateLuongCongNhat")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateLuongCongNhat(
            [FromBody] CreateLuongCongNhatCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("GetAllLuongCongNhat")]
        [ProducesResponseType(typeof(List<LuongCongNhatDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<LuongCongNhatDto>>> GetAllLuongCongNhat(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllLuongCongNhatQuery(), cancellationToken);
            return Ok(new JsonResponse<List<LuongCongNhatDto>>(result));
        }

        [HttpPut("UpdateLuongCongNhat/{nhanVienId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateLuongCongNhat(
            [FromRoute] string nhanVienId,
            [FromBody] UpdateLuongCongNhatCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command.MaSoNhanVien == default)
            {
                command.MaSoNhanVien = nhanVienId;
            }

            if (nhanVienId != command.MaSoNhanVien)
            {
                return BadRequest("ID from route and from body are not matched");
            }

            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<LuongCongNhatDto>(result));
        }

        [HttpDelete("DeleteLuongCongNhat/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteLuongCongNhat(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new DeleteLuongCongNhatCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
