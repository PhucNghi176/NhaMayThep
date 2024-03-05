using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.CapBacLuong;
using NhaMayThep.Application.CapBacLuong.CreateCapBacLuong;
using NhaMayThep.Application.CapBacLuong.DeleteCapBacLuong;
using NhaMayThep.Application.CapBacLuong.GetAll;
using NhaMayThep.Application.CapBacLuong.UpdateCapBacLuong;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.CapBacLuong
{
    [ApiController]
    //[Authorize]
    public class CapBacLuongController : ControllerBase
    {
        private readonly ISender _mediator;
        public CapBacLuongController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("cap-bac-luong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(
           [FromBody] CreateCapBacLuongCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("cap-bac-luong/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<CapBacLuongDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<CapBacLuongDto>>>> GetAll(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllCapBacLuongQuery(), cancellationToken);
            return Ok(new JsonResponse<List<CapBacLuongDto>>(result));
        }

        [HttpPut("cap-bac-luong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(
           [FromBody] UpdateCapBacLuongCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("cap-bac-luong/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(
           [FromRoute] int id,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteCapBacLuongCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
