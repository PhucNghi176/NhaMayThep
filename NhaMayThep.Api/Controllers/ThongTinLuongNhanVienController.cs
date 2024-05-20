using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinLuongNhanVien;
using NhaMayThep.Application.ThongTinLuongNhanVien.Create;
using NhaMayThep.Application.ThongTinLuongNhanVien.Delete;
using NhaMayThep.Application.ThongTinLuongNhanVien.GetAll;
using NhaMayThep.Application.ThongTinLuongNhanVien.GetById;
using NhaMayThep.Application.ThongTinLuongNhanVien.Update;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{

    [ApiController]
    
    public class ThongTinLuongNhanVienController : ControllerBase
    {
        private readonly ISender _mediator;

        public ThongTinLuongNhanVienController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("thong-tin-luong-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateThongTinLuongNhanVien(
           [FromBody] CreateThongTinLuongNhanVienCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPut("thong-tin-luong-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateThongTinLuongNhanVien(
            [FromBody] UpdateThongTinLuongNhanVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("thong-tin-luong-nhan-vien/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteThongTinLuongNhanVien(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteThongTinLuongNhanVienCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("thong-tin-luong-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ThongTinLuongNhanVienDTO>>> GetAllThongTinLuongNhanVien(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinLuongNhanVienQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinLuongNhanVienDTO>>(result));
        }

        [HttpGet("thong-tin-luong-nhan-vien/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ThongTinLuongNhanVienDTO>> GetThongTinLuongNhanVien(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinLuongNhanVienByIdQuery(id), cancellationToken);
            return Ok(new JsonResponse<ThongTinLuongNhanVienDTO>(result));
        }
    }
}
