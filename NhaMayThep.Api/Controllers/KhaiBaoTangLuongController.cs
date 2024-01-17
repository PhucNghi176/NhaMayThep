using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.KhaiBaoTangLuong;
using NhaMayThep.Application.KhaiBaoTangLuong.Create;
using NhaMayThep.Application.KhaiBaoTangLuong.Delete;
using NhaMayThep.Application.KhaiBaoTangLuong.GetAll;
using NhaMayThep.Application.KhaiBaoTangLuong.GetById;
using NhaMayThep.Application.KhaiBaoTangLuong.Update;
using System.Net.Mime;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhaiBaoTangLuongController : ControllerBase
    {
        private readonly ISender _mediator;

        public KhaiBaoTangLuongController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create(
            [FromBody] CreateKhaiBaoTangLuongCommand command,
            CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Create Success"));
        }

        [HttpPut("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(
            [FromBody] UpdateKhaiBaoTangLuongCommand command,
            CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Update Success"));
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteKhaiBaoTangLuongCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>("Delete Success"));
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(JsonResponse<KhaiBaoTangLuongDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<KhaiBaoTangLuongDto>> GetById(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetKhaiBaoTangLuongByIdQuery(id), cancellationToken);
            return result;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(JsonResponse<KhaiBaoTangLuongDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<KhaiBaoTangLuongDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllKhaiBaoTangLuongQuery(), cancellationToken);
            return result;
        }
    }
}
