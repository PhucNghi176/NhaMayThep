using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.DonViCongTac;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using NhaMayThep.Application.DonViCongTac.GetAllDonViCongTac;
using NhaMayThep.Application.DonViCongTac.UpdateDonViCongTac;
using NhaMayThep.Application.NhanVien.FillterByChucVuIDOrTinhTrangLamViecID;
using NhaMayThep.Application.NhanVien;
using NhaMayThep.Application.ThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.DeleteThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.GetAllThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.GetByNhanVienIDThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien.GetByPagination;
using NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien;
using System.Net.Mime;
using NhaMayThep.Application.ThongTinDangVien.FilterThongTinDangVien;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ThongTinDangVienController : ControllerBase
    {
        private readonly ISender _mediator;

        public ThongTinDangVienController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("thong-tin-dang-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateThongTinDangVien(
            [FromBody] CreateThongTinDangVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("thong-tin-dang-vien/getAll")]
        [ProducesResponseType(typeof(List<ThongTinDangVienDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ThongTinDangVienDto>>> GetAllThongTinDangVien(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinDangVienQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinDangVienDto>>(result));
        }

        [HttpGet("thong-tin-dang-vien/{nhanVienID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByNhanVienIDThongTinDangVien(
           [FromRoute] string nhanVienID,
           CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new GetByNhanVienIDThongTinDangVienCommand(nhanVienID), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinDangVienDto>>(result));
        }

        [HttpPut("thong-tin-dang-vien")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateThongTinDangVien(
            [FromBody] UpdateThongTinDangVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("thong-tin-dang-vien/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteThongTinDangVien(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new DeleteThongTinDangVienCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("thong-tin-dang-vien/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinDangVienDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinDangVienDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinDangVienDto>>>> GetPagination([FromQuery] GetThongTinDangVienByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("thong-tin-dang-vien/filter-thong-tin-dang-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinDangVienDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinDangVienDto>>>> FilterNhanVien(
            [FromQuery] FilterThongTinDangVienQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
