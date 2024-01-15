using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhaMapThep.Api.Controllers.ResponseTypes;
using NhaMayThep.Application.LoaiCongTac;
using NhaMayThep.Application.LoaiCongTac.Create;
using NhaMayThep.Application.LoaiCongTac.Delete;
using NhaMayThep.Application.LoaiCongTac.GetAll;
using NhaMayThep.Application.LoaiCongTac.Update;
using System.Net.Mime;

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

        //[HttpPost("create")]
        //[Produces(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(typeof(JsonResponse<LoaiCongTacDto>), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<JsonResponse<LoaiCongTacDto>>> CreateReview(
        //   [FromBody] CreateLoaiCongTacCommand command,
        //   CancellationToken cancellationToken = default)
        //{
        //    var result = await _mediator.Send(command, cancellationToken);
        //    //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
        //    return Ok(new JsonResponse<LoaiCongTacDto>(result));
        //}

        [HttpPost("update")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<LoaiCongTacDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<LoaiCongTacDto>>> UpdateReview(
            [FromBody] UpdateLoaiCongTacCommad command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return (new JsonResponse<LoaiCongTacDto>(result));
        }

        [HttpPost("delete")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<bool>>> DeleteReview(
            [FromBody] DeleteLoaiCongTacCommad command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return (new JsonResponse<bool>(result));
        }



        [HttpGet("getAll")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<List<LoaiCongTacDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<List<LoaiCongTacDto>>>> GetAllReview(
           CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllLoaiCongTacQuery(), cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return (new JsonResponse<List<LoaiCongTacDto>>(result));
        }
    }
}

