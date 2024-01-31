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
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByPagination;
using NhaMayThep.Application.ThongTinCongDoan.GetAll;

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
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>>> GetAll(
           [FromQuery] GetAllThongTinGiamTruGiaCanhQuery query,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-by-id/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinGiamTruGiaCanhDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinGiamTruGiaCanhDto>>> GetById(
          [FromRoute] string id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinGiamTruGiaCanhByIdQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<ThongTinGiamTruGiaCanhDto>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-by-nhan-vien-id/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinGiamTruGiaCanhDto>>>> GetByNhanVienId(
          [FromRoute] string id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinGiamTruGiaCanhByNhanVienIdQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinGiamTruGiaCanhDto>>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-all-deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>>> GetAllDeleted(
           [FromQuery] GetAllThongTinGiamTruGiaCanhDeletedQuery query,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-by-id-deleted/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinGiamTruGiaCanhDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinGiamTruGiaCanhDto>>> GetByIdDeleted(
          [FromRoute] string id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinGiamTruGiaCanhByIdDeletedQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<ThongTinGiamTruGiaCanhDto>(result));
        }
        [HttpGet("thong-tin-giam-tru-gia-canh/get-by-nhan-vien-id-deleted/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinGiamTruGiaCanhDto>>>> GetByNhanVienIdDeleted(
          [FromRoute] string id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinGiamTruGiaCanhByNhanVienIdDeletedQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinGiamTruGiaCanhDto>>(result));
        }

        [HttpGet("thong-tin-giam-tru-gia-canh/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<Dto>>>> GetPagination([FromQuery] GetThongTinGiamTruGiaCanhByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
