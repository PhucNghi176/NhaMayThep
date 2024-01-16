using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using System.Net.Mime;
using NhaMayThep.Application.ThongTinChucDanh.CreateNewChucDanh;
using NhaMayThep.Application.ThongTinChucDanh.DeleteChucDanh;
using NhaMayThep.Application.ThongTinChucDanh.GetAllChucDanh;
using NhaMayThep.Application.ThongTinChucDanh.GetChucDanhById;
using NhaMayThep.Application.ThongTinChucDanh.UpdateChucDanh;
using NhaMayThep.Application.ThongTinChucDanh;

namespace NhaMayThep.Api.Controllers.ThongTinChucDanh
{
    [ApiController]
    public class ChucDanhController : ControllerBase
    {
        private readonly ISender _mediator;
        public ChucDanhController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("chuc-danh")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<int>>> CreateNewHopDong([FromBody] CreateNewChucDanhCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(CreateNewHopDong), new { id = result }, new JsonResponse<int>(result));
        }

        [HttpDelete("chuc-danh/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> RemoveHopDong([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteChucDanhCommand(id: id), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }

        [HttpGet("chuc-danh")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ChucDanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<ChucDanhDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ChucDanhDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllChucDanhQuery(), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }

        [HttpGet("chuc-danh/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ChucDanhDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<ChucDanhDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ChucDanhDto>>> GetById([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetChucDanhByIdQuery(id: id), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }
        [HttpPut("chuc-danh/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ChucDanhDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<ChucDanhDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ChucDanhDto>>> UpdateHopDong([FromRoute] int id, [FromBody] UpdateChucDanhCommand command, CancellationToken cancellationToken = default)
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
