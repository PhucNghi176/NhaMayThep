using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.KhaiBaoTangLuong.Create;
using NhaMayThep.Application.KhaiBaoTangLuong.Delete;
using NhaMayThep.Application.KhaiBaoTangLuong.GetId;
using NhaMayThep.Application.KhaiBaoTangLuong.Update;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using NhaMayThep.Application.KhaiBaoTangLuong.GetAll;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class KhaiBaoTangLuongController : ControllerBase
    {
        private readonly ISender _mediator;

        public KhaiBaoTangLuongController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("khai-bao-tang-luong")]
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

        [HttpGet("khai-bao-tang-luong")]
        [ProducesResponseType(typeof(List<KhaiBaoTangLuongDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<KhaiBaoTangLuongDto>>> GetAllKhaiBaoTangLuong(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllKhaiBaoTangLuongQuery(), cancellationToken);
            return Ok(new JsonResponse<List<KhaiBaoTangLuongDto>>(result));
        }

        [HttpPut("khai-bao-tang-luong")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateKhaiBaoTangLuong(

            [FromBody] UpdateKhaiBaoTangLuongCommand command,
            CancellationToken cancellationToken = default)
        {


            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("khai-bao-tang-luong/{id}")]
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

        [HttpGet("khai-bao-tang-luong/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<KhaiBaoTangLuongDto>>> GetKhaiBaoTangLuongById(
        [FromRoute] string id,
        CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetKhaiBaoTangLuongByIdQuery(id), cancellationToken);
            return result != null ? Ok(new JsonResponse<KhaiBaoTangLuongDto>(result)) : NotFound();
        }
    }
}
