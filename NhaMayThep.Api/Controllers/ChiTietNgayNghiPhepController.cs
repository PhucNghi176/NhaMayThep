using Microsoft.AspNetCore.Mvc;
using MediatR;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Create;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Delete;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Update;
using NhaMayThep.Application.ChiTietNgayNghiPhep.GetAll;
using NhaMayThep.Application.ChiTietNgayNghiPhep.GetById;
using NhaMapThep.Api.Controllers.ResponseTypes;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mime;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NhaMayThep.Application.ChiTietNgayNghiPhep;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ChiTietNgayNghiPhepController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChiTietNgayNghiPhepController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create([FromBody] CreateChiTietNgayNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("ChiTietNgayNghiPhep tạo thành công "));
        }

        [HttpDelete("delete/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(string id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteChiTietNgayNghiPhepCommand(id); 
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("ChiTietNgayNghiPhep xóa thành công "));
        }


        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update([FromBody] UpdateChiTietNgayNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("ChiTietNgayNghiPhep cập nhật thành công"));
        }

        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ChiTietNgayNghiPhepDto>>>> GetAll(CancellationToken cancellationToken = default)

        {
            var query = new GetAllChiTietNghiPhepQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<ChiTietNgayNghiPhepDto>>(result));
        }
        [HttpGet("getById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ChiTietNgayNghiPhepDto>>> GetById(string id, CancellationToken cancellationToken = default)
        {
            var query = new GetChiTietNgayNghiPhepByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<ChiTietNgayNghiPhepDto>(result));
        }
    }
}

