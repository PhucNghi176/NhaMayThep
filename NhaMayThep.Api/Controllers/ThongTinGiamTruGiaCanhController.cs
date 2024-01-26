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

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ThongTinGiamTruGiaCanhController : ControllerBase
    {
        private readonly ISender _mediator;
        public ThongTinGiamTruGiaCanhController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
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
        [HttpPost("restore")]
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
        [HttpPut("update")]
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
        [HttpDelete("delete/{Id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(
           [FromRoute] string Id,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteThongTinGiamTruGiaCanhCommand(id: Id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpGet("getall")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinGiamTruGiaCanhDto>>>> GetAll(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinGiamTruGiaCanhQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinGiamTruGiaCanhDto>>(result));
        }
        [HttpGet("get_by_id/{id}")]
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
        [HttpGet("getby_nhanvien_id/{id}")]
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
        [HttpGet("getall_deleted")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinGiamTruGiaCanhDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinGiamTruGiaCanhDto>>>> GetAllDeleted(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinGiamTruGiaCanhDeletedQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinGiamTruGiaCanhDto>>(result));
        }
        [HttpGet("get_by_id_deleted/{id}")]
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
        [HttpGet("getby_nhanvien_id_deleted/{id}")]
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
    }
}
