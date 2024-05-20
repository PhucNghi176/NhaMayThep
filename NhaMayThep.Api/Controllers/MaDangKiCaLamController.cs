using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.MaDangKiCaLamViec;
using NhaMayThep.Application.MaDangKiCaLamViec.Create;
using NhaMayThep.Application.MaDangKiCaLamViec.Delete;
using NhaMayThep.Application.MaDangKiCaLamViec.GetAll;
using NhaMayThep.Application.MaDangKiCaLamViec.GetById;
using NhaMayThep.Application.MaDangKiCaLamViec.Update;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    
    public class MaDangKiCaLamController : ControllerBase
    {
        private readonly ISender _mediator;
        public MaDangKiCaLamController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ma-dang-ki-ca-lam")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateMaDangKiCaLam(
           [FromBody] CreateMaDangKiCaLamCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPut("ma-dang-ki-ca-lam")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateMaDangKiCaLam(
            [FromBody] UpdateMaDangKiCaLamCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("ma-dang-ki-ca-lam/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteMaDangKiCaLam(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteMaDangKiCaLamCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("ma-dang-ki-ca-lam")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<MaDangKiCaLamViecDTO>>> GetAllMaDangKiCaLam(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllMaDangKiCaLamQuery(), cancellationToken);
            return Ok(new JsonResponse<List<MaDangKiCaLamViecDTO>>(result));
        }

        [HttpGet("ma-dang-ki-ca-lam/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MaDangKiCaLamViecDTO>> GetMaDangKiCaLamById(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetMaDangKiCaLamByIdQuery(id), cancellationToken);
            return Ok(new JsonResponse<MaDangKiCaLamViecDTO>(result));
        }
    }

}
