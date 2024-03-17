using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.NghiPhep;
using NhaMayThep.Application.NghiPhep.Create;
using NhaMayThep.Application.NghiPhep.Delete;
using NhaMayThep.Application.NghiPhep.GetById;
using NhaMayThep.Application.NghiPhep.GetAll;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Application.NghiPhep.Update;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.NghiPhep.FilterNghiPhep;

namespace NhaMapThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class NghiPhepController : ControllerBase
    {
        private readonly ISender _mediator;

        public NghiPhepController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateNghiPhep(
            [FromBody] CreateNghiPhepCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpDelete("nghi-phep/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteNghiPhep(
            [FromRoute] string Id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteNghiPhepCommand(Id), cancellationToken);
            return new JsonResponse<string>(result);
        }
        [HttpPut("nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateNghiPhep(
            [FromBody] UpdateNghiPhepCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }


        [HttpGet("nghi-phep/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<NghiPhepDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<NghiPhepDto>>> GetNghiPhepById(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByIdQuery(id), cancellationToken);
            return new JsonResponse<NghiPhepDto>(result);
        }

        [HttpGet("nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<NghiPhepDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<NghiPhepDto>>>> GetNghiPheps(
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllQuery(), cancellationToken);
            return new JsonResponse<List<NghiPhepDto>>(result);
        }

        [HttpGet]
        [Route("nghi-phep/filter-nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<NghiPhepDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<NghiPhepDto>>>> FilterNghiPhep(
            [FromQuery] FilterNghiPhepQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
