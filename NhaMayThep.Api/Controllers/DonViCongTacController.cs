using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.DonViCongTac;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using NhaMayThep.Application.DonViCongTac.DeleteDonViCongTac;
using NhaMayThep.Application.DonViCongTac.GetAllDonViCongTac;
using NhaMayThep.Application.DonViCongTac.UpdateDonViCongTac;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DonViCongTacController : ControllerBase
    {
        private readonly ISender _mediator;

        public DonViCongTacController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateDonViCongTac")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateDonViCongTac(
            [FromBody] CreateDonViCongTacCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<int>(result));
        }

        [HttpGet("GetAllDonViCongTac")]
        [ProducesResponseType(typeof(List<DonViCongTacDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DonViCongTacDto>>> GetAllDonViCongTac(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllDonViCongTacQuery(), cancellationToken);
            return Ok(new JsonResponse<List<DonViCongTacDto>>(result));
        }

        [HttpPut("UpdateDonViCongTac/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateDonViCongTac(
            [FromRoute] int id,
            [FromBody] UpdateDonViCongTacCommand command,
            CancellationToken cancellationToken = default)
        {
            command.RouteId(id);

            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<DonViCongTacDto>(result));
        }

        [HttpDelete("DeleteDonViCongTac/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteDonViCongTac([FromRoute] int id , CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteDonViCongTacCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
