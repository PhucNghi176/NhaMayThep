using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinPhuCap;
using NhaMayThep.Application.ThongTinPhuCap.CreateNewPhuCap;
using NhaMayThep.Application.ThongTinPhuCap.DeletePhuCap;
using NhaMayThep.Application.ThongTinPhuCap.GetAllPhuCap;
using NhaMayThep.Application.ThongTinPhuCap.GetPhuCapById;
using NhaMayThep.Application.ThongTinPhuCap.UpdatePhuCap;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.ThongTinPhuCap
{
    [ApiController]
    public class PhuCapController : ControllerBase
    {
        private readonly ISender _mediator;
        public PhuCapController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("phu-cap")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<int>>> CreateNewHopDong([FromBody] CreateNewPhuCapCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(CreateNewHopDong), new { id = result }, new JsonResponse<int>(result));
        }

        [HttpDelete("phu-cap/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> RemoveHopDong([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeletePhuCapCommand(id: id), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }

        [HttpGet("phu-cap")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<PhuCapDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<PhuCapDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<PhuCapDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllPhuCapQuery(), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }

        [HttpGet("phu-cap/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PhuCapDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PhuCapDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<PhuCapDto>>>> GetById([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetPhuCapByIdQuery(id: id), cancellationToken);
            return result == null ? BadRequest() : Ok(result);
        }
        [HttpPut("phu-cap/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PhuCapDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PhuCapDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PhuCapDto>>> UpdateHopDong([FromRoute] int id, [FromBody] UpdatePhuCapCommand command, CancellationToken cancellationToken = default)
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
