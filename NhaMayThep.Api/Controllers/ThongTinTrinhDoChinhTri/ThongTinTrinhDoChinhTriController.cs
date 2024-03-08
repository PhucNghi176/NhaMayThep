using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinTrinhDoChinhTri;
using NhaMayThep.Application.ThongTinTrinhDoChinhTri.CreateThongTinTrinhDoChinhTri;
using NhaMayThep.Application.ThongTinTrinhDoChinhTri.DeleteThongTinTrinhDoChinhTri;
using NhaMayThep.Application.ThongTinTrinhDoChinhTri.GetAll;
using NhaMayThep.Application.ThongTinTrinhDoChinhTri.UpdateThongTinTrinhDoChinhTri;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.ThongTinTrinhDoChinhTri
{
    [ApiController]
    [Authorize]
    public class ThongTinTrinhDoChinhTriController : ControllerBase
    {
        private readonly ISender _mediator;
        public ThongTinTrinhDoChinhTriController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("thong-tin-trinh-do-chinh-tri")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(
           [FromBody] CreateThongTinTrinhDoChinhTriCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("thong-tin-trinh-do-chinh-tri/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinTrinhDoChinhTriDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinTrinhDoChinhTriDto>>>> GetAll(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinTrinhDoChinhTriQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinTrinhDoChinhTriDto>>(result));
        }

        [HttpPut("thong-tin-trinh-do-chinh-tri")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(
           [FromBody] UpdateThongTinTrinhDoChinhTriCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("thong-tin-trinh-do-chinh-tri/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(
           [FromRoute] int id,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteThongTinTrinhDoChinhTriCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
