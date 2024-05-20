using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThueSuat;
using NhaMayThep.Application.ThueSuat.CreateThueSuat;
using NhaMayThep.Application.ThueSuat.DeleteThueSuat;
using NhaMayThep.Application.ThueSuat.GetAllThueSuat;
using NhaMayThep.Application.ThueSuat.GetThueSuatById;
using NhaMayThep.Application.ThueSuat.UpdateThueSuat;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.ThueSuat
{
    [ApiController]
    
    public class ThueSuatController : ControllerBase
    {
        private readonly ISender _mediator;
        public ThueSuatController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("ThueSuat")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> createThueSuat(
            [FromBody] CreateThueSuatCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(createThueSuat), new { id = result }, new JsonResponse<string>(result));
        }
        [HttpGet("ThueSuat/{ID}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThueSuatDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<ThueSuatDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThueSuatDTO>>> getThueSuatById(
            [FromRoute] int ID,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetThueSuatByIdQuery(ID), cancellationToken);
            return new JsonResponse<ThueSuatDTO>(result);
        }
        [HttpGet("ThueSuat")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThueSuatDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<ThueSuatDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThueSuatDTO>>>> getAllThueSuat(
            CancellationToken cancellation = default)
        {
            var result = await this._mediator.Send(new GetAllThueSuatQuery(), cancellation);
            return new JsonResponse<List<ThueSuatDTO>>(result);
        }
        [HttpPut("ThueSuat")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> updateThueSuat(
            [FromBody] UpdateThueSuatCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }
        [HttpDelete("ThueSuat/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> deleteThueSuat(
            [FromRoute] int Id,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new DeleteThueSuatCommand(Id), cancellationToken);
            return new JsonResponse<string>(result);
        }
    }
}
