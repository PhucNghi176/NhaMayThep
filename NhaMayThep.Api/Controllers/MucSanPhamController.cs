using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.PhongBan.CreatePhongBan;
using NhaMayThep.Application.PhongBan.DeletePhongBan;
using NhaMayThep.Application.PhongBan.GetSinglePhongBan;
using NhaMayThep.Application.PhongBan.UpdatePhongBan;
using NhaMayThep.Application.PhongBan;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using NhaMayThep.Application.MucSanPham;
using NhaMayThep.Application.MucSanPham.Create;
using NhaMayThep.Application.MucSanPham.GetById;
using NhaMayThep.Application.MucSanPham.Update;
using NhaMayThep.Application.MucSanPham.Delete;
using NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetAllThongTinQuaTrinhNhanSu;
using NhaMayThep.Application.ThongTinQuaTrinhNhanSu;
using NhaMayThep.Application.MucSanPham.GetAll;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MucSanPhamController : ControllerBase
    {
        private readonly ISender _mediator;
        public MucSanPhamController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("muc-san-pham")]
        [ProducesResponseType(typeof(JsonResponse<List<MucSanPhamDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<MucSanPhamDto>>>> getAllPhongBan(
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(new GetAllMucSanPhamQuery(), cancellationToken);
            return result != null ? Ok(new JsonResponse<List<MucSanPhamDto>>(result)) : NotFound();
        }

        [HttpPost("muc-san-pham")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create(
            [FromBody] CreateMucSanPhamCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpGet("muc-san-pham/{id}")]
        [ProducesResponseType(typeof(JsonResponse<MucSanPhamDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<MucSanPhamDto>>> GetByID(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetMucSanPhamByIdQuery(id: id), cancellationToken);
            return result != null ? Ok(new JsonResponse<MucSanPhamDto>(result)) : NotFound();
        }

        [HttpPut("muc-san-pham/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Update(
            [FromRoute] int id,
            [FromBody] UpdateMucSanPhamCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command.ID == default)
            {
                command.ID = id;
            }
            if (id != command.ID)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
        [HttpDelete("muc-san-pham/{id}")]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteMucSanPhamCommand(id: id), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
