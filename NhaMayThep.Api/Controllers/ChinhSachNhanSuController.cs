using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using System.Net.Mime;
using NhaMayThep.Application.ChinhSachNhanSu;
using NhaMayThep.Application.ChinhSachNhanSu.Create;
using NhaMayThep.Application.ChinhSachNhanSu.GetById;
using NhaMayThep.Application.ChinhSachNhanSu.Update;
using NhaMayThep.Application.ChinhSachNhanSu.Delete;
using NhaMayThep.Application.ChinhSachNhanSu.GetAll;
using Microsoft.AspNetCore.Authorization;
using NhaMayThep.Application.ChinhSachNhanSu.FilterChinhSachNhanSu;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ChinhSachNhanSuController : ControllerBase
    {
        private readonly ISender _mediator;
        public ChinhSachNhanSuController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("chinh-sach-nhan-su")]
        [ProducesResponseType(typeof(JsonResponse<List<ChinhSachNhanSuDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ChinhSachNhanSuDto>>>> getAllChinhSachNhanSu(
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetAllChinhSachNhanSuQuery(), cancellationToken);
            return result != null ? Ok(new JsonResponse<List<ChinhSachNhanSuDto>>(result)) : NotFound();
        }

        [HttpPost("chinh-sach-nhan-su")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create(
            [FromBody] CreateChinhSachNhanSuCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("chinh-sach-nhan-su/{id}")]
        [ProducesResponseType(typeof(JsonResponse<ChinhSachNhanSuDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ChinhSachNhanSuDto>>> GetByID(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetChinhSachNhanByIdQuery(id: id), cancellationToken);
            return result != null ? Ok(new JsonResponse<ChinhSachNhanSuDto>(result)) : NotFound();
        }

        [HttpPut("chinh-sach-nhan-su/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Update(
            [FromRoute] int id,
            [FromBody] UpdateChinhSachNhanSuCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command.ID == default)
            {
                command.ID = id;
            }
            if (id != command.ID)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpDelete("chinh-sach-nhan-su/{id}")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteChinhSachNhanSuCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet]
        [Route("chinh-sach-nhan-su/filter-chinh-sach-nhan-su")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ChinhSachNhanSuDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ChinhSachNhanSuDto>>>> FilterChinhSachNhanSu(
            [FromQuery] FilterChinhSachNhanSuQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
