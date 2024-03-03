using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.PhiCongDoan.Create;
using NhaMayThep.Application.PhiCongDoan.Delete;
using NhaMayThep.Application.PhiCongDoan.GetId;
using NhaMayThep.Application.PhiCongDoan.Update;
using NhaMayThep.Application.PhiCongDoan.GetAll;
using NhaMayThep.Application.PhiCongDoan;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class PhiCongDoanController : ControllerBase
    {
        private readonly ISender _mediator;

        public PhiCongDoanController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("phi-cong-doan")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreatePhiCongDoan(
            [FromBody] CreatePhiCongDoanCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("phi-cong-doan")]
        [ProducesResponseType(typeof(List<PhiCongDoanDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PhiCongDoanDto>>> GetAllPhiCongDoan(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllPhiCongDoanQuery(), cancellationToken);
            return Ok(new JsonResponse<List<PhiCongDoanDto>>(result));
        }

        [HttpPut("phi-cong-doan")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePhiCongDoan(

            [FromBody] UpdatePhiCongDoanCommand command,
            CancellationToken cancellationToken = default)
        {


            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("phi-cong-doan/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeletePhiCongDoan(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new DeletePhiCongDoanCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("phi-cong-doan/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PhiCongDoanDto>>> GetPhiCongDoanById(
        [FromRoute] string id,
        CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetPhiCongDoanByIdQuery(id), cancellationToken);
            return result != null ? Ok(new JsonResponse<PhiCongDoanDto>(result)) : NotFound();
        }
    }
}
