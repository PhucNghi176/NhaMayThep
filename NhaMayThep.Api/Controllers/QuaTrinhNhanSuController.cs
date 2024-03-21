using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.PhongBan;
using NhaMayThep.Application.PhongBan.DeletePhongBan;
using NhaMayThep.Application.PhongBan.GetAllPhongBan;
using NhaMayThep.Application.QuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu.DeleteQuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu.GetByPagination;
using NhaMayThep.Application.QuaTrinhNhanSu.GetAllQuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu.GetSingleQuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu.UpdateQuaTrinhNhanSu;
using System.Net.Mime;
using NhaMayThep.Application.NhanVien.FillterByChucVuIDOrTinhTrangLamViecID;
using NhaMayThep.Application.NhanVien;
using NhaMayThep.Application.QuaTrinhNhanSu.FilterQuaTrinhNhanSu;
using NhaMayThep.Application.PhongBan.UpdatePhongBan;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class QuaTrinhNhanSuController : ControllerBase
    {
        private readonly ISender _mediator;
        public QuaTrinhNhanSuController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("qua-trinh-nhan-su")]
        [ProducesResponseType(typeof(JsonResponse<List<QuaTrinhNhanSuDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<QuaTrinhNhanSuDto>>>> getAllPhongBan(
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetAllQuaTrinhNhanSuQuery(), cancellationToken);
            return result != null ? Ok(new JsonResponse<List<QuaTrinhNhanSuDto>>(result)) : NotFound();
        }

        [HttpPost("qua-trinh-nhan-su")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(
            [FromBody] CreateQuaTrinhNhanSuCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("qua-trinh-nhan-su/{id}")]
        [ProducesResponseType(typeof(JsonResponse<QuaTrinhNhanSuDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<QuaTrinhNhanSuDto>>> GetByID(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetQuaTrinhNhanSuQuery(id: id), cancellationToken);
            return result == null ? NotFound() : Ok(new JsonResponse<QuaTrinhNhanSuDto>(result));
        }

        [HttpPut("qua-trinh-nhan-su")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(UpdateQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("qua-trinh-nhan-su/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete([FromRoute] string id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteQuaTrinhNhanSuCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("qua-trinh-nhan-su/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<QuaTrinhNhanSuDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<QuaTrinhNhanSuDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<QuaTrinhNhanSuDto>>>> GetPagination([FromQuery] GetQuaTrinhNhanSuByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("qua-trinh-nhan-su/filter-qua-trinh-nhan-su")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<QuaTrinhNhanSuDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<QuaTrinhNhanSuDto>>>> FilterQuaTrinhNhanSu(
            [FromQuery] FilterQuaTrinhNhanSuQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
