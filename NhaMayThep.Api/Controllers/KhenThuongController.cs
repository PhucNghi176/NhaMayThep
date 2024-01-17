using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.KhaiBaoTangLuong.Create;
using NhaMayThep.Application.KhaiBaoTangLuong.Delete;
using NhaMayThep.Application.KhaiBaoTangLuong.GetAll;
using NhaMayThep.Application.KhaiBaoTangLuong.GetById;
using NhaMayThep.Application.KhaiBaoTangLuong.Update;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System.Net.Mime;
using NhaMayThep.Application.KhenThuong.Create;
using NhaMayThep.Application.KhenThuong.Update;
using NhaMayThep.Application.KhenThuong.Delete;
using NhaMayThep.Application.KhenThuong;
using NhaMayThep.Application.KhenThuong.GetById;
using NhaMayThep.Application.KhenThuong.GetAll;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhenThuongController : ControllerBase
    {
        private readonly ISender _mediator;

        public KhenThuongController(ISender mediator)
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
            [FromBody] CreateKhenThuongCommand command,
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
            [FromBody] UpdateKhenThuongCommand command,
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
            await _mediator.Send(new DeleteKhenThuongCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>("Delete Success"));
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(JsonResponse<KhenThuongDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<KhenThuongDto>> GetById(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetKhenThuongByIdQuery(id), cancellationToken);
            return result;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(JsonResponse<KhenThuongDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<KhenThuongDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllKhenThuongQuery(), cancellationToken);
            return result;
        }
    }
}
