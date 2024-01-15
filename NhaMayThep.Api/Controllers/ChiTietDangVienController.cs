using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ChiTietDangVien;
using NhaMayThep.Application.ChiTietDangVien.CreateChiTietDangVien;
using NhaMayThep.Application.ChiTietDangVien.GetAllChiTietDangVien;
using NhaMayThep.Application.DonViCongTac;
using NhaMayThep.Application.ThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.GetAllThongTinDangVien;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return CreatedAtAction(nameof(CreateChiTietDangVien), new JsonResponse<string>(result));
        }


        [HttpGet("GetAllChiTietDangVien")]
        [ProducesResponseType(typeof(List<DonViCongTacDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ChiTietDangVienDto>>> GetAllChiTietDangVien(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllChiTietDangVienQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
