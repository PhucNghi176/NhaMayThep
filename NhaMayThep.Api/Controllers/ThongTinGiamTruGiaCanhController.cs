using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.CreateThongTinGiamTruGiaCanh;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.DeleteThongTinGiamTruGiaCanh;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAll;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetById;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienId;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAllDeleted;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByIdDeleted;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByNhanVienIdDeleted;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.RestoreThongTinGiamTruGiaCanh;
using System.Net.Mime;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.UpdateThongTinGiamTruGiaCanh;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.ThongTinCongDoan.GetAll;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAllPaginationDeleted;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetAllPagination;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.FilterThongTinGiamTruGiaCanh;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ThongTinGiamTruGiaCanhController : ControllerBase
    {
        private readonly ISender _mediator;
        public ThongTinGiamTruGiaCanhController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("thong-tin-giam-tru-gia-canh/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(
          [FromBody] CreateThongTinGiamTruGiaCanhCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPost("thong-tin-giam-tru-gia-canh/restore")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Restore(
          [FromBody] RestoreThongTinGiamTruGiaCanhCommand command,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPut("thong-tin-giam-tru-gia-canh/update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(
           [FromBody] UpdateThongTinGiamTruGiaCanhCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpDelete("thong-tin-giam-tru-gia-canh/delete/{id}")]
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
            var result = await _mediator.Send(new DeleteThongTinGiamTruGiaCanhCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinGiamTruGiaCanhDto>>>> GetAll(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinGiamTruGiaCanhQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinGiamTruGiaCanhDto>>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinGiamTruGiaCanhDto>>>> GetAllDeleted(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinGiamTruGiaCanhDeletedQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinGiamTruGiaCanhDto>>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-all/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>>> GetAllPagination(
          [FromQuery] GetAllThongTinGiamTruGiaCanhPaginationQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-all-deleted/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>>> GetAllPaginationDeleted(
          [FromQuery] GetAllThongTinGiamTruGiaCanhPaginationDeletedQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-by-id")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinGiamTruGiaCanhDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinGiamTruGiaCanhDto>>> GetById(
          [FromQuery] GetThongTinGiamTruGiaCanhByIdQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<ThongTinGiamTruGiaCanhDto>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-by-id-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinGiamTruGiaCanhDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinGiamTruGiaCanhDto>>> GetByIdDeleted(
         [FromQuery] GetThongTinGiamTruGiaCanhByIdDeletedQuery query,
         CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<ThongTinGiamTruGiaCanhDto>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-by-nhan-vien-id")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinGiamTruGiaCanhDto>>>> GetByNhanVienId(
          [FromQuery] GetThongTinGiamTruGiaCanhByNhanVienIdQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<ThongTinGiamTruGiaCanhDto>>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-by-nhan-vien-id-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinGiamTruGiaCanhDto>>>> GetByNhanVienIdDeleted(
          [FromQuery] GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<ThongTinGiamTruGiaCanhDto>>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/filter-thong-tin-giam-tru-gia-canh")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>>> FilterThongTinGiamTruGiaCanh(
          [FromQuery] FilterThongTinGiamTruGiaCanhQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>(result));
        }
    }
}
