using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using NhaMayThep.Application.DangKiCaLam.Create;
using NhaMayThep.Application.DangKiCaLam.Delete;
using NhaMayThep.Application.DangKiCaLam.Update;
using NhaMayThep.Application.DangKiCaLam.Queries.GetDangKiCaLamById;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.DangKiCaLam.GetAll;
using NhaMayThep.Application.DangKiCaLam;
using NhaMayThep.Application.DangKiCaLam.CheckIn;
using NhaMayThep.Application.DangKiCaLam.CheckOut;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    
    public class DangKiCaLamController : ControllerBase
    {
        private readonly ISender _mediator;

        public DangKiCaLamController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("dang-ki-ca-lam")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<DangKiCaLamDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<DangKiCaLamDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var query = new GetAllDangKiCaLamQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<DangKiCaLamDto>>(result));
        }

        [HttpPost("dang-ki-ca-lam")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create([FromBody] CreateDangKiCaLamCommand command, CancellationToken cancellationToken = default)
        {
          var result =  await _mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpDelete("dang-ki-ca-lam/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(string id, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteDangKiCaLamCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>("Đăng kí ca làm xóa thành công."));
        }

        [HttpPut("dang-ki-ca-lam")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update([FromBody] UpdateDangKiCaLamCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Đăng kí ca làm cập nhật thành công."));
        }

        [HttpGet("dang-ki-ca-lam/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<DangKiCaLamDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<DangKiCaLamDto>>> GetById(string id, CancellationToken cancellationToken = default)
        {
            var query = new GetDangKiCaLamByIdQuery (id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<DangKiCaLamDto>(result));
        }

        [HttpPost("CheckIn/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CheckIn(string id, CancellationToken cancellationToken)
        {
            var command = new CheckInCommand { Id = id };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Check-in thành công ."));
        }


        [HttpPost("CheckOut/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CheckOut(string id, CancellationToken cancellationToken)
        {
            var command = new CheckOutCommand { Id = id };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Check-out thành công."));
        }
    }
}
