using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.LoaiTangCa.Create;
using NhaMayThep.Application.LoaiTangCa.GetById;
using NhaMayThep.Application.LoaiTangCa.Update;
using NhaMayThep.Application.LoaiTangCa.Delete;
using NhaMayThep.Application.LoaiTangCa.GetAll;
using NhaMayThep.Application.LoaiTangCa;
using System.Net.Mime;

namespace NhaMayThep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoaiTangCaController : ControllerBase
    {
        private readonly ISender _mediator;

        public LoaiTangCaController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Create(CreateLoaiTangCaCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Loai Tang Ca created successfully"));
        }

        [HttpDelete("delete/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Delete(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteLoaiTangCaCommand(id), cancellationToken);
            return Ok(new JsonResponse<string>("Loai Tang Ca deleted successfully"));
        }



        [HttpPut("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<string>>> Update(UpdateLoaiTangCaCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new JsonResponse<string>("Loai Tang Ca updated successfully"));
        }

        [HttpGet("getAll")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<LoaiTangCaDto>>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<List<LoaiTangCaDto>>(result));
        }

        [HttpGet("getById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LoaiTangCaDto>>> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetLoaiTangCaByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<LoaiTangCaDto>(result));
        }
    }
}
