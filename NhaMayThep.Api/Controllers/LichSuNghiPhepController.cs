using Microsoft.AspNetCore.Mvc;
using MediatR;
using NhaMayThep.Application.LichSuNghiPhep.Create;
using NhaMayThep.Application.LichSuNghiPhep.Delete;
using NhaMayThep.Application.LichSuNghiPhep.GetAll;
using NhaMayThep.Application.LichSuNghiPhep.GetByID;
using NhaMayThep.Application.LichSuNghiPhep.Update;
using NhaMapThep.Api.Controllers.ResponseTypes;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mime;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NhaMayThep.Application.LichSuNghiPhep;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.LichSuNghiPhep.GetByPagination;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.FilterThongTinGiamTruGiaCanh;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh;
using NhaMayThep.Application.LichSuNghiPhep.Filter;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    public class LichSuNghiPhepController : ControllerBase
    {
        private readonly ISender _mediator;

        public LichSuNghiPhepController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("lich-su-nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create([FromBody] CreateLichSuNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            var message = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(message));
        }

        [HttpDelete("lich-su-nghi-phep/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(string id, CancellationToken cancellationToken = default)
        {
            var message = await _mediator.Send(new DeleteLichSuNghiPhepCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(message));
        }


        [HttpPut("lich-su-nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update([FromBody] UpdateLichSuNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            var message = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(message));
        }



        [HttpGet("lich-su-nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<LichSuNghiPhepDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var query = new GetAllLichSuNghiPhepQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<LichSuNghiPhepDto>>(result));
        }

        [HttpGet("lich-su-nghi-phep/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LichSuNghiPhepDto>>> GetById(string id, CancellationToken cancellationToken = default)
        {
            var query = new GetByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<LichSuNghiPhepDto>(result));
        }

        [HttpGet("lich-su-nghi-phep/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LichSuNghiPhepDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LichSuNghiPhepDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<LichSuNghiPhepDto>>>> GetPagination([FromQuery] GetLichSuNghiPhepByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("lich-su-nghi-phep/filter-lich-su-nghi-phep")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LichSuNghiPhepDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<LichSuNghiPhepDto>>>> FilterLichSuNghiPhep(
          [FromQuery] FilterLichSuNghiPhepQuery query,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PagedResult<LichSuNghiPhepDto>>(result));
        }
    }
}