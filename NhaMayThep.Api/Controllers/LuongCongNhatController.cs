using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.LichSuCongTacNhanVien;
using NhaMayThep.Application.LuongCongNhat;
using NhaMayThep.Application.LuongCongNhat.Create;
using NhaMayThep.Application.LuongCongNhat.Delete;
using NhaMayThep.Application.LuongCongNhat.Filter;
using NhaMayThep.Application.LuongCongNhat.GetAll;
using NhaMayThep.Application.LuongCongNhat.GetId;
using NhaMayThep.Application.LuongCongNhat.Update;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{

    [ApiController]
    [Authorize]
    public class LuongCongNhatController : ControllerBase
    {
        private readonly ISender _mediator;

        public LuongCongNhatController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("luong-cong-nhat")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateLuongCongNhat(
            [FromBody] CreateLuongCongNhatCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("luong-cong-nhat")]
        [ProducesResponseType(typeof(List<LuongCongNhatDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<LuongCongNhatDto>>> GetAllLuongCongNhat(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllQuery(), cancellationToken);
            return Ok(new JsonResponse<List<LuongCongNhatDto>>(result));
        }

        [HttpPut("luong-cong-nhat")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateLuongCongNhat(

            [FromBody] UpdateLuongCongNhatCommand command,
            CancellationToken cancellationToken = default)
        { 


            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("luong-cong-nhat/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteLuongCongNhat(
            [FromRoute] string id,
            CancellationToken cancellationToken = default)
        {

            var result = await _mediator.Send(new DeleteLuongCongNhatCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("luong-cong-nhat/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LuongCongNhatDto>>> GetLuongCongNhatById(string id, CancellationToken cancellationToken)
        {
            var query = new GetLuongCongNhatByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return new JsonResponse<LuongCongNhatDto>(result);
        }

        [HttpGet("luong-cong-nhat/filter")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LuongCongNhatDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<PagedResult<LuongCongNhatDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<PagedResult<LuongCongNhatDto>>>> FilterLuongCongNhat(
            [FromQuery] FilterLuongCongNhatQuery query, 
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}