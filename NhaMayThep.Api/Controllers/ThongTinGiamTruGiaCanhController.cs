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
using NhaMayThep.Application.ThongTinGiamTruGiaCanh.UpdateThongTinGiamTruGiaCanh;
using System.Net.Mime;

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
            var userid = User.Claims.FirstOrDefault(x => x.Type == "nameid")!.Value;
            command.NguoiTao(userid);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpPut("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinGiamTruGiaCanhDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinGiamTruGiaCanhDto>>> Update(
           [FromBody] UpdateThongTinGiamTruGiaCanhCommand command,
           CancellationToken cancellationToken = default)
        {
            var userid = User.Claims.FirstOrDefault(x => x.Type == "nameid")!.Value;
            command.NguoiCapNhat(userid);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<ThongTinGiamTruGiaCanhDto>(result));
        }
        [HttpDelete("delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(
           [FromBody] DeleteThongTinGiamTruGiaCanhCommand command,
           CancellationToken cancellationToken = default)
        {
            var userid = User.Claims.FirstOrDefault(x => x.Type == "nameid")!.Value;
            command.NguoiXoa(userid);
            var result = await _mediator.Send(command, cancellationToken);
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
            var result = await _mediator.Send(new GetThonTinGiamTruGiaCanhByNhanVienIdQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinGiamTruGiaCanhDto>>(result));
        }
    }
}
