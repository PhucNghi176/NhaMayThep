using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.ThongTinLuongNhanVien.Create;
using NhaMayThep.Application.ThongTinLuongNhanVien.Delete;
using NhaMayThep.Application.ThongTinLuongNhanVien.GetAll;
using NhaMayThep.Application.ThongTinLuongNhanVien.GetById;
using NhaMayThep.Application.ThongTinLuongNhanVien.Update;
using NhaMayThep.Application.ThongTinLuongNhanVien;
using NhaMayThep.Application.ChinhSachNhanSu;
using NhaMayThep.Application.ChinhSachNhanSu.Create;
using NhaMayThep.Application.ChinhSachNhanSu.Update;
using NhaMayThep.Application.ChinhSachNhanSu.Delete;
using NhaMayThep.Application.ChinhSachNhanSu.GetById;
using NhaMayThep.Application.ChinhSachNhanSu.GetAll;
using System.Net.Mime;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChinhSachNhanSuController : ControllerBase
    {
        private readonly ISender _mediator;

        public ChinhSachNhanSuController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateUser(
            [FromBody] CreateChinhSachNhanSuCommand command,
            CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Create Success"));
        }

        [HttpPut("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ChinhSachNhanSuDto>> UpdateUser(
            [FromBody] UpdateChinhSachNhanSuCommand command,
            CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Update Success"));
        }

        [HttpDelete("delete/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteUser(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteChinhSachNhanSuCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>("Delete Success"));
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(JsonResponse<ChinhSachNhanSuDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ChinhSachNhanSuDto>> GetUserById(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetChinhSachNhanSuByIdQuery(id), cancellationToken);
            return result;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(JsonResponse<ChinhSachNhanSuDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ChinhSachNhanSuDto>>> GetAllUsers(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllChinhSachNhanSuQuery(), cancellationToken);
            return result;
        }
    }
}
