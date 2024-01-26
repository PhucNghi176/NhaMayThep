using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.KhenThuong;
using NhaMayThep.Application.KhenThuong.CreateKhenThuong;
using NhaMayThep.Application.KhenThuong.DeleteKhenThuong;
using NhaMayThep.Application.KhenThuong.GetAllKhenThuong;
using NhaMayThep.Application.KhenThuong.GetKhenThuongById;
using NhaMayThep.Application.KhenThuong.UpdateKhenThuong;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.KhenThuong
{
    [ApiController]
    public class KhenThuongController : ControllerBase
    {
        private readonly ISender _mediator;
        public KhenThuongController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("KhenThuong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<KhenThuongDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<KhenThuongDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<KhenThuongDTO>>> createKhenThuong(
            [FromBody] CreateKhenThuongCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(createKhenThuong), new {id = result}, new JsonResponse<KhenThuongDTO>(result));
        }
        [HttpGet("KhenThuong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<KhenThuongDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<KhenThuongDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<KhenThuongDTO>>>> getAllKhenThuong(
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetAllKhenThuongQuery(), cancellationToken);
            return new JsonResponse<List<KhenThuongDTO>>(result);
        }
        [HttpGet("KhenThuong/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<KhenThuongDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<KhenThuongDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<KhenThuongDTO>>> getAllKhenThuong(
            [FromRoute] string Id,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetKhenThuongByIDQuery(Id), cancellationToken);
            return new JsonResponse<KhenThuongDTO>(result);
        }
        [HttpPut("KhenThuong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<KhenThuongDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<KhenThuongDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<KhenThuongDTO>>> updateKhenThuong(
            [FromBody] UpdateKhenThuongCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return new JsonResponse<KhenThuongDTO>(result);
        }
        [HttpDelete("KhenThuong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> deleteKhenThuong(
            [FromBody] DeleteKhenThuongCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }
    }
}
