using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.DonViCongTac;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using NhaMayThep.Application.DonViCongTac.GetAllDonViCongTac;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return CreatedAtAction(nameof(CreateDonViCongTac), new JsonResponse<int>(result));
        }

        [HttpGet("GetAllDonViCongTac")]
        [ProducesResponseType(typeof(List<DonViCongTacDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DonViCongTacDto>>> GetAllDonViCongTac(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllDonViCongTacQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
