using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.DonViCongTac;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using NhaMayThep.Application.DonViCongTac.GetAllDonViCongTac;
using NhaMayThep.Application.DonViCongTac.UpdateDonViCongTac;
using NhaMayThep.Application.ThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.DeleteThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.GetAllThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinDangVienController : ControllerBase
    {
        private readonly ISender _mediator;

        public ThongTinDangVienController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateThongTinDangVien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateThongTinDangVien(
            [FromBody] CreateThongTinDangVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(CreateThongTinDangVien), new JsonResponse<string>(result));
        }

        [HttpGet("GetAllThongTinDangVien")]
        [ProducesResponseType(typeof(List<DonViCongTacDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ThongTinDangVienDto>>> GetAllThongTinDangVien(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinDangVienQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpPut("UpdateThongTinDangVien/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateThongTinDangVien(
            [FromRoute] string id,
            [FromBody] UpdateThongTinDangVienCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command.ID == default)
            {
                command.ID = id;
            }

            if (id != command.ID)
            {
                return BadRequest("ID from route and from body are not matched");
            }

            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("DeleteThongTinDangVien/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteThongTinDangVien(
            [FromRoute] string id,
            [FromBody] string nguoiXoaId,
            CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new DeleteThongTinDangVienCommand(id: id, nguoiXoaID: nguoiXoaId), cancellationToken);
            return Ok(result);
        }
    }
}
