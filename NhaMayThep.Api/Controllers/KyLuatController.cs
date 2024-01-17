
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.KhenThuong.Create;
using NhaMayThep.Application.KhenThuong.Delete;
using NhaMayThep.Application.KhenThuong.GetAll;
using NhaMayThep.Application.KhenThuong.GetById;
using NhaMayThep.Application.KhenThuong.Update;
using NhaMayThep.Application.KhenThuong;
using System.Net.Mime;
using NhaMayThep.Application.KyLuat.Create;
using NhaMayThep.Application.KyLuat.Update;
using NhaMayThep.Application.KyLuat.Delete;
using NhaMayThep.Application.KyLuat;
using NhaMayThep.Application.KyLuat.GetById;
using NhaMayThep.Application.KyLuat.GetAll;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KyLuatController : ControllerBase
    {
        private readonly ISender _mediator;

        public KyLuatController(ISender mediator)
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
            [FromBody] CreateKyLuatCommand command,
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
            [FromBody] UpdateKyLuatCommand command,
            CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Update Success"));
        }

        [HttpDelete("delete/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteKyLuatCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>("Delete Success"));
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(JsonResponse<KyLuatDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<KyLuatDto>> GetById(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetKyLuatByIdQuery(id), cancellationToken);
            return result;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(JsonResponse<KyLuatDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<KyLuatDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllKyLuatQuery(), cancellationToken);
            return result;
        }
    }
}
