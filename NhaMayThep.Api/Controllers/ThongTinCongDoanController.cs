using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.ThongTinCongDoan;
using NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan;
using NhaMayThep.Application.ThongTinCongDoan.DeleteThongTinCongDoan;
using NhaMayThep.Application.ThongTinCongDoan.GetAll;
using NhaMayThep.Application.ThongTinCongDoan.GetAllDeleted;
using NhaMayThep.Application.ThongTinCongDoan.GetById;
using NhaMayThep.Application.ThongTinCongDoan.GetByIdDeleted;
using NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienId;
using NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienIdDeleted;
using NhaMayThep.Application.ThongTinCongDoan.GetByPagination;
using NhaMayThep.Application.ThongTinCongDoan.RestoreThongTinCongDoan;
using NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ThongTinCongDoanController : ControllerBase
    {
        private readonly ISender _mediator;
        public ThongTinCongDoanController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("thong-tin-cong-doan/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(
           [FromBody] CreateThongTinCongDoanCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost("thong-tin-cong-doan/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Restore(
           [FromBody] RestoreThongTinCongDoanCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPut("thong-tin-cong-doan/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(
           [FromBody] UpdateThongTinCongDoanCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpDelete("thong-tin-cong-doan/delete/{id}")]
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
            var result = await _mediator.Send(new DeleteThongTinCongDoanCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet("thong-tin-cong-doan/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinCongDoanDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinCongDoanDto>>>> GetAll(
            [FromQuery] GetAllThongTinCongDoanQuery query,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ThongTinCongDoanDto>>(result));
        }
        [HttpGet("thong-tin-cong-doan/get-by-id/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinCongDoanDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinCongDoanDto>>> GetById(
          [FromRoute] string id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinCongDoanByIdQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<ThongTinCongDoanDto>(result));
        }
        [HttpGet("thong-tin-cong-doan/get-by-nhan-vien-id/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinCongDoanDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinCongDoanDto>>> GetBayNhanVienId(
          [FromRoute] string id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinCongDoanByNhanVienIdQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<ThongTinCongDoanDto>(result));
        }
        [HttpGet("thong-tin-cong-doan/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinCongDoanDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinCongDoanDto>>>> GetAllDeleted(
          [FromQuery] GetAllThongTinCongDoanDeletedQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ThongTinCongDoanDto>>(result));
        }
        [HttpGet("thong-tin-cong-doan/get-by-id-deleted/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinCongDoanDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinCongDoanDto>>> GetByIdDeleted(
          [FromRoute] string id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinCongDoanByIdDeletedQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<ThongTinCongDoanDto>(result));
        }
        [HttpGet("thong-tin-cong-doan/get-by-nhan-vien-id-deleted/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinCongDoanDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinCongDoanDto>>> GetBayNhanVienIdDeleted(
          [FromRoute] string id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinCongDoanByNhanVienIdDeletedQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<ThongTinCongDoanDto>(result));
        }

        [HttpGet("thong-tin-cong-doan/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinCongDoanDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinCongDoanDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinCongDoanDto>>>> GetPagination([FromQuery] GetThongTinCongDoanByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
