using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ChiTietNgayNghiPhep;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Create;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Delete;
using NhaMayThep.Application.ChiTietNgayNghiPhep.GetAll;
using NhaMayThep.Application.ChiTietNgayNghiPhep.GetById;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Update;
using NhaMayThep.Application.Common.Pagination;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ChiTietNgayNghiPhepController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChiTietNgayNghiPhepController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("chi-tiet-ngay-nghi-phep")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create([FromBody] CreateChiTietNgayNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("chi-tiet-ngay-nghi-phep/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(string id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteChiTietNgayNghiPhepCommand(id);
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("ChiTietNgayNghiPhep xóa thành công "));
        }


        [HttpPut("chi-tiet-ngay-nghi-phep")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update([FromBody] UpdateChiTietNgayNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("ChiTietNgayNghiPhep cập nhật thành công"));
        }

        [HttpGet("chi-tiet-ngay-nghi-phep/getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ChiTietNgayNghiPhepDto>>>> GetAll(CancellationToken cancellationToken = default)

        {
            var query = new GetAllChiTietNghiPhepQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<ChiTietNgayNghiPhepDto>>(result));
        }

        [HttpGet("chi-tiet-ngay-nghi-phep/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ChiTietNgayNghiPhepDto>>> GetById(string id, CancellationToken cancellationToken = default)
        {
            var query = new GetChiTietNgayNghiPhepByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<ChiTietNgayNghiPhepDto>(result));
        }

        [HttpGet("chi-tiet-ngay-nghi-phep/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ChiTietNgayNghiPhepDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ChiTietNgayNghiPhepDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ChiTietNgayNghiPhepDto>>>> GetPagination([FromQuery] GetAllChiTietNghiPhepQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}

