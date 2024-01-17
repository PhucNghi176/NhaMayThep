using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinChucVu;
using NhaMayThep.Application.ThongTinChucVu.CreateNewChucVu;
using NhaMayThep.Application.ThongTinChucVu.DeleteChucVu;
using NhaMayThep.Application.ThongTinChucVu.GetAllChucVu;
using NhaMayThep.Application.ThongTinChucVu.GetChucVuById;
using NhaMayThep.Application.ThongTinChucVu.UpdateChucVu;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.ThongTinChucVu
{
    [ApiController]
    [Authorize]
    public class ChucVuController : ControllerBase
    {
        private readonly ISender _mediator;
        public ChucVuController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("chuc-vu")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<int>>> CreateNewHopDong([FromBody] CreateNewChucVuCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(CreateNewHopDong), new { id = result }, new JsonResponse<int>(result));
        }

        [HttpDelete("chuc-vu/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> RemoveHopDong([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteChucVuCommand(id: id), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }

        [HttpGet("chuc-vu")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ChucVuDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<ChucVuDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ChucVuDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllChucVuQuery(), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }

        [HttpGet("chuc-vu/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ChucVuDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<ChucVuDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ChucVuDto>>>> GetById([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetChucVuByIdQuery(id: id), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }
        [HttpPut("chuc-vu/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ChucVuDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<ChucVuDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ChucVuDto>>> UpdateHopDong([FromRoute] int id, [FromBody] UpdateChucVuCommand command, CancellationToken cancellationToken = default)
        {
            if (command.Id == default)
                command.Id = id;
            if (id != command.Id)
                return BadRequest();
            var result = await _mediator.Send(command, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
