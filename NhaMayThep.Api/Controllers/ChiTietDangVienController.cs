using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using Microsoft.AspNetCore.Authorization;
using NhaMayThep.Application.ChiTietDangVien;
using NhaMayThep.Application.ChiTietDangVien.CreateChiTietDangVien;
using NhaMayThep.Application.ChiTietDangVien.DeleteChiTietDangVien;
using NhaMayThep.Application.ChiTietDangVien.GetAllChiTietDangVien;
using NhaMayThep.Application.ChiTietDangVien.UpdateChiTietDangVien;


using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChiTietDangVienController : ControllerBase
    {
        private readonly ISender _mediator;

        public ChiTietDangVienController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateChiTietDangVien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateChiTietDangVien(
            [FromBody] CreateChiTietDangVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }


        [HttpGet("GetAllChiTietDangVien")]
        [ProducesResponseType(typeof(List<ChiTietDangVienDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ChiTietDangVienDto>>> GetAllChiTietDangVien(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllChiTietDangVienQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ChiTietDangVienDto>>(result));
        }

        [HttpPut("UpdateChiTietDangVien/{nhanVienId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateChiTietDangVien(
            [FromRoute] string nhanVienId,
            [FromBody] UpdateChiTietDangVienCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command.NhanVienID == default)
            {
                command.NhanVienID = nhanVienId;
            }

            if (nhanVienId != command.NhanVienID)
            {
                return BadRequest("ID from route and from body are not matched");
            }

            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<ChiTietDangVienDto>(result));
        }

        [HttpDelete("DeleteChiTietDangVien/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteChiTietDangVien(
           [FromRoute] string id,
           CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new DeleteChiTietDangVienCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
