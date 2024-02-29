using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using System.Net.Mime;
using NhaMayThep.Application.ChiTietBaoHiem;
using NhaMayThep.Application.ChiTietBaoHiem.GetAll;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.ChiTietBaoHiem.GetAllPagination;
using NhaMayThep.Application.ChiTietBaoHiem.GetAllPaginationDeleted;
using NhaMayThep.Application.ChiTietBaoHiem.GetAllDeleted;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ChiTietBaoHiemController : ControllerBase
    {
        private readonly ISender _mediator;
        public ChiTietBaoHiemController(ISender mediator)
        {
            _mediator = mediator;
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
    }
}
