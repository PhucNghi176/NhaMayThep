using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinCongDoan;
using NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan;
using NhaMayThep.Application.ThongTinCongDoan.DeleteThongTinCongDoan;
using NhaMayThep.Application.ThongTinCongDoan.GetAll;
using NhaMayThep.Application.ThongTinCongDoan.GetById;
using NhaMayThep.Application.ThongTinCongDoan.GetByNhanVienId;
using NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ThongTinCongDoanController : ControllerBase
    {
        private readonly ISender _mediator;
        public ThongTinCongDoanController(ISender mediator)
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
           [FromBody] CreateThongTinCongDoanCommand command,
           CancellationToken cancellationToken = default)
        {
            var userid = User.Claims.FirstOrDefault(x => x.Type == "nameid")!.Value; //Only create when user is authentication and authorized
            command.NguoiTao(userid);
            var result = await _mediator.Send(command, cancellationToken);
            return result > 0 
                ? Ok(new JsonResponse<string>("Create Successfully")) 
                : BadRequest(new JsonResponse<string>("Create Failed"));
        }
        [HttpPut("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinCongDoanDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinCongDoanDto>>> Update(
           [FromBody] UpdateThongTinCongDoanCommand command,
           CancellationToken cancellationToken = default)
        {
            var userid = User.Claims.FirstOrDefault(x => x.Type == "nameid")!.Value; //Only create when user is authentication and authorized
            command.NguoiCapNhat(userid);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<ThongTinCongDoanDto>(result));
        }
        [HttpDelete("delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<int>>> Delete(
           [FromBody] DeleteThongTinCongDoanCommand command,
           CancellationToken cancellationToken = default)
        {
            var userid = User.Claims.FirstOrDefault(x => x.Type == "nameid")!.Value; //Only create when user is authentication and authorized
            command.NguoiXoa(userid);
            var result = await _mediator.Send(command, cancellationToken);
            return result > 0 
                ? Ok(new JsonResponse<string>("Delete Successfully")) 
                : BadRequest(new JsonResponse<string>("Delete Failed"));
        }
        [HttpGet("getall")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<ThongTinCongDoanDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ThongTinCongDoanDto>>>> GetAll(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllThongTinCongDoanQuery(), cancellationToken);
            return Ok(new JsonResponse<List<ThongTinCongDoanDto>>(result));
        }
        [HttpGet("get_by_id/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinCongDoanDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinCongDoanDto>>> GetById(
          [FromRoute] string id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinCongDoanByIdQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<ThongTinCongDoanDto>(result));
        }
        [HttpGet("get_by_nhanvien_id/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<ThongTinCongDoanDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ThongTinCongDoanDto>>> GetBayNhanVienId(
          [FromRoute] string id,
          CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetThongTinCongDoanByNhanVienIdQuery(id: id), cancellationToken);
            return Ok(new JsonResponse<ThongTinCongDoanDto>(result));
        }
    }
}
