using Microsoft.AspNetCore.Mvc;
using MediatR;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Create;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mime;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Application.ChiTietNgayNghiPhep;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.LichSuNghiPhep;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Delete;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Update;
using NhaMayThep.Application.ChiTietNgayNghiPhep.GetAll;
using NhaMayThep.Application.ChiTietNgayNghiPhep.GetById;

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
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ChiTietNgayNghiPhepDto>>> Create([FromBody] CreateChiTietNgayNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);
                return Ok(new JsonResponse<ChiTietNgayNghiPhepDto>(result));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new JsonResponse<string>(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse<string>(ex.Message));
            }
        }
        [HttpDelete("delete/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(string id, CancellationToken cancellationToken = default)
        {
            try
            {
                var command = new DeleteChiTietNgayNghiPhepCommand { Id = id };
                var result = await _mediator.Send(command, cancellationToken);

                if (result == null) // Check if the result is null, meaning record not found
                {
                    return NotFound(new JsonResponse<string>("ChiTietNgayNghiPhep not found"));
                }

                return Ok(new JsonResponse<string>("ChiTietNgayNghiPhep deleted successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new JsonResponse<string>(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse<string>(ex.Message));
            }
        }

        [HttpPut("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ChiTietNgayNghiPhepDto>>> Update(UpdateChiTietNgayNghiPhepCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);
                return Ok(new JsonResponse<ChiTietNgayNghiPhepDto>(result));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new JsonResponse<string>(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse<string>(ex.Message));
            }
        }
        [HttpGet("getAll")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<ChiTietNgayNghiPhepDto>>>> GetAll(CancellationToken cancellationToken = default)
        {
            var query = new GetAllChiTietNghiPhepQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<ChiTietNgayNghiPhepDto>>(result));
        }

        [HttpGet("getById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<ChiTietNgayNghiPhepDto>>> GetById(string id, CancellationToken cancellationToken = default)
        {
            var query = new GetChiTietNgayNghiPhepByIdQuery(id);
            try
            {
                var result = await _mediator.Send(query, cancellationToken);
                return Ok(new JsonResponse<ChiTietNgayNghiPhepDto>(result));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new JsonResponse<string>(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new JsonResponse<string>(ex.Message));
            }
        }
    }
}
