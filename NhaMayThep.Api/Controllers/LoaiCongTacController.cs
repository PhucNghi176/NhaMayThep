using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.LoaiCongTac;
using NhaMayThep.Application.LoaiCongTac.Create;
using NhaMayThep.Application.LoaiCongTac.Delete;
using NhaMayThep.Application.LoaiCongTac.GetAll;
using NhaMayThep.Application.LoaiCongTac.Update;
using NhaMayThep.Application.LoaiHoaDon.Create;
using NhaMayThep.Application.LoaiHoaDon;
using System.Net.Mime;
using NhaMayThep.Application.LoaiHoaDon.GetAll;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiCongTacController : ControllerBase
    {
        private readonly ISender _mediator;
        
        public LoaiCongTacController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateLoaiCongTac(
                 [FromBody] CreateLoaiCongTacCommand command,
                 CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<string>("create success"));
        }

        [HttpPut("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateLoaiCongTac(
            [FromBody] UpdateLoaiCongTacCommad command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<string>("update success"));
        }

        [HttpDelete("delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> DeleteLoaiCongTac(
            [FromBody] DeleteLoaiCongTacCommad command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<string>(result));
        }



        [HttpGet("getAll")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllLoaiCongTac(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllLoaiCongTacQuery(), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return Ok(new JsonResponse<List<LoaiCongTacDto>>(result));
        }
    }
}

