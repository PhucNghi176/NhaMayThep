using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem;
using NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Create;
using NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Delete;
using NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Filter;
using NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAll;
using NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllDeleted;
using NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllDeletedPagination;
using NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.GetAllPagination;
using NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Restore;
using NhaMayThep.Application.Common.Pagination;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    
    public class BaoHiemNhanVienChiTietBaoHiemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BaoHiemNhanVienChiTietBaoHiemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("chi-tiet-bao-hiem-nhan-vien/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(
           [FromBody] CreateBaoHiemNhanVienChiTietBaoHiemCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost]
        [Route("chi-tiet-bao-hiem-nhan-vien/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Restore(
           [FromBody] RestoreBaoHiemNhanVienChiTietBaoHiemCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpDelete]
        [Route("chi-tiet-bao-hiem-nhan-vien/delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(
           [FromBody] DeleteBaoHiemNhanVienChiTietBaoHiemCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet]
        [Route("chi-tiet-bao-hiem-nhan-vien/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<BaoHiemNhanVienChiTietBaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<BaoHiemNhanVienChiTietBaoHiemDto>>>> GetAll(
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllBaoHiemNhanVienChiTietBaoHiemQuery(), cancellationToken);
            return Ok(new JsonResponse<List<BaoHiemNhanVienChiTietBaoHiemDto>>(result));
        }
        [HttpGet]
        [Route("chi-tiet-bao-hiem-nhan-vien/get-all-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>>> GetAllPagination(
            [FromQuery] GetAllBaoHiemNhanVienChiTietbaoHiemPaginationQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>(result));
        }
        [HttpGet]
        [Route("chi-tiet-bao-hiem-nhan-vien/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<BaoHiemNhanVienChiTietBaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<BaoHiemNhanVienChiTietBaoHiemDto>>>> GetAllDeleted(
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllDeletedBaoHiemNhanVienChiTietBaoHiemQuery(), cancellationToken);
            return Ok(new JsonResponse<List<BaoHiemNhanVienChiTietBaoHiemDto>>(result));
        }
        [HttpGet]
        [Route("chi-tiet-bao-hiem-nhan-vien/get-all-deleted-pagination")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>>> GetAllDeletedPagination(
            [FromQuery] GetAllDeletedBaoHiemNhanVienChiTietBaoHiemPaginationQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>(result));
        }
        [HttpGet]
        [Route("chi-tiet-bao-hiem-nhan-vien/filter-chi-tiet-bao-hiem-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>>> Filter(
          [FromQuery] FilterBaoHiemNhanVienChiTietBaoHiemQuery query,
       CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>(result));
        }
    }
}
