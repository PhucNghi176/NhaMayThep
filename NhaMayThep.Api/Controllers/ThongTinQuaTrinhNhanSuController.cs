using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.Common.Pagination;
using NhaMayThep.Application.ThongTinQuaTrinhNhanSu;
using NhaMayThep.Application.ThongTinQuaTrinhNhanSu.CreateThongTinQuaTrinhNhanSu;
using NhaMayThep.Application.ThongTinQuaTrinhNhanSu.DeleteThongTinQuaTrinhNhanSu;
using NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetAllThongTinQuaTrinhNhanSu;
using NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetByPagination;
using NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetSingleThongTinQuaTrinhNhanSu;
using NhaMayThep.Application.ThongTinQuaTrinhNhanSu.UpdateThongTinQuaTrinhNhanSu;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    
    public class ThongTinQuaTrinhNhanSuController : ControllerBase
    {
        private readonly ISender _mediator;
        public ThongTinQuaTrinhNhanSuController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("thong-tin-qua-trinh-nhan-su")]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinQuaTrinhNhanSuDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinQuaTrinhNhanSuDto>>>> getAllPhongBan(
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetAllThongTinQuaTrinhNhanSuQuery(), cancellationToken);
            return result != null ? Ok(new JsonResponse<List<ThongTinQuaTrinhNhanSuDto>>(result)) : NotFound();
        }

        [HttpPost("thong-tin-qua-trinh-nhan-su")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create(
            [FromBody] CreateThongTinQuaTrinhNhanSuCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("thong-tin-qua-trinh-nhan-su/{id}")]
        [ProducesResponseType(typeof(JsonResponse<ThongTinQuaTrinhNhanSuDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinQuaTrinhNhanSuDto>>> GetByID(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetSingleThongTinQuaTrinhNhanSuQuery(id: id), cancellationToken);
            return result != null ? Ok(new JsonResponse<ThongTinQuaTrinhNhanSuDto>(result)) : NotFound();
        }

        [HttpPut("thong-tin-qua-trinh-nhan-su")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(UpdateThongTinQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }


        [HttpDelete("thong-tin-qua-trinh-nhan-su/{id}")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteThongTinQuaTrinhNhanSuCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("thong-tin-qua-trinh-nhan-su/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinQuaTrinhNhanSuDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinQuaTrinhNhanSuDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinQuaTrinhNhanSuDto>>>> GetPagination([FromQuery] GetThongTinQuaTrinhNhanSuByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
