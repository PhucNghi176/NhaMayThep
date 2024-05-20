using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.BaoHiemNhanVien;
using NhaMayThep.Application.BaoHiemNhanVien.Create;
using NhaMayThep.Application.BaoHiemNhanVien.Delete;
using NhaMayThep.Application.BaoHiemNhanVien.FilterBaoHiemNhanVien;
using NhaMayThep.Application.BaoHiemNhanVien.GetAll;
using NhaMayThep.Application.BaoHiemNhanVien.GetById;
using NhaMayThep.Application.BaoHiemNhanVien.Update;
using NhaMayThep.Application.Common.Pagination;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    
    public class BaoHiemNhanVienController : ControllerBase
    {
        private readonly ISender _mediator;

        public BaoHiemNhanVienController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("bao-hiem-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateBaoHiemNhanVien(
            [FromBody] CreateBaoHiemNhanVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpDelete("bao-hiem-nhan-vien/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteBaoHiemNhanVien(
            [FromRoute] int Id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteBaoHiemNhanVienCommand(Id), cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpPut("bao-hiem-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateBaoHiemNhanVien(
            [FromBody] UpdateBaoHiemNhanVienCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("bao-hiem-nhan-vien/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<BaoHiemNhanVienDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<BaoHiemNhanVienDto>>> GetBaoHiemNhanVienById(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByIdQuery(id), cancellationToken);
            return new JsonResponse<BaoHiemNhanVienDto>(result);
        }

        [HttpGet("bao-hiem-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<BaoHiemNhanVienDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<BaoHiemNhanVienDto>>>> GetBaoHiemNhanViens(
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllQuery(), cancellationToken);
            return new JsonResponse<List<BaoHiemNhanVienDto>>(result);
        }

        [HttpGet]
        [Route("bao-hiem-nhan-vien/filter-bao-hiem-nhan-vien")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<BaoHiemNhanVienDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<BaoHiemNhanVienDto>>>> FilterBaoHiemNhanVien(
            [FromQuery] FilterBaoHiemNhanVienQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
