using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.CreateTrangThaiDangKiCaLamViec;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.DeleteTrangThaiDangKiCaLamViec;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.GetAllTrangThaiDangKiCaLamViec;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.GetTrangThaiDangKiCaLamViecById;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.UpdateTrangThaiDangKiCaLamViec;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{

    [ApiController]
    
    public class TrangThaiDangKiCaLamViecController : ControllerBase
    {
        private readonly ISender _mediator;

        public TrangThaiDangKiCaLamViecController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("trang-thai-dang-ki-ca-lam-viec")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateTrangThaiCaLamViec(
           [FromBody] CreateTrangThaiDangKiCaLamViecCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPut("trang-thai-dang-ki-ca-lam-viec")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateTrangThaiCaLamViec(
            [FromBody] UpdateTrangThaiDangKiCaLamViecCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("trang-thai-dang-ki-ca-lam-viec/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteTrangThaiCaLamViec(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteTrangThaiDangKiCaLamViecCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("trang-thai-dang-ki-ca-lam-viec")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TrangThaiDangKiCaLamViecDTO>>> GetAllTrangThaiCaLamViec(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllTrangThaiDangKiCaLamViecQuery(), cancellationToken);
            return Ok(new JsonResponse<List<TrangThaiDangKiCaLamViecDTO>>(result));
        }

        [HttpGet("trang-thai-dang-ki-ca-lam-viec/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TrangThaiDangKiCaLamViecDTO>> GetTrangThaiCaLamViecById(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetTrangThaiDangKiCaLamViecByIdQuery(id), cancellationToken);
            return Ok(new JsonResponse<TrangThaiDangKiCaLamViecDTO>(result));
        }
    }

}
