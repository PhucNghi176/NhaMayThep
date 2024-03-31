using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Create;
using NhaMayThep.Application.LuongThoiGian.CreateLuongThoiGian;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [Authorize]
    public class BaoHiemNhanVienChiTietBaoHiemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BaoHiemNhanVienChiTietBaoHiemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("chi-tiet-bao-hiem-nhan-vien/create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(
           [FromBody] CreateBaoHiemNhanVienChiTietBaoHiemCommand command,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
