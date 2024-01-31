using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.LoaiTangCa.Create;
using NhaMayThep.Application.LoaiTangCa.Update;
using NhaMayThep.Application.LoaiTangCa.GetAll;
using NhaMayThep.Application.LoaiTangCa;
using System.Net.Mime;
using NhaMayThep.Application.LoaiTangCa.GetId;
using NhaMayThep.Application.LoaiTangCa.Delete;

using Microsoft.AspNetCore.Authorization;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class LoaiTangCaController : ControllerBase
    {
        private readonly ISender _mediator;

        public LoaiTangCaController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> CreateLoaiTangCa([FromBody] CreateLoaiTangCaCommand command, CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpDelete("delete/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> DeleteLoaiTangCa(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteLoaiTangCaCommand(id), cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpPut("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(JsonResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> UpdateLoaiTangCa(
            [FromBody] UpdateLoaiTangCaCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await this._mediator.Send(command, cancellationToken);
            return new JsonResponse<string>(result);
        }

        [HttpGet("getAllLoaiTangCa")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<LoaiTangCaDto>>>> GetAllLoaiTangCa(CancellationToken cancellationToken)
        {
            var query = new GetAllQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return new JsonResponse<List<LoaiTangCaDto>>(result);
        }

        [HttpGet("getLoaiTangCaById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LoaiTangCaDto>>> GetLoaiTangCaById(int id, CancellationToken cancellationToken)
        {
            var query = new GetLoaiTangCaByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return new JsonResponse<LoaiTangCaDto>(result);
        }
    }
}