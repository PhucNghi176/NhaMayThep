using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.NghiPhep.Create;
using NhaMayThep.Application.NghiPhep.Delete;
using NhaMayThep.Application.NghiPhep.GetById;
using NhaMayThep.Application.NghiPhep.Update;
using NhaMayThep.Application.NghiPhep;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using NhaMayThep.Application.NghiPhep.GetAll;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class NghiPhepController : ControllerBase
    {
        private readonly ISender _mediator;

        public NghiPhepController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateNghiPhep(
            [FromBody] CreateNghiPhepCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("nghi-phep")]
        [ProducesResponseType(typeof(List<NghiPhepDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<NghiPhepDto>>> GetAllNghiPhep(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllNghiPhepQuery(), cancellationToken);
            return Ok(new JsonResponse<List<NghiPhepDto>>(result));
        }

        [HttpPut("nghi-phep")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateNghiPhep(

            [FromBody] UpdateNghiPhepCommand command,
            CancellationToken cancellationToken = default)
        {


            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("nghi-phep/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteNghiPhep(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new DeleteNghiPhepCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("nghi-phep/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<NghiPhepDto>>> GetNghiPhepById(
        [FromRoute] string id,
        CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetNghiPhepByIdQuery(id), cancellationToken);
            return result != null ? Ok(new JsonResponse<NghiPhepDto>(result)) : NotFound();
        }

    }
}
