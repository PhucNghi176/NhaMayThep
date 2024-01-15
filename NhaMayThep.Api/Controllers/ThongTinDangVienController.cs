using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.DonViCongTac;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using NhaMayThep.Application.DonViCongTac.GetAllDonViCongTac;
using NhaMayThep.Application.ThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.GetAllThongTinDangVien;
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
    }
}
