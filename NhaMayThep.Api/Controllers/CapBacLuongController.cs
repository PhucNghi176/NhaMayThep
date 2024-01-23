using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.CapBacLuong.CreateCapBacLuong;
using NhaMayThep.Application.ChiTietDangVien.UpdateChiTietDangVien;
using NhaMayThep.Application.ChiTietDangVien;
using System.Net.Mime;
using NhaMayThep.Application.CapBacLuong.UpdateCapBacLuong;
using NhaMayThep.Application.CapBacLuong;
using NhaMayThep.Application.ChiTietDangVien.DeleteChiTietDangVien;
using NhaMayThep.Application.CapBacLuong.DeleteCapBacLuong;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapBacLuongController : ControllerBase
    {
        private readonly ISender _mediator;

        public CapBacLuongController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateCapBacLuong")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> CreateCapBacLuong(
            [FromBody] CreateCapBacLuongCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }

        [HttpPut("updateCapbacluong/{BacLuongId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCapBacLuong(
           [FromRoute] int BacluongId,
           [FromBody] UpdateCapBacLuongCommand command,
           CancellationToken cancellationToken = default)
        {
            if (command.Id == default)
            {
                command.Id = BacluongId;
            }
            if (BacluongId != command.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<CapbacLuongDto>(result));
        }
        [HttpDelete("DeleteCapBacLuong/{BacLuongId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteCapBacLuong(
           [FromRoute] int BacLuongId,
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new DeleteCapBacLuongCommand(BacLuongId), cancellationToken);
            return Ok(new JsonResponse<string>(result));
        }
    }
}
