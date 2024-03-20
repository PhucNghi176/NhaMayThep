using Humanizer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Application.Common.Security;
using NhaMayThep.Application.HopDong.FilterHopDong;
using NhaMayThep.Application.HopDong;
using NhaMayThep.Application.KyLuat;
using NhaMayThep.Application.KyLuat.CreateKyLuat;
using NhaMayThep.Application.KyLuat.DeleteKyLuat;
using NhaMayThep.Application.KyLuat.GetAllKyLuat;
using NhaMayThep.Application.KyLuat.GetByPagination;
using NhaMayThep.Application.KyLuat.GetKyLuatById;
using NhaMayThep.Application.KyLuat.UpdateKyLuat;
using System.Net.Mime;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using NhaMayThep.Application.KyLuat.FilterKyLuat;

namespace NhaMayThep.Api.Controllers.KyLuat
{
    [ApiController]
    [Authorize]
    public class KyLuatController : ControllerBase
    {
        private readonly ISender _mediator;
        public KyLuatController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("KyLuat")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> createKyLuat(
            [FromBody] CreateKyLuatCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(createKyLuat), new { id = result }, new JsonResponse<string>(result));
        }
        [HttpGet("KyLuat")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<KyLuatDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<List<KyLuatDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<KyLuatDTO>>>> getAllKyLuat(
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetAllKyLuatQuery(), cancellationToken);
            return new JsonResponse<List<KyLuatDTO>>(result);
        }
        [HttpGet("KyLuat/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<KyLuatDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<KyLuatDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<KyLuatDTO>>> getKyLuatByID(
            [FromRoute] string Id,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetKyLuatByIDQuery(Id), cancellationToken);
            return new JsonResponse<KyLuatDTO>(result);
        }
        [HttpPut("KyLuat")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<JsonResponse<string>>> updateKyLuat(
            [FromBody] UpdateKyLuatCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }
        [HttpDelete("KyLuat/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<JsonResponse<string>>> deleteKyLuat(
            [FromRoute] string Id,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new DeleteKyLuatCommand(Id), cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpGet("ky-luat/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<KyLuatDTO>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<KyLuatDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<KyLuatDTO>>>> GetPagination([FromQuery] GetKyLuatByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("ky-luat/filter-ky-luat")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<KyLuatDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<KyLuatDTO>>>> FilterKyLuat(
        [FromQuery] FilterKyLuatQuery query,
        CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

    }
}
