using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ChiTietBaoHiem;
using NhaMayThep.Application.ChiTietBaoHiem.CreateChiTietBaoHiem;
using NhaMayThep.Application.ChiTietBaoHiem.DeleteChiTietBaoHiem;
using NhaMayThep.Application.ChiTietBaoHiem.FilterChiTietBaoHiem;
using NhaMayThep.Application.ChiTietBaoHiem.GetAll;
using NhaMayThep.Application.ChiTietBaoHiem.GetAllDeleted;
using NhaMayThep.Application.ChiTietBaoHiem.GetAllPagination;
using NhaMayThep.Application.ChiTietBaoHiem.GetAllPaginationDeleted;
using NhaMayThep.Application.ChiTietBaoHiem.GetById;
using NhaMayThep.Application.ChiTietBaoHiem.GetByIdDeleted;
using NhaMayThep.Application.ChiTietBaoHiem.RestoreChiTietBaoHiem;
using NhaMayThep.Application.ChiTietBaoHiem.UpdateChiTietBaoHiem;
using NhaMayThep.Application.Common.Pagination;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    
    public class ChiTietBaoHiemController : ControllerBase
    {
        private readonly ISender _mediator;
        public ChiTietBaoHiemController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("chi-tiet-bao-hiem/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(
           [FromBody] CreateChiTietBaoHiemCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost("chi-tiet-bao-hiem/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Restore(
           [FromBody] RestoreChiTietBaoHiemCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send<string>(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPut("chi-tiet-bao-hiem/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(
           [FromBody] UpdateChiTietBaoHiemCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send<string>(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpDelete("chi-tiet-bao-hiemn/delete/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(
           [FromRoute] string id,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send<string>(new DeleteChiTietBaoHiemCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet("chi-tiet-bao-hiem/get-by-id")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ChiTietBaoHiemDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ChiTietBaoHiemDto>>> GetById(
            [FromQuery] GetChiTietBaoHiemByIdQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send<ChiTietBaoHiemDto>(query, cancellationToken);
            return Ok(new JsonResponse<ChiTietBaoHiemDto>(result));
        }
        [HttpGet("chi-tiet-bao-hiem/get-by-id-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ChiTietBaoHiemDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ChiTietBaoHiemDto>>> GetByIdDeleted(
            [FromQuery] GetChiTietBaoHiemByIdDeletedQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send<ChiTietBaoHiemDto>(query, cancellationToken);
            return Ok(new JsonResponse<ChiTietBaoHiemDto>(result));
        }
        [HttpGet("chi-tiet-bao-hiem/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ChiTietBaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ChiTietBaoHiemDto>>>> GetAll(
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send<List<ChiTietBaoHiemDto>>(new GetAllChiTietBaoHiemQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ChiTietBaoHiemDto>>(result));
        }
        [HttpGet("chi-tiet-bao-hiem/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ChiTietBaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ChiTietBaoHiemDto>>>> GetAllDeleted(
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send<List<ChiTietBaoHiemDto>>(new GetAllDeletedChiTietBaoHiemQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ChiTietBaoHiemDto>>(result));
        }
        [HttpGet("chi-tiet-bao-hiem/get-all/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ChiTietBaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ChiTietBaoHiemDto>>>> GetAllPagination(
           [FromQuery] GetAllPaginationChiTietBaoHiemQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send<PagedResult<ChiTietBaoHiemDto>>(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ChiTietBaoHiemDto>>(result));
        }
        [HttpGet("chi-tiet-bao-hiem/get-all-deleted/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ChiTietBaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ChiTietBaoHiemDto>>>> GetAllPaginationDeleted(
           [FromQuery] GetAllPaginationDeletedChiTietBaoHiemQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send<PagedResult<ChiTietBaoHiemDto>>(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ChiTietBaoHiemDto>>(result));
        }
        [HttpGet("chi-tiet-bao-hiem/filter-chi-tiet-bao-hiem")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ChiTietBaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ChiTietBaoHiemDto>>>> FilterChiTietBaoHiem(
          [FromQuery] FilterChiTietBaoHiemQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send<PagedResult<ChiTietBaoHiemDto>>(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ChiTietBaoHiemDto>>(result));
        }
    }
}
