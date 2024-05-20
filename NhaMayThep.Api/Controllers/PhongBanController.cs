using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.Common.Pagination;
using NhaMayThep.Application.LoaiNghiPhep;
using NhaMayThep.Application.PhongBan;
using NhaMayThep.Application.PhongBan.CreatePhongBan;
using NhaMayThep.Application.PhongBan.DeletePhongBan;
using NhaMayThep.Application.PhongBan.GetAllPhongBan;
using NhaMayThep.Application.PhongBan.GetByPagination;
using NhaMayThep.Application.PhongBan.GetSinglePhongBan;
using NhaMayThep.Application.PhongBan.UpdatePhongBan;
using System.Net.Mime;


namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    
    public class PhongBanController : ControllerBase
    {
        private readonly ISender _mediator;
        public PhongBanController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost("phong-ban")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create(
            [FromBody] CreatePhongBanCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("phong-ban/{id}")]
        [ProducesResponseType(typeof(JsonResponse<PhongBanDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PhongBanDto>>> GetByID(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetPhongBanQuery(id: id), cancellationToken);
            return result != null ? Ok(new JsonResponse<PhongBanDto>(result)) : NotFound();
        }

        [HttpGet("phong-ban")]
        [ProducesResponseType(typeof(JsonResponse<List<PhongBanDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<PhongBanDto>>>> getAllPhongBan(
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetAllPhongBanQuery(), cancellationToken);
            return result != null ? Ok(new JsonResponse<List<PhongBanDto>>(result)) : NotFound();
        }

        [HttpPut("phong-ban")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(UpdatePhongBanCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("phong-ban/{id}")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeletePhongBanCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("phong-ban/phan-trang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LoaiNghiPhepDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LoaiNghiPhepDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<LoaiNghiPhepDto>>>> GetPagination([FromQuery] GetPhongBanByPaginationQuery query, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
