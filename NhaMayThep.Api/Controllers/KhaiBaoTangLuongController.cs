using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.KhaiBaoTangLuong.Create;
using NhaMayThep.Application.KhaiBaoTangLuong.Delete;
using NhaMayThep.Application.KhaiBaoTangLuong.GetAll;
using NhaMayThep.Application.KhaiBaoTangLuong.Update;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KhaiBaoTangLuongController : ControllerBase
    {
        private readonly ISender _mediator;

        public KhaiBaoTangLuongController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateKhaiBaoTangLuong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateKhaiBaoTangLuong(
            [FromBody] CreateKhaiBaoTangLuongCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("GetAllKhaiBaoTangLuong")]
        [ProducesResponseType(typeof(List<KhaiBaoTangLuongDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<KhaiBaoTangLuongDto>>> GetAllKhaiBaoTangLuong(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllKhaiBaoTangLuongQuery(), cancellationToken);
            return Ok(new JsonResponse<List<KhaiBaoTangLuongDto>>(result));
        }

        [HttpPut("UpdateKhaiBaoTangLuong/{nhanVienId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateKhaiBaoTangLuong(
            [FromRoute] string nhanVienId,
            [FromBody] UpdateKhaiBaoTangLuongCommand command,
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
            return Ok(new JsonResponse<KhaiBaoTangLuongDto>(result));
        }

        [HttpDelete("DeleteKhaiBaoTangLuong/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteKhaiBaoTangLuong(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new DeleteKhaiBaoTangLuongCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
