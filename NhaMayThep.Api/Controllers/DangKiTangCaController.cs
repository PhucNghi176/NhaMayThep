using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using NhaMayThep.Application.DangKiTangCa.Create;
using NhaMayThep.Application.DangKiTangCa.Delete;
using NhaMayThep.Application.DangKiTangCa.Update;
using NhaMayThep.Application.DangKiTangCa.Queries.GetDangKiTangCaById;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.DangKiTangCa;
using NhaMayThep.Application.DangKiTangCa.GetId;
using NhaMayThep.Application.LichSuNghiPhep.GetAll;
using NhaMayThep.Application.LichSuNghiPhep;
using NhaMayThep.Application.DangKiTangCa.GetAll;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    
    public class DangKiTangCaController : ControllerBase
    {
        private readonly ISender _mediator;

        public DangKiTangCaController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("dang-ki-tang-ca")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<DangKiTangCaDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var query = new GetAllDangKyTangCaQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<DangKiTangCaDto>>(result));
        }

        [HttpPost("dang-ki-tang-ca")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create([FromBody] CreateDangKiTangCaCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Đăng kí tăng ca tạo thành công."));
        }

        [HttpDelete("dang-ki-tang-ca/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(string id, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new DeleteDangKiTangCaCommand (id), cancellationToken);
            return Ok(new JsonResponse<string>("Đăng kí tăng ca xóa thành công."));
        }

        [HttpPut("dang-ki-tang-ca")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update([FromBody] UpdateDangKiTangCaCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Đăng kí tăng ca cập nhật thành công."));
        }

        [HttpGet("dang-ki-tang-ca/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<DangKiTangCaDto>>> GetById(string id, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetByIdQuery { Id = id }, cancellationToken);
            return Ok(new JsonResponse<DangKiTangCaDto>(result));
        }

        
    }
}
