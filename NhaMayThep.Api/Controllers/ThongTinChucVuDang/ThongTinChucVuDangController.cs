using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinChucVuDang;
using NhaMayThep.Application.ThongTinChucVuDang.CreateThongTinChucVuDang;
using NhaMayThep.Application.ThongTinChucVuDang.DeleteThongTinChucVuDang;
using NhaMayThep.Application.ThongTinChucVuDang.GetAll;
using NhaMayThep.Application.ThongTinChucVuDang.UpdateThongTinChucVuDang;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers.ThongTinChucVuDang
{
    [ApiController]
    
    public class ThongTinChucVuDangController : ControllerBase
    {
        private readonly ISender _mediator;
        public ThongTinChucVuDangController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("thong-tin-chuc-vu-dang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(
           [FromBody] CreateThongTinChucVuDangCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("thong-tin-chuc-vu-dang/get-all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinChucVuDangDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinChucVuDangDto>>>> GetAll(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinChucVuDangQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinChucVuDangDto>>(result));
        }

        [HttpPut("thong-tin-chuc-vu-dang")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(
           [FromBody] UpdateThongTinChucVuDangCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpDelete("thong-tin-chuc-vu-dang/{id}")]
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
            var result = await _mediator.Send(new DeleteThongTinChucVuDangCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
