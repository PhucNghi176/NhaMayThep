using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.BangLuong.Create;
using NhaMayThep.Application.BangLuong.Delete;
using NhaMayThep.Application.BangLuong.GetById;
using NhaMayThep.Application.BangLuong.Update;
using NhaMayThep.Application.BangLuong;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using NhaMayThep.Application.BangLuong.GetAll;

namespace NhaMayThep.Api.Controllers.BangLuong
{
    [ApiController]
    [Authorize]
    public class BangLuongController : ControllerBase
    {
        private readonly ISender _mediator;

        public BangLuongController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("bang-luong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateBangLuong(
            [FromBody] CreateBangLuongCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("bang-luong")]
        [ProducesResponseType(typeof(List<BangLuongDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BangLuongDto>>> GetAllBangLuong(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllQuery(), cancellationToken);
            return Ok(new JsonResponse<List<BangLuongDto>>(result));
        }

        [HttpPut("bang-luong")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateBangLuong(

            [FromBody] UpdateBangLuongCommand command,
            CancellationToken cancellationToken = default)
        {


            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("bang-luong/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBangLuong(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new DeleteBangLuongCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("bang-luong/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<BangLuongDto>>> GetBangLuongById(string id, CancellationToken cancellationToken)
        {
            var query = new GetBangLuongByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return new JsonResponse<BangLuongDto>(result);
        }
    }
}
