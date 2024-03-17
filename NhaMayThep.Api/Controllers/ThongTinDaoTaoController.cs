using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinDaoTao.Delete;
using NhaMayThep.Application.ThongTinDaoTao;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.ThongTinDaoTao.GetById;
using NhaMayThep.Application.ThongTinDaoTao.GetAll;
using NhaMayThep.Application.ThongTinDaoTao.Create;
using NhaMayThep.Application.ThongTinDaoTao.Update;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.ThongTinDaoTao.GetByPagination;
using Microsoft.AspNetCore.Authorization;
using NhaMayThep.Application.ThongTinDaoTao.FillterThongTinDaoTao;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ThongTinDaoTaoController : ControllerBase
    {
        private readonly ISender _mediator;

        public ThongTinDaoTaoController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("thong-tin-dao-tao")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateThongTinDaoTao(
            [FromBody] CreateThongTinDaoTaoCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpDelete("thong-tin-dao-tao/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteThongTinDaoTao(
            [FromRoute] string Id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteThongTinDaoTaoCommand(Id), cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpPut("thong-tin-dao-tao")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateThongTinDaoTao(
            [FromBody] UpdateThongTinDaoTaoCommand command,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _mediator.Send(command, cancellationToken);
                return new JsonResponse<string>("Thành Công!");
            }
            catch (Exception)
            {
                return BadRequest(new JsonResponse<string>("Thất Bại!"));
            }
        }

        [HttpGet("thong-tin-dao-tao/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinDaoTaoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinDaoTaoDto>>> GetThongTinDaoTaoById(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByIdQuery(id), cancellationToken);
            return new JsonResponse<ThongTinDaoTaoDto>(result);
        }

        [HttpGet("thong-tin-dao-tao")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinDaoTaoDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinDaoTaoDto>>>> GetThongTinDaoTaos(
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllQuery(), cancellationToken);
            return new JsonResponse<List<ThongTinDaoTaoDto>>(result);
        }

        [HttpGet("thong-tin-dao-tao/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinDaoTaoDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinDaoTaoDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinDaoTaoDto>>>> GetPagination([FromQuery] GetThongTinDaoTaoByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("thong-tin-dao-tao/filter-thong-tin-dao-tao")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<ThongTinDaoTaoDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<ThongTinDaoTaoDto>>>> FilterThongTinDaoTao(
            [FromQuery] FilterThongTinDaoTaoQuery query,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
