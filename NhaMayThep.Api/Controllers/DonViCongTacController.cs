using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.DonViCongTac;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using NhaMayThep.Application.DonViCongTac.DeleteDonViCongTac;
using NhaMayThep.Application.DonViCongTac.GetAllDonViCongTac;
using NhaMayThep.Application.DonViCongTac.GetByIDDonViCongTac;
using NhaMayThep.Application.DonViCongTac.GetByPagination;
using NhaMayThep.Application.DonViCongTac.UpdateDonViCongTac;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    //[Authorize]
    public class DonViCongTacController : ControllerBase
    {
        private readonly ISender _mediator;

        public DonViCongTacController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("don-vi-cong-tac")]
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
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("don-vi-cong-tac/getAll")]
        [ProducesResponseType(typeof(List<DonViCongTacDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DonViCongTacDto>>> GetAllDonViCongTac(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllDonViCongTacQuery(), cancellationToken);
            return Ok(new JsonResponse<List<DonViCongTacDto>>(result));
        }

        [HttpGet("don-vi-cong-tac/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByIDDonViCongTac([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByIDDonViCongTacCommand(id), cancellationToken);
            return Ok(new JsonResponse<DonViCongTacDto>(result));
        }

        [HttpPut("don-vi-cong-tac")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateDonViCongTac(
            [FromBody] UpdateDonViCongTacCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("don-vi-cong-tac/{id}")]
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

        [HttpGet("don-vi-cong-tac/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<DonViCongTacDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<DonViCongTacDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<DonViCongTacDto>>>> GetPagination([FromQuery] GetDonVICongTacByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
