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
using NhaMayThep.Application.ChiTietDangVien.GetByNhanVienIDChiTietDangVien;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ChiTietDangVienController : ControllerBase
    {
        private readonly ISender _mediator;

        public ChiTietDangVienController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("chi-tiet-dang-vien")]
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


        [HttpGet("chi-tiet-dang-vien/getAll")]
        [ProducesResponseType(typeof(List<ChiTietDangVienDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ChiTietDangVienDto>>> GetAllChiTietDangVien(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllChiTietDangVienQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ChiTietDangVienDto>>(result));
        }

        [HttpGet("chi-tiet-dang-vien/{nhanVienID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByNhanVienIDChiTietDangVien(
           [FromRoute] string nhanVienID,
           CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new GetByNhanVienIDChiTietDangVienCommand(nhanVienID), cancellationToken);
            return Ok(new JsonResponse<ChiTietDangVienDto>(result));
        }

        [HttpPut("chi-tiet-dang-vien")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateChiTietDangVien(
            [FromBody] UpdateChiTietDangVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<ChiTietDangVienDto>(result));
        }

        [HttpDelete("chi-tiet-dang-vien/{id}")]
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
